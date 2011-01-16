using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insta.Project.LecteurRSS.Model;
using System.Xml;
using System.IO;

namespace Insta.Project.LecteurRSS.Model
{
    /// <summary>
    /// Coeur applicatif : Gestionnaire de l'annuaire des flux RSS
    /// </summary>
    public class SyndicationManager
    {
        /// <summary>
        /// instance unique
        /// </summary>
        private static SyndicationManager _instance = null;

        /// <summary>
        /// racine des repertoires 
        /// </summary>
        private SyndicationFolder _root;

        #region Constructeur

        /// <summary>
        /// Instancie un nouveau gestionnaire de syndication
        /// </summary>
        public SyndicationManager()
        {
            _root = new SyndicationFolder("root", null);
        }

        #endregion

        #region Propriete

        public SyndicationFolder Root
        {
            get { return _root; }
            set { _root = value; }
        }

        #endregion

        #region -- Methode de l'instance --

        /// <summary>
        /// Retourne l'instance unique de la classe SyndicationManager.
        /// </summary>
        /// <returns></returns>
        public static SyndicationManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new SyndicationManager();
            }
            return _instance;
        }

        #endregion

        #region -- Methode pour la gestion des repertoires --

        /// <summary>
        /// Retourne le repertoire correspond au chemin spécifie 
        ///     en parametre
        /// </summary>
        /// <param name="folderPath">chemin du repertoire</param>
        /// <returns>repertoire à rechercher</returns>
        public SyndicationFolder GetFolder(String folderPath)
        {
            if (folderPath == null) {
                throw new FolderNotFoundException("Le repertoire n'existe pas.");
            }

            // DECLARATION & INITIALISATION
            SyndicationFolder folder = null;
            
            // on recupere chacun des noms des repertoires
            //    dans un tableau
            String[] foldersName = folderPath.Split('/');

            // on recupere la racine de l'arbre des repertoires
            folder = Root;

            for (int i = 1 ; i < foldersName.Length ; i++)
            {
                folder = folder.GetSubFolder(foldersName[i]);
            }

            return folder;
        }

        /// <summary>
        /// Verifie l'existance du repertoire au chemin spécifié en argument
        /// </summary>
        /// <param name="folderPath">chemin du repertoir à verifier</param>
        /// <returns>true si le repertoire existe, false autrement</returns>
        public bool ExistsFolder(String folderPath)
        {
            try {
                GetFolder(folderPath);
                return true;
            }
            catch (FolderNotFoundException) {
                return false;
            }
        }

        /// <summary>
        /// Supprime le repertoire correspondant au chemin specifie en parametre.
        /// </summary>
        /// <param name="folderPath">chemin du repertoire à supprimer</param>
        public void DeleteFolder(String folderPath)
        {
            // DECLARATION & INITIALISATION
            SyndicationFolder folder = null;

            // recupere le repertoire à supprimer
            folder = GetFolder(folderPath);

            // supprime le repertoire
            folder.Delete();
        }

        #endregion

        #region -- Methode pour la gestion des channel --

        /// <summary>
        ///  Retourne le channel correspond au chemin spécifié en parametre
        /// </summary>
        /// <param name="channelPath">chemin du channel</param>
        /// <returns></returns>
        public Channel GetChannel(String channelPath)
        {
            if (channelPath == null) {
                throw new ChannelNotFoundException("Le chemin du channel est introuvable");
            }

            // DECLARATION & INITIALISATION
            SyndicationFolder folder = null;
            Channel channel = null;
            int channelIndex;

            // on recupere chacun des noms des repertoires
            //    dans un tableau
            String[] foldersName = channelPath.Split('/');
            channelIndex = (foldersName.Length - 1);

            // on recupere la racine de l'arbre des repertoires
            folder = Root;

            for (int i = 1; i < channelIndex ; i++)
            {
                try {
                    folder = folder.GetSubFolder(foldersName[i]);
                }
                catch (FolderNotFoundException) {
                    throw new ChannelNotFoundException("Le chemin du channel est introuvable");
                }
            }

            // Fix NullPointerException
            //   cause => analyse le dossier avant le channel
            if (folder != null) { 
                String channelName = foldersName[channelIndex];
                channel = folder.GetChannel(channelName);
            }

            return channel;
        }

        /// <summary>
        /// Verifie l'existance du channel au chemin spécifié en argument
        /// </summary>
        /// <param name="channelPath">chemin du channel à rechercher</param>
        /// <returns>true si le channel existe, false autrement</returns>
        public bool ExistsChannel(String channelPath)
        {
            try {
                GetChannel(channelPath);
                return true;
            }
            catch (ChannelNotFoundException) {
                return false;
            }
        }

        /// <summary>
        /// Supprime le channel correspondant au chemin specifie en parametre.
        /// </summary>
        /// <param name="folderPath">chemin du channel à supprimer</param>
        public void DeleteChannel(String channelPath)
        {
            // DECLARATION & INITIALISATION
            Channel channel = null;

            // recupere le repertoire à supprimer
            channel = GetChannel(channelPath);

            // supprime le repertoire
            channel.Delete();
        }

        /// <summary>
        /// Retourne un channel à partir de son url.
        /// </summary>
        /// <param name="url">url du channel</param>
        /// <returns>
        /// channel correspondant à l'url, ou null
        ///   si le channel n'existe pas.
        /// </returns>
        public Channel GetChannelByUrl(String url)
        {
            // INIT
            String channelPath = null;

            // recupere le chemin d'acces du channel
            channelPath = SyndicationFolder.GetChannelPathByUrl(url);

            if (channelPath != null)
            {
                return GetChannel(channelPath);
            }
            return null;
        }

        /// <summary>
        /// Determine si l'url correspond à un channel du gestionnaire
        /// </summary>
        /// <param name="url">url à determiner</param>
        /// <returns>true si l'url à un channel, false autrement</returns>
        public bool IsRegistered(String url)
        {
            return SyndicationFolder.ExistsUrl(url);
        }

        /// <summary>
        /// Retourne les chemins d'accès de tous les channels du gestionnaire
        /// </summary>
        /// <returns></returns>
        public IEnumerable<String> GetChannelsPath()
        {
            return SyndicationFolder.GetChannelsPath;
        }

        #endregion 

        #region -- Methode pour sauvegarder et charger l'arbre des repertoires

        /// <summary>
        /// Sauvegarde l'arbre des repertoires
        ///   et des channels dans un fichier xml
        /// </summary>
        /// <param name="fileName">nom du fichier de sauvegarder</param>
        public void Save(String fileName)
        {
            // INIT
            XmlDocument document = null;
            XmlNode xmlDeclaration = null;
            XmlNode rootNode = null;

            // creation du document
            document = new XmlDocument();

            // creation de la declaration xml
            xmlDeclaration = document.CreateXmlDeclaration("1.0", "utf-8", null);
            document.AppendChild(xmlDeclaration);

            // creation du repertoire root
            rootNode = document.CreateNode(XmlNodeType.Element, "root", null);
            document.AppendChild(rootNode);

            // sauvegarde l'arbre des repertoires de l'application
            Save(Root, document.DocumentElement, document);

            // sauvegarde le document xml dans un fichier
            document.Save(fileName);
        }

        /// <summary>
        /// Sauvegarde les sous-repertoires et les channels d'un repertoire
        ///   dans un fichier xml.
        /// </summary>
        /// <param name="folderParent">repertoire</param>
        /// <param name="nodeParent">node xml associé au repertoire</param>
        /// <param name="xmlDocument">fichier xml</param>
        private void Save(SyndicationFolder folderParent, XmlNode nodeParent, XmlDocument xmlDocument)
        {
            XmlNode folderNode = null;
            XmlNode channelNode = null;
            XmlNode nameNode = null;
            XmlNode linkNode = null;

            // sauvegarde les sous-repertoires
            foreach (SyndicationFolder folder in folderParent.SubFolders)
            {
                // creation du node repertorie
                folderNode = xmlDocument.CreateNode(XmlNodeType.Element, "folder", null);
                nameNode = xmlDocument.CreateNode(XmlNodeType.Element, "name", null);
                nameNode.AppendChild(xmlDocument.CreateTextNode(folder.Name));
                folderNode.AppendChild(nameNode);

                // associe le node du sous-repertoire au repertoire
                nodeParent.AppendChild(folderNode);

                // sauvegarde les repertoires et les channels de ce sous-repertoires
                Save(folder, folderNode, xmlDocument);
            }

            // sauvegarde les channels
            foreach (Channel channel in folderParent.Channels)
            {
                // creation du node du channel
                channelNode = xmlDocument.CreateNode(XmlNodeType.Element, "channel", null);
                nameNode = xmlDocument.CreateNode(XmlNodeType.Element, "name", null);
                nameNode.AppendChild(xmlDocument.CreateTextNode(channel.Name));
                channelNode.AppendChild(nameNode);
                linkNode = xmlDocument.CreateNode(XmlNodeType.Element, "link", null);
                linkNode.AppendChild(xmlDocument.CreateTextNode(channel.Link));
                channelNode.AppendChild(linkNode);

                // associé le node du channel au node du repertoire
                nodeParent.AppendChild(channelNode);
            }
        }

        /// <summary>
        /// Charge l'arbre des repertoires des flux RSS 
        ///  à partir d'un fichier XML.
        /// </summary>
        /// <param name="fileName">nom du fichier de sauvegarde</param>
        public void Load(String fileName)
        {
            try
            {
                // INIT
                XmlDocument document = null;

                // creation du document
                document = new XmlDocument();

                // charge le fichier xml
                document.Load(fileName);

                // charge l'arbre des repertoires
                Load(document.DocumentElement, Root);
            }
            catch (FileNotFoundException)  { }
        }

        /// <summary>
        /// Charge les repertoires et les channels d'un repertoire
        /// </summary>
        /// <param name="nodeParent">node xml associé au repertoire</param>
        /// <param name="folderParent">repertoire à charger</param>
        public void Load(XmlNode nodeParent, SyndicationFolder folderParent)
        {
            XmlElement element = (XmlElement)nodeParent;

            // charge les sous-repertories de ce repertoires.
            foreach (XmlNode folderNode in element.GetElementsByTagName("folder"))
            {
                if (folderNode.ParentNode.Equals(nodeParent))
                {
                    // creation du sous-repertoire
                    folderParent.CreateSubFolder(folderNode["name"].InnerText);

                    // charge les repertoires et les channels de ce sous-repertoire.
                    Load(folderNode, folderParent.GetSubFolder(folderNode["name"].InnerText));
                }
            }

            // charge les channels de ce repertoire
            foreach (XmlNode channelNode in element.GetElementsByTagName("channel"))
            {
                if (channelNode.ParentNode.Equals(nodeParent))
                {
                    // creation du channel
                    folderParent.CreateChannel(channelNode["name"].InnerText, channelNode["link"].InnerText);
                }
            }
        }

        #endregion

    }
}
