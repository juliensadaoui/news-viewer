using System;
using System.Collections.Generic;
using System.Text;

// ressources de l'analyseur de fichier XML
using System.Xml;

// ressources du canal
using Insta.Project.LecteurRSS.Model;

namespace Insta.Project.LecteurRSS.SyndicationParser
{
    /// <summary>
    /// Classe abstrait servant de base pour l'analyse de flux
    ///   de syndication (RSS 0.91, RSS 0.92, RSS 2.0, Atom 1.0 ...)
    /// Classe implementant le design pattern Template Method.
    /// </summary>
    public abstract class AbstractSyndicationParser : ISyndicationParser
    {
        #region Attribut

        /// <summary>
        /// taille de la longueur du titre
        /// </summary>
        protected int MAX_TITLE_LENGTH = 60;

        /// <summary>
        /// channel associé au analyseur du fichier XML
        /// </summary>
        private Channel _channel;

        /// <summary>
        /// Document DOM: Representation en memorie sous forme d'arbre
        ///  du fichier XML
        /// </summary>
        private XmlDocument _document;

        /// <summary>
        /// noeud (element) racine de l'arbre (representation en memorie) 
        ///     du fichier XML
        /// </summary>
        private XmlElement _root;

        #endregion

        #region Constructeur

        /// <summary>
        /// Instancie un analyseur de fichier XML
        /// </summary>
        /// <param name="document">representation en memoire du fichier XML associé au flux</param>
        /// <param name="channel">channel associé à l'analyseur XML</param>
        /// <param name="format">format du flux de syndication utilisé par le channel</param>
        protected AbstractSyndicationParser(XmlDocument document, Channel channel, String format)
        {
            Document = document;
            Link = channel.Link;
            Format = format;
            Channel = channel;

            Items = new Dictionary<string, Item>();
            Categories = new List<string>();

            // TODO expcetion si null
            if (Document != null)
                Root = Document.DocumentElement;
        }

        #endregion

        #region Propriete

        /// <summary>
        /// Channel associé au analyseur de fichier XML
        /// </summary>
        public Channel Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        /// <summary>
        /// Document DOM: Representation en memoire sous forme d'arbre
        ///  du fichier XML
        /// </summary>
        public XmlDocument Document
        {
            get { return _document; }
            set { _document = value; }
        }

        /// <summary>
        /// noeud (element) racine de l'arbre (representation en memorie) 
        ///     du fichier XML
        /// </summary>s
        public XmlElement Root
        {
            get { return _root; }
            set { _root = value; }
        }

        // Propriete contenant les informations sur le Channel
        public String Format { get; protected set; }
        public String Title { get; protected set; }
        public String Link { get; protected set; }
        public String Description { get; protected set; }
        public String Language { get; protected set; }
        public String Copyright { get; protected set; }
        public String ManagingEditor { get; protected set; }
        public String WebMaster { get; protected set; }
        public String PubDate { get; protected set; }
        public String LastBuildDate { get; protected set; }
        public List<String> Categories { get; protected set; }
        public String Generator { get; protected set; }
        public String Docs { get; protected set; }
        public String Ttl { get; protected set; }
        public String Rating { get; protected set; }
        public int SkipHours { get; protected set; }
        public String SkipDays { get; protected set; }
        public Image Image { get; protected set; }
        public Cloud Cloud { get; protected set; }
        public Dictionary<String, Item> Items { get; protected set; }

        #endregion

        #region -- Methode --

        /// <summary>
        /// Retourne le titre d'un article contenu dans sa description
        /// </summary>
        /// <param name="description">description contenant le titre</param>
        /// <returns>titre de l'article</returns>
        protected String GetTitleToDescription(String description)
        {
            // DECLARATION
            Char[] titleToCharArray;
            String resultTitle;

            if (description.Length > MAX_TITLE_LENGTH)
            {
                resultTitle = description.Substring(0, MAX_TITLE_LENGTH);
            }
            else
            {
                resultTitle = description;
            }

            resultTitle.Normalize();

            // supprime apres un blanc
            titleToCharArray = resultTitle.ToCharArray();

            for (int i = (resultTitle.Length - 1); i >= 0 
                && i >= (resultTitle.Length/2) /* Fix Bug with RSS 0.92 */ ; i--)
            {
                if (titleToCharArray[i] == ' ')
                {
                    resultTitle = resultTitle.Substring(0, i) + "...";
                    break;
                }
            }
            

            return resultTitle;
        }

        #endregion

        #region -- Implementation du Design Pattern Templates Method --

        /// <summary>
        /// Méthode "Template" (modèle).
        /// </summary>
        public void Parse()
        {
            ParseChannel();
            ParseImage();
            ParseCloud();
            ParseItems();
        }

        /// <summary>
        /// Méthode abstraite permettant d'analyser les informations generales d'un Channel
        ///       dans un fichier XML de flux de syndication. 
        /// L'implémentation de cette méthode sera redéfinie par les classes dérivées.
        /// </summary>
        protected abstract void ParseChannel();

        /// <summary>
        /// Méthode abstraite permettant d'analyser les informations sur l'image associée au
        ///     Channel dans un fichier XML de flux de syndication. 
        /// L'implémentation de cette méthode sera redéfinie par les classes dérivées.
        /// </summary>
        protected abstract void ParseImage();

        /// <summary>
        /// Méthode abstraite permettant d'analyser les informations sur les articles associés au
        ///     Channel dans un fichier XML de flux de syndication. 
        /// L'implémentation de cette méthode sera redéfinie par les classes dérivées.
        /// </summary>
        protected abstract void ParseItems();

        /// <summary>
        /// Méthode abstraite permettant d'analyser les informations sur le service web associés au
        ///     Channel dans un fichier XML de flux de syndication. 
        /// L'implémentation de cette méthode sera redéfinie par les classes dérivées.
        /// </summary>
        protected abstract void ParseCloud();

        #endregion
    }
}
