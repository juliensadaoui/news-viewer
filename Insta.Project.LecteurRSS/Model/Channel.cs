using System;
using System.Collections.Generic;
using System.Xml;
using Insta.Project.LecteurRSS.SyndicationParser;
using System.Threading;
using Insta.Project.LecteurRSS.Model;
using System.Text;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Cette classe represente un canal de l'annuaire de flux RSS. 
    ///     Ce canal peut-etre un flux RSS ou un flux ATOM
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// Verrou pour les sections critiques de la classe.
        ///  Ce verrou est utilisé pour le multi-threading.
        /// </summary>
        private readonly Object _locker = new Object();

        #region -- Attribut --

        /// <summary>
        /// Nom du channel
        /// </summary>
        private String _name;

        /// <summary>
        /// Format du flux de syndication utilisé par le channel
        /// </summary>
        private String _format;

        /// <summary>
        /// Titre du channel
        /// </summary>
        private String _title;

        /// <summary>
        /// Url du site web contenant le channel
        /// </summary>
        private String _link;

        /// <summary>
        /// Description du channel
        /// </summary>
        private String _description;

        /// <summary>
        /// Langage dans lequel est decrit le contenu
        /// </summary>
        private String _language;

        /// <summary>
        /// Notice de copyright pour le contenu du canal.
        /// </summary>
        private String _copyright;

        /// <summary>
        /// adresse mail du responsable du contenu editorial
        /// </summary>
        private String _managingEditor;

        /// <summary>
        /// adresse mail du responsable du site web contenant le canal
        /// </summary>
        private String _webMaster;

        /// <summary>
        /// date de publication du contenu du canal
        /// </summary>
        private String _pubDate;

        /// <summary>
        /// La dernière date où le contenu du canal a changé.  	Sat, 07 Sep 2002 09:42:31 GMT
        /// </summary>
        private String _lastBuildDate;

        /// <summary>
        /// Spécifie une catégorie ou plusieurs auxquelles correspond le canal. 
        /// </summary>
        private List<String> _categories;

        /// <summary>
        /// Une chaîne indiquant le programme utilisé pour générer le canal. 
        /// </summary>
        private String _generator;

        /// <summary>
        /// Une URL pointant sur la documentation du format utilisé pour le fichier RSS
        /// </summary>
        private String _docs;

        /// <summary>
        /// ttl représente la durée de vie. C'est un nombre de minutes qui indique combien de temps un canal peut être gardé en mémoire cache avant rafraîchissement à la source
        /// </summary>
        private String _ttl;

        //textInput 	Spécifie une champ d'entrée de texte qui ne peut pas être affiché avec le canal. 

        /// <summary>
        /// La côte PICS pour le canal. 
        /// </summary>
        private String _rating;

        /// <summary>
        /// Un indice pour les aggrégateurs leur indiquant combien d'heures peuvent être sautées.
        /// </summary>
        private int _skipHours;

        /// <summary>
        /// Un indice pour les aggrégateurs leur indiquant combien de jours peuvent être sautés. 
        /// </summary>
        private String _skipDays;

        /// <summary>
        /// Service web associé au channel
        /// </summary>
        private Cloud _cloud;

        /// <summary>
        /// Image associé au channel
        /// </summary>
        private Image _image;

        /// <summary>
        /// Repertoire parent associé à ce channel (flux de syndication)
        /// </summary>
        private SyndicationFolder _parent;

        /// <summary>
        /// Liste des articles associé au channel
        /// </summary>
        private Dictionary<String, Item> _items;

        /// <summary>
        /// Nombre d'articles (item) non lus du channel
        /// </summary>
        private int _unreadItemCount;

        /// <summary>
        /// Etat du dernier chargement du channel
        /// </summary>
        private SyndicationLoadState _loadState;

        /// <summary>
        /// message d'erreur correspondant 
        /// au dernier chargement du channel
        /// </summary>
        private String _loadError;

        /// <summary>
        /// Tâche en arriere plan
        /// </summary>
        private Thread _backgroundTask;

        /// <summary>
        /// Indique si le channel est en cours de deplacement
        /// </summary>
        private bool _isMoved;

        /// <summary>
        /// Nouveau emplacement du channel au cours de son deplacement
        /// </summary>
        private string _folderMovedTo;

        #endregion

        #region -- Event --

        /// <summary>
        /// Evenement declenché lorsque le channel est supprimé
        /// </summary>
        public event DeleteRequestDelegate DeleteChannelRequest;

        #endregion

        #region -- Constructeur --

        /// <summary>
        /// Nécessaire pour la serialisation Xml
        /// </summary>
        public Channel()
        { }



        /// <summary>
        /// Instancie un nouveau channel de flux RSS
        /// </summary>
        /// <param name="name">titre ou nom du channel</param>
        /// <param name="link">url du site web contenant le channel</param>
        /// <param name="channel"></param>
        public Channel(String name, String link, SyndicationFolder parent)
        {
            _name = name;
            _link = link;
            _parent = parent;

            _categories = new List<string>();
            _items = new Dictionary<String, Item>();
            _backgroundTask = new Thread(new ThreadStart(Load));
        }

        #endregion

        #region -- Propriete --

        /// <summary>
        /// Retourne le nom du channel
        /// </summary>
        public String Name { get { return _name; } }

        /// <summary>
        /// Retourne le chemin du channel dans l'arbre des repertoires
        /// </summary>
        public String Path { get { return Parent.Path + "/" + _name; } }

        /// <summary>
        /// Retourne le repertoire associé à ce channel
        /// </summary>
        public SyndicationFolder Parent { get { return _parent; } }

        /// <summary>
        /// Retourne le format du flux de syndication utilisée
        /// </summary>
        public String Format { get { return _format; } }

        /// <summary>
        /// Retourne le titre du channel
        /// </summary>
        public String Title { get { return _title; } }

        /// <summary>
        /// Retourne l'Url du site web contenant le channel
        /// </summary>
        public String Link { get { return _link; } }

        /// <summary>
        /// Retourne une description du channel
        /// </summary>
        public String Description { get { return _description; } }

        /// <summary>
        /// Retourne la langue utilisée pour ce channel
        /// </summary>
        public String Language { get { return _language; } }

        /// <summary>
        /// Retourne la notice de copyright pour le contenu du canal.
        /// </summary>
        public String Copyright { get { return _copyright; } }

        /// <summary>
        /// Retourne l'adresse mail du responsable du contenu editorial
        /// </summary>
        public String ManagingEditor { get { return _managingEditor; } }

        /// <summary>
        /// Retourne l'adresse mail du responsable du site web contenant le canal
        /// </summary>
        public String WebMaster { get { return _webMaster; } }

        /// <summary>
        /// Retourne la date de publication du channel
        /// </summary>
        public String PubDate { get { return _pubDate; } }

        /// <summary>
        /// Retourne la derniere date de modification du channel
        /// </summary>
        public String LastBuildDate { get { return _lastBuildDate; } }

        /// <summary>
        /// Retourne une enumeration de la liste des
        ///     categories associées à ce channel
        /// </summary>
        public IEnumerable<String> Categories
        {
            get
            {
                if (_categories.Count != 0)
                {
                    foreach (String category in _categories)
                    {
                        yield return category;
                    }
                }
            }
        }

        /// <summary>
        /// Retourne l'application qui a genere le flux de syndication
        ///     associé au channel
        /// </summary>
        public String Generator { get { return _generator; } }

        /// <summary>
        /// Retourne URL pointant sur la documentation du format
        ///     utilisé pour ce flux
        /// </summary>
        public String Docs { get { return _docs; } }

        /// <summary>
        /// Retourne la duree de vie du channel
        /// </summary>
        public String Ttl { get { return _ttl; } }

        /// <summary>
        /// La côte PICS pour le canal. 
        /// </summary>
        public String Rating { get { return _rating; } }

        /// <summary>
        /// Retourne l'indice pour les aggrégateurs leur indiquant
        ///   combien d'heures peuvent être sautées.
        /// </summary>
        public int SkipHours { get { return _skipHours; } }

        /// <summary>
        /// Retourne l'indice pour les aggrégateurs leur indiquant
        ///   combien de jours peuvent être sautés. 
        /// </summary>
        public String SkipDays { get { return _skipDays; } }

        /// <summary>
        /// Retourne l'image associée à ce channel
        /// </summary>
        public Image Image { get { return _image; } }

        /// <summary>
        /// Retourne le Service web associé au channel
        /// </summary>
        public Cloud Cloud { get { return _cloud; } }

        /// <summary>
        /// Retourne le nombre d'articles associés au channel
        /// </summary>
        public int ItemCount { get { return _items.Count; } }

        /// <summary>
        /// Retourne une enumeration de la liste des articles
        ///   associés au channel
        /// </summary>
        public IEnumerable<Item> Items
        {
            get
            {
                if (_items.Count != 0)
                {
                    foreach (String key in _items.Keys)
                    {
                        yield return _items[key];
                    }
                }
            }
        }

        /// <summary>
        /// Retourne l'etat correspondant au dernier
        ///   chargement du channel.
        /// </summary>
        public SyndicationLoadState LoadState { get { return _loadState; } }

        /// <summary>
        /// Retourne le message d'erreur correspondant
        ///  au dernier chargement du channel.
        /// </summary>
        public String LoadError { get { return _loadError; } }

        /// <summary>
        /// Retourne le nombre d'article non lu du channel
        /// </summary>
        public int UnreadItemCount { get { return _unreadItemCount; } }

        /// <summary>
        /// Retourne true si le channel est en cours de deplacement
        /// </summary>
        public bool IsMoved { get { return _isMoved; } }

        /// <summary>
        /// Retourne le nouveau emplacement du channel
        ///   au cours de son deplacement.
        /// </summary>
        public String FolderMovedTo { get { return _folderMovedTo; } }

        #endregion

        #region -- Methode --

        /// <summary>
        ///  Ajoute un nouveau article (une actualité) au channel
        /// </summary>
        /// <param name="item">nouveau article</param>
        public void AddItem(Item item)
        {
            _items.Add(item.Guid, item);
        }

        /// <summary>
        /// Retourne un article du channel correspondant à l'identifiant
        ///     spécifié en argument.
        /// </summary>
        /// <param name="title">titre de l'article à rechercher</param>
        /// <returns>identifiant de l'article, null si l'article n'existe pas</returns>
        public Item GetItem(String guid)
        {
            try
            {
                return _items[guid];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        /// Configure tous les articles du channel comme lu
        /// </summary>
        public void MarkAllItemsRead()
        {
            foreach (String key in _items.Keys)
            {
                if (!_items[key].IsRead)
                    _items[key].IsRead = true;
            }
        }

        /// <summary>
        /// Retourne le repertoire racine (root) de l'arbre
        ///     des repertoires
        /// </summary>
        /// <returns>racine de l'arbre des repertoires</returns>
        private SyndicationFolder GetFolderRoot()
        {
            SyndicationFolder folderRoot = Parent;

            while (!folderRoot.IsRoot)
            {
                folderRoot = folderRoot.Parent;
            }

            return folderRoot;
        }

        /// <summary>
        /// Charge le contenu d'un flux de syndication
        ///   dans un autre thread (en arriere plan
        /// </summary>
        public void LoadAsync()
        {
            if (!_backgroundTask.IsAlive)
            {
                _backgroundTask.Start();
            }
        }

        /// <summary>
        /// Charge le contenu d'un flux de syndication
        /// </summary>
        public void Load()
        {
            bool load = true;

            switch (_loadState)
            {
                case SyndicationLoadState.LOADING:
                    load = false;
                    break;
            }

            // on charge le contenu du channel seulement si il n'y a
            //      pas de chargement en cours
            if (load)
            {
                _loadState = SyndicationLoadState.LOADING;

                // DECLARATION
                XmlDocument xmlDocument;
                AbstractSyndicationParser parser;

                // INITIALISATION
                xmlDocument = null;
                parser = null;

                try
                {
                    // creation d'un nouveau document XML
                    xmlDocument = new XmlDocument();

                    // ne prend pas en compte les proxy
                    // ne prend pas en compte les connexions securisees (ssl)
                    xmlDocument.Load(Link);

                    parser = SyndicationFactory.GetParser(xmlDocument, this);

                    // analyse le message XML du contenu du flux
                    parser.Parse();

                    // met à jour le channel
                    Update(parser);

                    _loadState = SyndicationLoadState.LOADED;

                }
                catch (Exception e)
                {
                    _loadState = SyndicationLoadState.LOAD_FAILED;
                    _loadError = e.Message;
                }
            }
        }

        /// <summary>
        /// Mise a jour de l'ensemble des données (informations)
        ///  du channel. Seuls les nouveaux articles du channel 
        ///  sont prises en compte.
        /// </summary>
        /// <param name="channel"></param>
        private void Update(AbstractSyndicationParser parser)
        {
            // on pose un verrou lorsqu'on modifie les données
            lock (_locker)
            {
                // update le titre du channel
                if (parser.Title != null)
                {
                    _title = parser.Title;
                }

                // update le format du channel
                if (parser.Format != null)
                {
                    _format = parser.Format;
                }

                // update la description du channel
                if (parser.Description != null)
                {
                    _description = parser.Description;
                }

                // update la langue utilisé du channel
                if (parser.Language != null)
                {
                    _language = parser.Language;
                }

                // update la Notice de copyright
                if (parser.Copyright != null)
                {
                    _copyright = parser.Copyright;
                }

                // update l'adresse email du responsable du contenu
                if (parser.ManagingEditor != null)
                {
                    _managingEditor = parser.ManagingEditor;
                }

                // update l'adresse mail du responsable du site web
                if (parser.WebMaster != null)
                {
                    _webMaster = parser.WebMaster;
                }

                // update la date de publication
                if (parser.PubDate != null)
                {
                    _pubDate = parser.PubDate;
                }

                // update la date ou le channel a change
                if (parser.LastBuildDate != null)
                {
                    _lastBuildDate = parser.LastBuildDate;
                }

                // update la liste categorie
                if (parser.Categories != null)
                {
                    _categories = parser.Categories;
                }

                // update le nom du logiciel qui genere le flux du channel
                if (parser.Generator != null)
                {
                    _generator = parser.Generator;
                }

                // update l'url pointant vers la documentation du format du flux
                if (parser.Docs != null)
                {
                    _docs = parser.Docs;
                }

                // update la duree de vie du channel
                if (parser.Ttl != null)
                {
                    _ttl = parser.Ttl;
                }

                // update la côte du channel
                if (parser.Rating != null)
                {
                    _rating = parser.Rating;
                }

                // update l'indice
                if (parser.SkipDays != null)
                {
                    _skipDays = parser.SkipDays;
                }

                // update l'indice
                if (parser.SkipHours != 0)
                {
                    _skipHours = parser.SkipHours;
                }

                // update l'image associé au channel
                if (parser.Image != null)
                {
                    _image = parser.Image;
                }

                // update le service web
                if (parser.Cloud != null)
                {
                    _cloud = parser.Cloud;
                }

                // ----------------------------------------
                //  Update la liste des articles
                // ----------------------------------------
                if (parser.Items != null)
                {
                    Item item = null;

                    // ajoute seulement les articles que ne possede
                    //   pas le channel
                    foreach (String key in parser.Items.Keys)
                    {
                        if (!_items.ContainsKey(key))
                        {
                            item = parser.Items[key];
                            AddItem(item);
                            item.DeleteItemRequest += new DeleteRequestDelegate(OnDeleteItemRequest);
                            item.ItemReadChanged += new ItemReadChangedDelegate(OnItemReadChanged);
                            _unreadItemCount++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Methode de l'evenement indiquant la supression d'un item
        /// </summary>
        /// <param name="name">cle de l'item</param>
        void OnDeleteItemRequest(string key, String parentPath)
        {
            // pose une verrou
            lock (_locker)
            {
                if (Path == parentPath)
                {
                    if (!_items[key].IsRead)
                    {
                        _unreadItemCount--;
                    }
                    _items.Remove(key);
                }
            }
        }

        /// <summary>
        /// Methode de l'evenement indiquant que un article (item)
        ///  est marqué comme lu
        /// </summary>
        void OnItemReadChanged()
        {
            lock (_locker)
            {
                _unreadItemCount--;
            }
        }

        /// <summary>
        /// Supprime le channel et tous les articles associés
        /// </summary>
        public void Delete()
        {
            // on pose un verrou
            lock (_locker)
            {
                _image = null;
                _items.Clear();
                _categories.Clear();

                if (DeleteChannelRequest != null)
                {
                    DeleteChannelRequest(Name, Parent.Path);
                }
            }
        }

        /// <summary>
        /// Deplace le channel dans un nouveau repertoire
        /// </summary>
        public void Move(String newParentPath)
        {
            // INITIALISATION
            SyndicationFolder newParent;
            String[] _folders;

            // on pose un verrou
            lock (_locker)
            {
                try
                {
                    // on change l'etat du repertoire
                    _isMoved = true;

                    _folders = newParentPath.Split('/');

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
                    if (DeleteChannelRequest != null)
                    {
                        DeleteChannelRequest(Name, Parent.Path);
                    }
                    _parent = newParent;
                }
                catch (FolderNotFoundException exception1)
                {
                    _isMoved = false;
                    _folderMovedTo = "";
                    throw new ChannelMovedException(exception1.Message);
                }
                catch (ChannelAlreadyCreatedException exception2)
                {
                    _isMoved = false;
                    _folderMovedTo = "";
                    throw new ChannelMovedException(exception2.Message);
                }

                _isMoved = false;
                _folderMovedTo = "";
            }
        }

        #endregion

        #region -- Methode ToString --

        /// <summary>
        /// Retourne la forme textuelle de l'objet
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder str = new StringBuilder();

            // format
            str.Append("Format: ");
            if (Format != null)
            {
                str.Append(Format);
            }
            else
            {
                str.Append("<empty>");
            }

            // titre
            str.Append("\nTitle: ");
            if (Title != null)
            {
                str.Append(Title);
            }
            else
            {
                str.Append("<empty>");
            }

            // url du site web 
            str.Append("\nLink: ");
            if (Link != null)
            {
                str.Append(Link);
            }
            else
            {
                str.Append("<empty>");
            }

            // description
            str.Append("\nDescription: ");
            if (Description != null)
            {
                str.Append(Description);
            }
            else
            {
                str.Append("<empty>");
            }

            // langage du channel
            str.Append("\nLanguage: ");
            if (Language != null)
            {
                str.Append(Language);
            }
            else
            {
                str.Append("<empty>");
            }

            // droit de intellectuel
            str.Append("\nCopyright: ");
            if (Copyright != null)
            {
                str.Append(Copyright);
            }
            else
            {
                str.Append("<empty>");
            }

            // date de publication
            str.Append("\nPubDate: ");
            if (PubDate != null)
            {
                str.Append(PubDate);
            }
            else
            {
                str.Append("<empty>");
            }

            // responsable du contenu du site web associé au channel
            str.Append("\nManagingEditor: ");
            if (ManagingEditor != null)
            {
                str.Append(ManagingEditor);
            }
            else
            {
                str.Append("<empty>");
            }

            // responsable du site web associé au channel
            str.Append("\nWebMaster: ");
            if (ManagingEditor != null)
            {
                str.Append(ManagingEditor);
            }
            else
            {
                str.Append("<empty>");
            }

            // logiciel qui genere le flux de syndication
            str.Append("\nGenerator: ");
            if (Generator != null)
            {
                str.Append(Generator);
            }
            else
            {
                str.Append("<empty>");
            }

            // lien vers la documentation sur le format
            str.Append("\nDoc: ");
            if (Docs != null)
            {
                str.Append(Docs);
            }
            else
            {
                str.Append("<empty>");
            }

            // Category
            str.Append("\nCategory: ");
            if (_categories.Count != 0)
            {
                foreach (String category in _categories)
                {
                    str.Append(category + " ");
                }
            }
            else
            {
                str.Append("<empty>");
            }

            // duree de vie
            str.Append("\nTtl: ");
            if (Ttl != null)
            {
                str.Append(Ttl);
            }
            else
            {
                str.Append("<empty>");
            }

            str.Append("\nSkipDay: ");
            if (SkipDays != null)
            {
                str.Append(SkipDays);
            }
            else
            {
                str.Append("<empty>");
            }

            str.Append("\nSkipHours: ");
            if (SkipHours != 0)
            {
                str.Append("" + SkipHours);
            }
            else
            {
                str.Append("<empty>");
            }

            // cote
            str.Append("\nRating: ");
            if (Rating != null)
            {
                str.Append(Rating);
            }
            else
            {
                str.Append("<empty>");
            }

            if (Image != null)
            {
                str.Append("\nImage: " + Image.toString());
            }

            if (Cloud != null)
            {
                str.Append("\nCloud: " + Cloud.toSring());
            }

            // on affiche tous les articles
            str.Append("\nItems ");
            str.Append("(");
            str.Append(ItemCount);
            str.Append("/");
            str.Append(UnreadItemCount);
            str.Append("): ");
            if (_items.Count != 0)
            {
                int i = 0;
                foreach (String key in _items.Keys)
                {
                    str.Append("\nitem: " + ++i);
                    str.Append(_items[key].ToString());
                }
            }
            else
            {
                str.Append("<empty>");
            }

            return str.ToString();
        }

        #endregion
    }
}
