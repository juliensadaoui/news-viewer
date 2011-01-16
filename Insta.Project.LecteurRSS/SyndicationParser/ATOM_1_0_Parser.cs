using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ressources de l'analyseur de fichier XML
using System.Xml;

// ressources du canal
using Insta.Project.LecteurRSS.Model;

namespace Insta.Project.LecteurRSS.SyndicationParser
{
    /// <summary>
    /// Classe permettant d'analyser un fichier XML correspondant 
    ///   à un flux Atom 1.0. Elle herite de la AbstractSyndicationParser
    ///   qui implemente de le pattern Template Method. Ce pattern permet
    ///   de decomposer l'analyser du fichier XML Atom 1.0 en plusieurs
    ///   étapes
    ///   
    /// Implémentation partielle de l'analyseur
    /// </summary>
    public class ATOM_1_0_Parser : AbstractSyndicationParser
    {
        #region -- Node associé à la balise "feed" --

        /// <summary>
        /// Noeud associé à la base "channel"
        /// </summary>
        private XmlNode _feedNode = null;

        /// <summary>
        /// Retourne et Modifie le noeud associé à la balise "feed"
        /// </summary>
        private XmlNode FeedNode
        {
            get { return _feedNode; }
            set { _feedNode = value; }
        }

        #endregion

        #region -- Constructeur --

        /// <summary>
        /// Instancie un nouveau analyseur de fichier XML
        ///  correspondant à un flux ATOM 1.0.
        /// </summary>
        /// <param name="document">fichier XML</param>
        /// <param name="channel">channel associé à ce fichier</param>
        /// <param name="format">nom du format du flux</param>
        public ATOM_1_0_Parser(XmlDocument document, Channel channel, String format) :
            base (document, channel, format)
        {
            // recupere l'element 'feed' du fichier XML
            FeedNode = Root;

            if (FeedNode == null)
            {
                //throw new SyndicationParserException();
            }
        }

        #endregion

        #region -- Methode analysant le flux Atom 1.0 --

        /// <summary>
        /// Méthode qui analyse la balise "feed" d'un flux Atom 1.0.
        /// La balise "channel" contient des informations générales sur un
        ///  flux Atom 1.0.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux Atom 1.0.
        /// </summary>
        protected override void ParseChannel()
        {
            if (FeedNode == null)
                return;

            // titre ou nom du channel
            if (FeedNode["title"] != null)
            {
                Title = FeedNode["title"].InnerText;
            }

            // sous titre du channe
            if (FeedNode["subtitle"] != null)
            {
                //Channel = feed["subtitle"].InnerText;
            }

            // url du site web associé au channel
            if (FeedNode["link"] != null)
            {
                Link = FeedNode["link"].GetAttribute("href");
            }

            // description du channel
            if (FeedNode["summary"] != null)
            {
                Description = FeedNode["summary"].InnerText;
            }

            // date de la derniere mise à jour du channel
            if (FeedNode["updated"] != null)
            {
                // TODO
            }

            // auteur de l'article
            if (FeedNode["author"] != null)
            {
                if (FeedNode["author"]["name"] != null)
                {
                    ManagingEditor = FeedNode["author"]["name"].InnerText;
                }
            }
        }

        /// <summary>
        /// Méthode d'analyse la balise "image" d'un flux Atom 1.0.
        /// La balise "image" contient des informations sur l'image
        ///   associés à ce flux. Elle represente en générale le logo
        ///   du site web associé au flux.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux Atom 1.0.
        /// </summary>
        protected override void ParseImage()
        {
            return;
        }

        /// <summary>
        /// Méthode qui analyse les balises "item" d'un flux RSS 2.0.
        /// Les balises "item" contiennent des informations sur les articles
        ///   (actualités) associés à ce flux.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux RSS 2.0.
        /// </summary>
        protected override void ParseItems()
        {
            // DECLARATION
            String title, link, description, guid, source,
                pubDate, updated, comments, category, author;
            Item item;

            // convertis le noeud de la balise "feed" en
            //   un element XML.
            XmlElement element = (XmlElement) FeedNode;

            // ------------------------------------------------
            //  On recupere tous les articles (actualité) du channel
            // ------------------------------------------------
            foreach (XmlNode itemNode in element.GetElementsByTagName("entry"))
            {
                // initialisation
                title = null;
                link = null;
                description = null;
                guid = null;
                source = null;
                pubDate = null;
                updated = null;
                comments = null;
                author = null;
                category = null;

                // titre de l'article
                if (itemNode["title"] != null)
                {
                    title = itemNode["title"].InnerText;
                }

                // url de la page web contenant l'article
                if (itemNode["link"] != null)
                {
                    link = itemNode["link"].GetAttribute("href");
                }

                // description de l'article
                if (itemNode["summary"] != null)
                {
                    description = itemNode["summary"].InnerText;
                }

                // identifiant de l'article
                if (itemNode["id"] != null)
                {
                    guid = itemNode["id"].InnerText;
                }

                // date de publication de l'article
                if (itemNode["published"] != null)
                {
                    pubDate = itemNode["published"].InnerText;
                }

                item = new Item(Channel, title, link, description, author,
                              category, null, guid,
                              source, pubDate, updated, comments);

                Items.Add(guid, item);

            } // end foreach()
        }

        /// <summary>
        /// Méthode qui analyse la balise flux Atom 1.0
        /// La balise ... contient des informations sur le service web
        ///   associés à ce flux.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux Atom 1.0
        /// </summary>
        protected override void ParseCloud()
        {
            return;
        }

        #endregion
    }
}
