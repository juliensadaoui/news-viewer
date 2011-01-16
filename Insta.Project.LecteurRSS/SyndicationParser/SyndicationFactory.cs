using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

// ressources du canal
using Insta.Project.LecteurRSS.Model;

namespace Insta.Project.LecteurRSS.SyndicationParser
{
    /// <summary>
    /// Cette classe implemente le design Pattern Factory. Elle permet de retourner
    ///   un analyseur de fichier XML en fonction du type de format du flux de syndication. 
    /// </summary>
    public class SyndicationFactory
    {
        /// <summary>
        /// Retourne le type de format du flux de syndication
        /// </summary>
        /// <param name="document"></param>
        /// <returns>
        /// Type de format du flux de syndication
        ///     1. ATOM_1_0 pour Atom 1.0
        ///     2. RSS_0_91 pour RSS 0.91
        ///     3. RSS_0_92 pour RSS 0.92
        ///     4. RSS_2_0 pour RSS 2.0
        /// </returns>
        private static SyndicationFormat GetSyndicationFormat(XmlDocument document)
        {
            // DECLARATION & INITIALISATION
            XmlElement root = null;
            String rootName = null;
            String version = null;
            SyndicationFormat format;

            // on recupere la racine du document XML
            root = document.DocumentElement;
            rootName = root.Name;
            format = SyndicationFormat.NONE;

            if (rootName.Equals("feed"))
            {
                if (root.NamespaceURI.Equals("http://www.w3.org/2005/Atom"))
                {
                    format = SyndicationFormat.ATOM_1_0;
                }  
            }
            else if (rootName.Equals("rss"))
            {
                version = root.GetAttribute("version");

                if (version != null) {

                    if (version.Contains("0.91"))
                    {
                        format = SyndicationFormat.RSS_0_91;
                    }
                    else if (version.Contains("0.92"))
                    {
                        format = SyndicationFormat.RSS_0_92;
                    }
                    else if (version.Contains("2.0"))
                    {
                        format = SyndicationFormat.RSS_2_0;
                    }
                }
            }
            return format;
        }

        /// <summary>
        /// Retourne un analyseur de flux de syndication en fonction
        ///  du type de format contenant dans le fichier XML.
        /// </summary>
        /// <param name="document">fichier XML du flux RSS</param>
        /// <param name="channel">channel associé à ce flux</param>
        /// <returns>analyseur XML</returns>
        public static AbstractSyndicationParser GetParser(XmlDocument document, Channel channel)
        {
            // DECLARATION
            AbstractSyndicationParser parser;
            SyndicationFormat format;

            // INITIALISATION
            format = SyndicationFormat.NONE;
            parser = null;

            // type de format du flux de syndication
            format = GetSyndicationFormat(document);
            switch (format)
            {
                case SyndicationFormat.RSS_0_91:
                    parser = new RSS_0_91_Parser(document, channel, "RSS 0.91");
                    break;
                case SyndicationFormat.RSS_0_92:
                    parser = new RSS_0_92_Parser(document, channel, "RSS 0.92");
                    break;
                case SyndicationFormat.RSS_2_0:
                    //Enum.GetName(typeof(SyndicationFormat), SyndicationFormat.RSS_2_0);
                    parser = new RSS_2_0_Parser(document, channel, "RSS 2.0");
                    break;
                case SyndicationFormat.ATOM_1_0:
                    parser = new ATOM_1_0_Parser(document, channel, "Atom 1.0");
                    break;
                default:
                    // TODO exception
                    break;
            }

            return parser;
        }
    }
}
