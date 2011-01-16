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
    /// Classe permettant d'analyser un fichier XML correspondant 
    ///   à un flux RSS 0.92. Elle herite de la AbstractSyndicationParser
    ///   qui implemente de le pattern Template Method. Ce pattern permet
    ///   de decomposer l'analyser du fichier XML RSS 0.92 en plusieurs
    ///   étapes
    /// </summary>
    public class RSS_0_92_Parser : AbstractSyndicationParser
    {
        #region -- Node associé à la balise "channel" --

        /// <summary>
        /// Noeud associé à la base "channel"
        /// </summary>
        private XmlNode _channelNode = null;

        /// <summary>
        /// Retourne et Modifie le noeud associé à la balise "channel"
        /// </summary>
        private XmlNode ChannelNode
        {
            get { return _channelNode; }
            set { _channelNode = value; }
        }

        #endregion

        #region -- Constructeur --

        /// <summary>
        /// Instancie un nouveau analyseur de fichier XML 
        ///   correspondant un flux de syndication RSS 0.92
        /// </summary>
        /// <param name="document">fichier xml à analyser</param>
        /// <param name="link">lien du site web associé à ce fichier XML</param>
        /// <param name="format">type du format du flux de syndication</param>
        public RSS_0_92_Parser(XmlDocument document, Channel channel, String format) :
            base(document, channel, format)
        {
            ChannelNode = Root.GetElementsByTagName("channel").Item(0);

            if (ChannelNode == null)
            {
                //throw new SyndicationParserException();
            }
        }

        #endregion

        #region -- Methode analysant le flux RSS 0.92 --

        /// <summary>
        /// Méthode qui analyse la balise "channel" d'un flux RSS 0.92.
        /// La balise "channel" contient des informations générales sur un
        ///  flux RSS 0.92.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux RSS 0.92.
        /// </summary>
        protected override void ParseChannel()
        {
            // titre du channel
            if (ChannelNode["title"] != null) {
                Title = ChannelNode["title"].InnerText;   
            }

            // url du site web du channel
            if (ChannelNode["link"] != null) {
                Link = ChannelNode["link"].InnerText;
            }

            // description du channel
            if (ChannelNode["description"] != null) {
                Description = ChannelNode["description"].InnerText;
            }

            // langue du contenu du channel
            if (ChannelNode["language"] != null) {
                Language = ChannelNode["language"].InnerText;
            }

            
            if (ChannelNode["copyright"] != null) {
                Copyright = ChannelNode["copyright"].InnerText;
            }

            // mail de la personne responsable du contenu du channel
            if (ChannelNode["managingEditor"] != null){
                ManagingEditor = ChannelNode["managingEditor"].InnerText;
            }

            // mail de la personne responsable du site web
            if (ChannelNode["webMaster"] != null){
                WebMaster = ChannelNode["webMaster"].InnerText;
            }

            // date de publication du channel
            if (ChannelNode["pubDate"] != null) {
                PubDate = ChannelNode["pubDate"].InnerText;
            }

            // derniere date ou le contenu a changé
            if (ChannelNode["lastBuildDate"] != null) {
                LastBuildDate = ChannelNode["lastBuildDate"].InnerText;
            }

            // URL pointant sur la documentation du format utilisé pour le fichier RSS
            if (ChannelNode["docs"] != null) {
                Docs = ChannelNode["docs"].InnerText;
            }

            // côte PICS pour le canal. 
            // côte PICS pour le canal. 
            if (ChannelNode["rating"] != null) {
                Rating = ChannelNode["rating"].InnerText;
            }

            // indice pour les aggrégateurs leur indiquant combien d'heures peuvent être sautées.
            if (ChannelNode["skipHours"] != null) {
                SkipHours = int.Parse(ChannelNode["skipHours"].InnerText);
            }

            //  indice pour les aggrégateurs leur indiquant combien de jours peuvent être sautés. 
            if (ChannelNode["skipDays"] != null) {
                SkipDays = ChannelNode["skipDays"].InnerText;
            }

            if (ChannelNode["txtInput"] != null) {
                // non implementé pour l'instant
            }
        }

        /// <summary>
        /// Méthode qui analyse la balise "cloud" d'un flux RSS 0.92.
        /// La balise "cloud" contient des informations sur le service web
        ///   associés à ce flux.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux RSS 0.92.
        /// </summary>
        protected override void ParseCloud()
        {
            // DECLARATION & INITIALISATION
            Cloud = new Cloud();

            // service web associé au channel
            if (ChannelNode["cloud"] != null) {

                if (ChannelNode["cloud"].GetAttribute("domain") != null) {
                    Cloud.Domain = ChannelNode["cloud"].GetAttribute("domain");
                }

                if (ChannelNode["cloud"].GetAttribute("port") != null) {
                    Cloud.Port = int.Parse(ChannelNode["cloud"].GetAttribute("port"));
                }

                if (ChannelNode["cloud"].GetAttribute("path") != null) {
                    Cloud.Path = ChannelNode["cloud"].GetAttribute("path");
                }

                if (ChannelNode["cloud"].GetAttribute("registerProcedure") != null) {
                    Cloud.RegisterProcedure = ChannelNode["cloud"].GetAttribute("registerProcedure");
                }

                if (ChannelNode["cloud"].GetAttribute("protocol") != null) {
                    Cloud.Protocol = ChannelNode["cloud"].GetAttribute("protocol");
                }
            }
        }

        /// <summary>
        /// Méthode qui analyse la balise "image" d'un flux RSS 0.92.
        /// La balise "image" contient des informations sur l'image
        ///   associés à ce flux. Elle represente en générale le logo
        ///   du site web associé au flux.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux RSS 0.92.
        /// </summary>
        protected override void ParseImage()
        {
            // DECLARATION
            XmlNode imageNode;

            // INITIALISATION
            imageNode   = null;
            Image       = null;

            //  image associé au channel
            if (ChannelNode["image"] != null) 
            {
                // recupere la node associé à la base "<image>"
                imageNode = ChannelNode["image"];

                if (imageNode["url"] != null) {
                    // url du lien de l'image
                    Image = new Image(imageNode["url"].InnerText);

                    // titre de l'image
                    if (imageNode["title"] != null) {
                        Image.Title = imageNode["title"].InnerText;
                    }

                    // url du channel associé à l'image
                    if (imageNode["link"] != null) {
                        Image.Link = imageNode["link"].InnerText;
                    }

                    // description de l'image
                    if (imageNode["description"] != null) {
                        Image.Description = imageNode["description"].InnerText;
                    }

                    // largeur en pixel de l'image
                    if (imageNode["width"] != null) {
                        Image.Width = int.Parse(imageNode["width"].InnerText);
                    }

                    // hauteur en pixel de l'image
                    if (imageNode["height"] != null) {
                        Image.Height = int.Parse(imageNode["height"].InnerText);
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui analyse les balises "item" d'un flux RSS 0.92.
        /// Les balises "item" contiennent des informations sur les articles
        ///   (actualités) associés à ce flux.
        /// 
        /// Dans l'implémentation fournie par cette classe, le fichier XML
        ///  analysé correspond à un flux RSS 0.92.
        /// </summary>
        protected override void ParseItems ()
        {
            // DECLARATION
            String title, link, description, guid, source, category;
            Item item;

            // convertis le noeud de la balise "channel" en
            //   un element XML.
            XmlElement element = (XmlElement)ChannelNode;

            // ------------------------------------------------
            //  On recupere tous les articles (actualité) du channel
            // ------------------------------------------------
            foreach (XmlNode itemNode in element.GetElementsByTagName("item"))
            {
                // INITALISATION
                category = null;
                title = null;
                link = null;
                description = null;
                guid = null;
                source = null;

                // titre de l'article
                if (itemNode["title"] != null) {
                    title = itemNode["title"].InnerText;
                    guid = title;
                }

                // url de la page web contenant l'article
                if (itemNode["link"] != null) {
                    link = itemNode["link"].InnerText;
                }

                // description de l'article
                if (itemNode["description"] != null) {
                    description = itemNode["description"].InnerText;

                    // recupere une partie de la description si l'article
                    //   ne possede pas de titre.
                    if (title == null) {
                        title = GetTitleToDescription(description);
                        guid = description; // basé sur toutes la description
                    }
                }

                // categorie de l'article
                if (itemNode["category"] != null) {
                    category = itemNode["category"].InnerText;
                }

                // nom du canal RSS d'où vient l'item
                if (itemNode["source"] != null) {
                    if (itemNode["source"].GetAttribute("url") != null) {
                        source = itemNode["source"].GetAttribute("url");
                    }
                    else {
                        source = itemNode["source"].InnerText;
                    }
                }

                item = new Item(Channel , title, link, description, null, 
                              category, null, guid,
                              source, null, null, null);

                // on ajoute seulement si la clé n'existe pas. Ce cas peut arriver si deux items
                //    ont la meme description.
                if (!Items.ContainsKey (guid)) {
                    Items.Add(guid, item);
                }

            } // end foreach()
        }

        #endregion
    }
}
