using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Insta.Project.LecteurRSS.SyndicationParser
{
    public class SyndicationParser : AbstractSyndicationParser
    {
        /// <summary>
        /// Formmat du contenu de syndication
        ///  (RSS 0.91, RSS 2.0, ATOM 1.0 ...)
        /// </summary>
        private SyndicationFormat _format;

        #region Constructeur

        public SyndicationParser(XmlDocument document, String link, Channel channel) :
            base(document, link, channel)
        {
            CheckSyndicationFormat(); // on recupere le format 
        }

        #endregion

        #region Propriete

        public SyndicationFormat Format
        {
            get { return _format; }
            set { _format = value; }
        }

        #endregion

        /// <summary>
        /// On verifie le type de format du flux de syndication
        /// </summary>
        public void CheckSyndicationFormat()
        {
            String racine = Root.Name;
            racine.ToLower();

            if (racine.Equals("feed")) {
                Format = SyndicationFormat.ATOM_1_0;
                Channel.Format = "Atom 1.0";
            }
            else if (racine.Equals("rss")) {
                String version = Root.GetAttribute("version");

                if (version != null) {
                    if (version.Contains("0.91"))
                    {
                        Format = SyndicationFormat.RSS_0_91;
                        Channel.Format = "RSS " + version;
                    }
                    else if (version.Contains("0.92"))
                    {
                        Format = SyndicationFormat.RSS_0_92;
                        Channel.Format = "RSS " + version;
                    }
                    else if (version.Contains("2.0"))
                    {
                        Format = SyndicationFormat.RSS_2_0;
                        Channel.Format = "RSS " + version;
                    }
                }
            }
        }


        public override void Parse()
        {
            AbstractSyndicationParser parser;
            parser = null;

            switch (Format)
            {
                case SyndicationFormat.RSS_0_91:
                    parser = new RSS_0_91_Parser(Document, Channel.Link, Channel);
                    break;
                case SyndicationFormat.RSS_0_92:
                    parser = new RSS_0_92_Parser(Document, Channel.Link, Channel);
                    break;
                case SyndicationFormat.RSS_2_0:
                    parser = new RSS_2_0_Parser(Document, Channel.Link, Channel);
                    break;
                case SyndicationFormat.ATOM_1_0:
                    break;
                default:
                    Channel = null;
                    break;
            }

            if (parser != null) {
                parser.Parse();
            }

        }
    }
}
