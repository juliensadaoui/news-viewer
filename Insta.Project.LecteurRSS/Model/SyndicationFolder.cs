using System;
using System.Collections.Generic;
using Insta.Project.LecteurRSS.Model;
using System.Text.RegularExpressions;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Delagate des evenements indiquant la suppression d'un element 
    ///   (repertoire, channel ou item)
    /// </summary>
    /// <param name="name"></param>
    public delegate void DeleteRequestDelegate(String name, String path);

    /// <summary>
    /// Cette classe represente un repertoire de l'annuaire des flux RSS.
    /// </summary>
    public class SyndicationFolder
    {
        #region -- CONSTANTES --

        /// <summary>
        /// Taille maximale du nom d'un dossier/channel
        /// </summary>
        private static int MAX_NAME_SIZE = 31;

        private static String PATTERN_NAME = @"^[\w\s]{3," + MAX_NAME_SIZE + "}$";

        private static Regex pattern = new Regex(PATTERN_NAME);

        #endregion

        #region -- Attribut --

        /// <summary>
        /// nom du repertoire
        /// </summary>
        private String _name;

        /// <summary>
        /// Indique si le repertoire est en cours de deplacement
        /// </summary>
        private bool _isMoved;

        /// <summary>
        /// Nouveau emplacement du repertoire
        /// </summary>
        private String _folderMovedTo;

        /// <summary>
        /// repertoire parent. null si le repertoire 
        ///     est l'element root.
        /// </summary>
        private SyndicationFolder _parent;

        /// <summary>
        /// Liste des channels (flux de syndication associé à un site 
        ///   web) associé à ce repertoire.
        /// </summary>
        private Dictionary<String, Channel> _channels;

        /// <summary>
        /// Liste des sous-repertoire associé à ce repertoire
        /// </summary>
        private List<SyndicationFolder> _subFolders;

        /// <summary>
        /// Table de map faisant correspond un lien d'un channel
        ///   vers le chemin du channel
        /// </summary>
        private static Dictionary<String, String> _mapLinkToPath = new Dictionary<string, string>();

        #endregion

        #region -- Event --

        public event DeleteRequestDelegate DeleteFolderRequest;

        #endregion

        #region -- Contructeur --

        /// <summary>
        /// Instancie un nouveau repertoire. L'instanciation d'un repertoire
        ///   doit obligatoirement spécifié son nom et le parent du repertoire.
        /// Seul le repertoire "root" a un parent egal à la valeur null
        /// </summary>
        /// <param name="folderName">nom du repertoire</param>
        /// <param name="parent">parent du repertoire</param>
        public SyndicationFolder(String folderName, SyndicationFolder parent)
        {
            _name = folderName;
            _parent = parent;
            _channels = new Dictionary<String, Channel>();
            _subFolders = new List<SyndicationFolder>();
        }

        #endregion

        #region -- Propriete --

        /// <summary>
        /// Le nom du dossier est en lecture seule. Pour modifier
        ///     le nom, utilisez la méthode Rename()
        /// </summary>
        public String Name { get { return _name; } }

        /// <summary>
        /// Le chemin du repertoire est en lecteur seule. pour modifier,
        ///     le chemin, utilisez la méthode Move()s
        /// </summary>
        public String Path
        {
            get { return ((IsRoot) ? "" : Parent.Path + "/" + _name); }
        }

        /// <summary>
        /// Retourne le repertoire parent de ce repertoire
        /// </summary>
        public SyndicationFolder Parent { get { return _parent; } }

        /// <summary>
        /// Retourne true si le repertoire est la racine de 
        ///  l'arbre des repertoire, false autrement
        /// </summary>
        public bool IsRoot
        {
            get { return ((Parent == null) ? true : false); }
        }

        /// <summary>
        /// Le repertoire est en cours de deplacement
        /// </summary>
        public bool IsMoved
        {
            get { return _isMoved; }
        }

        /// <summary>
        /// Nouveau emplacement du repertoire lors du 
        ///   de deplacement du repertoire.
        /// </summary>
        public String FolderMovedTo
        {
            get { return _folderMovedTo; }
        }

        /// <summary>
        /// Retourne une enumeration des sous-repertoires de
        ///   ce repertoire
        /// </summary>
        public IEnumerable<SyndicationFolder> SubFolders
        {
            get
            {
                if (_subFolders.Count != 0)
                {
                    foreach (SyndicationFolder folder in _subFolders)
                    {
                        yield return folder;
                    }
                }
            }
        }

        /// <summary>
        /// Retourne une enumeration des sous-repertoires de
        ///   ce repertoire.
        /// </summary>
        public IEnumerable<Channel> Channels
        {
            get
            {
                if (_channels.Count != 0)
                {
                    foreach (String key in _channels.Keys)
                    {
                        yield return _channels[key];
                    }
                }
            }
        }

        /// <summary>
        /// Retourne le nombre total d'articles associés à ce repertoire
        /// </summary>
        public int TotalItemCount
        {
            get
            {
                int totalItemCount = 0;

                foreach (String key in _channels.Keys)
                {
                    totalItemCount += _channels[key].ItemCount;
                }

                foreach (SyndicationFolder folder in SubFolders)
                {
                    totalItemCount += folder.TotalItemCount;
                }
                return totalItemCount;
            }
        }

        /// <summary>
        /// Retourne le nombre total d'articles non lus associés à ce repertoire
        /// </summary>
        public int TotalUnreadItemCount
        {
            get
            {
                int unreadItemCount = 0;

                foreach (String key in _channels.Keys)
                {
                    unreadItemCount += _channels[key].UnreadItemCount;
                }

                foreach (SyndicationFolder folder in SubFolders)
                {
                    unreadItemCount += folder.TotalUnreadItemCount;
                }

                return unreadItemCount;
            }
        }

        #endregion

        #region -- Methode sur la table de hachage "link" => "Path"

        /// <summary>
        /// Retourne le chemin d'accès de les channels
        ///   du model
        /// </summary>
        public static IEnumerable<String> GetChannelsPath
        {
            get
            {
                if (_mapLinkToPath.Count != 0)
                {
                    foreach (String key in _mapLinkToPath.Keys)
                    {
                        yield return _mapLinkToPath[key];
                    }
                }
            }
        }

        /// <summary>
        /// Determines si l'url correspond à un channel du model.
        /// </summary>
        /// <param name="url">url du channel</param>
        /// <returns>true si le channel existe, false autrement</returns>
        public static bool ExistsUrl(String url)
        {
            return _mapLinkToPath.ContainsKey(url);
        }

        /// <summary>
        /// Retourne le chemin d'accès d'un channel par son url. 
        /// </summary>
        /// <param name="url">url du channel</param>
        /// <returns>
        /// chemin d'accès du channel, null si l'url correspond à aucune channel.
        /// </returns>
        public static String GetChannelPathByUrl(String url)
        {
            if (_mapLinkToPath.ContainsKey(url))
            {
                return _mapLinkToPath[url];
            }
            return null;
        }

        #endregion

        #region -- Methode pour les Channel du repertoire --

        /// <summary>
        /// Creation d'un nouveau channel associé à ce repertoire.
        /// Si un channel dont le nom correspond à "name",
        ///   le channel ne sera pas crée.
        /// </summary>
        /// <param name="name">nom du channel</param>
        /// <param name="url">url du channel</param>
        public Channel CreateChannel(String name, String link)
        {
            // on verifie la taille du nom du channel
            if (name.Length > MAX_NAME_SIZE)
            {
                throw new IllegalNameException("Le nom du channel est limité à " + MAX_NAME_SIZE + " caractères.");
            }
            // on verifie que le nom du channel ne possede pas de caracteres interdits
            else if (!pattern.IsMatch(name))
            {
                throw new IllegalNameException("Le nom du channel est limité aux lettres, aux chiffres et aux espaces.");
            }
            // on verifie que le channel n'existe pas dans ce repertoire
            else if (ExistsChannel(name))
            {
                throw new ChannelAlreadyCreatedException("Le channel " + name + " existe déjà dans le repertoire \"" + Path + "\".");
            }

            // creation du channel
            Channel channel = new Channel(name, link, this);

            // on ecoute l'evenement
            channel.DeleteChannelRequest += new DeleteRequestDelegate(OnDeleteChannelRequest);

            // ajout du channel
            _channels.Add(name, channel);
            _mapLinkToPath.Add(channel.Link, channel.Path);

            return channel;
        }

        /// <summary>
        /// Retourne le channel associé à ce repertoire dont le nom
        ///    est specifié en argument
        /// </summary>
        /// <param name="name">nom du channel à rechercher</param>
        /// <returns>channel recherché</returns>
        public Channel GetChannel(String name)
        {
            try
            {
                return _channels[name];
            }
            catch (KeyNotFoundException)
            {
                throw new ChannelNotFoundException("Le chemin spécifié pour ce channel n'existe pas");
            }
        }

        /// <summary>
        /// Verifie si le channel de nom "name" est un channel
        ///  (flux de syndication) de ce repertoire.
        /// </summary>
        /// <param name="name">nom du channel à rechercher</param>
        /// <returns>true si le channel existe, false autrement</returns>
        public bool ExistsChannel(String name)
        {
            if (_channels.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Evenement declenché lorsque un channel souhaite etre supprimés
        /// </summary>
        /// <param name="name">nom du channel à supprimer</param>
        void OnDeleteChannelRequest(string name, string parentPath)
        {
            if (Path == parentPath)
            {
                // update la table de hachage "link" => "path"
                _mapLinkToPath.Remove(GetChannel(name).Link);

                // supprime le channel
                _channels.Remove(name);
            }
        }

        /// <summary>
        /// Deplace le channel spécifié en parametre
        ///  dans ce repertoire
        /// </summary>
        /// <param name="channel">
        /// channel à deplacer dans le repertoire
        /// </param>
        public void Move(Channel channel)
        {
            if ((channel.IsMoved) && (channel.FolderMovedTo == Path))
            {
                if (ExistsChannel(channel.Name))
                {
                    throw new FolderAlreadyCreatedException("Un channel avec le meme nom existe dans ce repertoire");
                }

                // ajoute le channel
                _channels.Add(channel.Name, channel);
                channel.DeleteChannelRequest += new DeleteRequestDelegate(OnDeleteChannelRequest);

                // update la table de hachage "link" => "path"
                _mapLinkToPath.Remove(channel.Link);
                _mapLinkToPath.Add(channel.Link, channel.Path);
            }
        }

        #endregion

        #region -- Methode pour les sous-repertoires du repertoire --

        /// <summary>
        /// Retourne le repertoire racine (root) de l'arbre
        ///     des repertoires
        /// </summary>
        /// <returns>racine de l'arbre des repertoires</returns>
        private SyndicationFolder GetFolderRoot()
        {
            SyndicationFolder folderRoot = this;

            while (!folderRoot.IsRoot)
            {
                folderRoot = folderRoot.Parent;
            }

            return folderRoot;
        }

        /// <summary>
        /// Creation d'un nouveau sous-repertoire associé à ce repertoire.
        /// Si un sous-repertoire dont le nom correspond à "folderName",
        ///   le sous-repertoire ne sera pas crée.
        /// </summary>
        /// <param name="folderName">nom du sous-repertoire à créer</param>
        public SyndicationFolder CreateSubFolder(String folderName)
        {
            // on verifie la taille du nom du repertoire
            if (folderName.Length > MAX_NAME_SIZE)
            {
                throw new IllegalNameException("Le nom du répertoire est limité à " + MAX_NAME_SIZE + " caracteres.");
            }
            // on verifie que le nom du repertoire ne possede pas de caracteres interdits
            else if (!pattern.IsMatch(folderName))
            {
                throw new IllegalNameException("Le nom du répertoire est limité aux lettres, aux chiffres et aux espaces.");
            }
            // on verifie que ce sous-repertoire n'existe pas
            else if (ExistsSubFolder(folderName))
            {
                throw new FolderAlreadyCreatedException("Le repertoire \"" + folderName + "\" existe déjà dans le repertoire \"" + Path + "\".");
            }

            // creation du nouveau repertoire
            SyndicationFolder subFolder = new SyndicationFolder(folderName, this);

            // ecoute de l'evenement DeleteFolderRequest
            subFolder.DeleteFolderRequest += new DeleteRequestDelegate(OnDeleteFolderRequest);

            // on ajoute le sous-repertoire à ce repertoire
            _subFolders.Add(subFolder);

            return subFolder;
        }

        /// <summary>
        /// Verifie si le repertoire "folderName" en argument est
        ///   un sous-repertoire de ce repertoire
        /// </summary>
        /// <param name="folderName">nom du repertoire à rechercher</param>
        /// <returns>true si "folderName" est un sous-repertoire, false autrement</returns>
        public bool ExistsSubFolder(String folderName)
        {
            // DECLARATION & INITIALISATION
            bool existsSubFolder = false;

            foreach (SyndicationFolder folder in _subFolders)
            {
                if (folder.Name.Equals(folderName))
                {
                    existsSubFolder = true;
                    break;
                }
            }

            return existsSubFolder;
        }

        /// <summary>
        /// Retourne le sous-repertoire dont le nom correspond au nom du souss-repertoire
        ///  spécifié en argument.
        /// </summary>
        /// <param name="nameFolder">nom du sous-repertoire à rechercher</param>
        /// <returns>sous-repertoire dont le nom correspond "nameFolder",
        ///     null si le sous-repertoire n'existe pas.</returns>
        public SyndicationFolder GetSubFolder(String nameFolder)
        {
            // Tant que tous les sous-repertoires ne sont pas analysés, Faire:
            //  - on verifie que le nom du sous-repertoire courant est egal
            //      au nom du sous-repertoire spécifié en argument.
            //  - si le sous-repertoire est trouvé, on retourne le sous-repertoire
            foreach (SyndicationFolder folder in _subFolders)
            {
                if (folder.Name.Equals(nameFolder))
                {
                    return folder;
                }
            }

            throw new FolderNotFoundException("Le repertoire \"" + Path + "/" + nameFolder + "\" n'existe pas.");
        }

        /// <summary>
        /// Deplace le repertoire spécifié en parametre
        ///  dans ce repertoire
        /// </summary>
        /// <param name="folder">
        /// repertoire à deplacer dans ce repertoire
        /// </param>
        public void Move(SyndicationFolder folder)
        {
            if ((folder.IsMoved) && (folder.FolderMovedTo == Path))
            {
                if (ExistsSubFolder(folder.Name))
                {
                    throw new FolderAlreadyCreatedException("Un repertoire avec le meme nom existe dans ce repertoire");
                }

                _subFolders.Add(folder);
                folder.DeleteFolderRequest += new DeleteRequestDelegate(OnDeleteFolderRequest);
            }
        }

        /// <summary>
        /// Evenement declenché lorsque un repertoire souhaite etre supprimé
        /// </summary>
        /// <param name="folder">nom du repertoire à supprimer</param>
        void OnDeleteFolderRequest(String folderName, String parentPath)
        {
            // INIT
            SyndicationFolder folder = null;

            if (parentPath == Path)
            {
                folder = GetSubFolder(folderName);
                folder.DeleteFolderRequest -= new DeleteRequestDelegate(OnDeleteFolderRequest);

                _subFolders.Remove(GetSubFolder(folderName));
            }
        }

        #endregion

        #region -- Methode du repertoire --

        /// <summary>
        /// Marque les articles (actualité) de tous les channels
        ///   associés à ce repertoire et de tous les channels 
        ///   associés à ces sous-repertoires comme lus.
        /// </summary>
        public void MarkAllItemsRead()
        {
            // Marque les articles de tous les channels associés
            //  à ce repertoire comme lus.
            foreach (String key in _channels.Keys)
            {
                _channels[key].MarkAllItemsRead();
            }

            // Marque les articles de tous les channels associés
            //  à ces sous-repertoires comme lus.
            foreach (SyndicationFolder folder in _subFolders)
            {
                folder.MarkAllItemsRead();
            }
        }

        /*
        /// <summary>
        /// Modifie le nom du repertoire.
        /// </summary>
        /// <param name="folderName">nouveau du nom du repertoire</param>
        public void Rename(String folderName)
        {
            _name = folderName;
        }
        */

        /// <summary>
        /// Supprime le repertoire, les channels et les sous-repertoires
        ///     associés à ce channel
        /// </summary>
        public void Delete()
        {
            // supprime les repertoires et les channels
            //   associés à ce repertoire
            _subFolders.Clear();
            _channels.Clear();

            // --------------------------------------------
            // update la table de hashage "link" => "path"
            // --------------------------------------------
            List<String> keys = new List<string>();
            foreach (String key in _mapLinkToPath.Keys)
            {
                if (_mapLinkToPath[key].Contains(Path))
                {
                    keys.Add(key);
                }
            }

            for (int i = 0; i < keys.Count; i++)
            {
                _mapLinkToPath.Remove(keys[i]);
            }

            // event indiquant la supression du repertoire
            if (DeleteFolderRequest != null)
            {
                DeleteFolderRequest(Name, Parent.Path);
            }
        }

        /// <summary>
        /// Deplace le repertoire dans le chemin "newParentPath" indiqué
        ///     en arguments.
        /// </summary>
        /// <param name="newParentPath"></param>
        public void Move(String newParentPath)
        {
            // verifie que le repertoire de destination 
            //  n'est pas un sous-repertoire de ce repertoire.
            if (newParentPath.Contains(Path))
            {
                throw new FolderMovedException("Impossible de deplacer le repertoire \"" + Path + "\" dans le sous-repertoire \"" + newParentPath + "\"");
            }

            // INITIALISATION 
            SyndicationFolder newParent = null;
            String oldPath = null;
            String[] _folders = newParentPath.Split('/');
            List<String> keys = new List<string>();

            try
            {
                // on change l'etat du repertoire
                _isMoved = true;

                // recupere la racine de l'arbre des repertoires
                newParent = GetFolderRoot();

                // on recherche le repertoire associé à ce chemin
                for (int i = 1; i < _folders.Length; i++)
                {
                    newParent = newParent.GetSubFolder(_folders[i]);
                }

                // on indique le repertoire de destination
                _folderMovedTo = newParent.Path;

                // on deplace le repertoire
                newParent.Move(this);
                if (DeleteFolderRequest != null)
                {
                    DeleteFolderRequest(Name, _parent.Path);
                }
                oldPath = Path;
                _parent = newParent;

                // --------------------------------------------
                // update la table de hashage "link" => "path"
                // --------------------------------------------
                foreach (String key in _mapLinkToPath.Keys)
                {
                    if (_mapLinkToPath[key].Contains(oldPath))
                    {
                        keys.Add(key);
                    }
                }

                for (int i = 0; i < keys.Count; i++)
                {
                    _mapLinkToPath[keys[i]] = _mapLinkToPath[keys[i]].Replace(oldPath, Path);
                }
            }
            catch (FolderNotFoundException exception1)
            {
                _isMoved = false;
                _folderMovedTo = "";
                throw new FolderMovedException(exception1.Message);
            }
            catch (FolderAlreadyCreatedException exception2)
            {
                _isMoved = false;
                _folderMovedTo = "";
                throw new FolderMovedException(exception2.Message);
            }

            _isMoved = false;
            _folderMovedTo = "";
        }

        /// <summary>
        /// Retourne sous une forme contextuelle (String)
        ///   le repertoire.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            // nom du repertoire
            str.Append("Name: " + Name);

            // chemin d'acces du repertoire
            str.Append("\nPath: " + Path);

            // nom du repertoire parent
            str.Append("\nParent: " + ((IsRoot) ? "root" : Parent.Name));

            // statistiques
            str.Append("\nStats: ");
            str.Append("\nSubFolders=" + _subFolders.Count);
            str.Append("\nChannels=" + _channels.Count);
            str.Append("\nTotalItems=" + TotalItemCount + "/" + TotalUnreadItemCount);

            return str.ToString();
        }

        #endregion
    }
}
