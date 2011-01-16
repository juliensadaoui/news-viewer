using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ressources pour les tests unitaires
using NUnit.Framework;

// ressources du projet
using Insta.Project.LecteurRSS;
using Insta.Project.LecteurRSS.SyndicationParser;
using Insta.Project.LecteurRSS.Model;

// ressources pour analyser les fichiers XML
using System.Xml;

namespace Insta.Project.CI.UnitTests.LecteurRSS
{
    /// <summary>
    /// Test la classe qui analyse les flux de syndication 
    ///   utilisant la norme RSS 0.92
    /// </summary>
    [TestFixture()]
    public class RSS_0_92_ParserTests
    {
        /// <summary>
        /// Fichier XML contenant le flux de syndication RSS 0.92
        /// </summary>
        String sampleRss092Xml = Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleRss092;

        /// <summary>
        /// Analyseur de fichier Xml pour les flux de syndication RSS 0.92
        /// </summary>
        RSS_0_92_Parser parser;

        [SetUp()]
        public void Initialise()
        {
            // creation d'un document de fichier XML
            XmlDocument document = new XmlDocument();

            // charge le fichier XML en memoire
            document.LoadXml(sampleRss092Xml);

            // initialise un analyseur de flux de syndication RSS 0.92
            parser = new RSS_0_92_Parser(document, new Channel("Test", "http://www.scripting.com/blog/categories/gratefulDead.html", null), "RSS 0.92");
        }

        /// <summary>
        /// Test la methode TestParse
        /// 
        /// Test l'analyse d'un fichier XML d'un flux de syndication RSS 0.91
        ///   Le fichier XML pour realiser ce test est le fichier exemple fournit
        ///    par la specification
        /// </summary>
        [Test()]
        public void TestParse()
        {
            // DECLARATION
            bool result = true;
          //  Item item1, item2;

            parser.Parse();

            // on test si l'analyseur a bien recupéré toutes les informations
            //      generales du channel contenu dans le fichier
            result &= (parser.Title.Equals("Dave Winer: Grateful Dead"));
            result &= (parser.Link.Equals("http://www.scripting.com/blog/categories/gratefulDead.html"));
            //result &= (parser.Description.Equals("A high-fidelity Grateful Dead song every day. This is where we&apos;re experimenting with enclosures on RSS news items that download when you&apos;re not using your computer. If it works (it will) it will be the end of the Click-And-Wait multimedia experience on the Internet."));
            result &= (parser.LastBuildDate.Equals("Fri, 13 Apr 2001 19:23:02 GMT"));
            result &= (parser.Docs.Equals("http://backend.userland.com/rss092"));
            result &= (parser.ManagingEditor.Equals("dave@userland.com (Dave Winer)"));
            result &= (parser.WebMaster.Equals("dave@userland.com (Dave Winer)"));

            // on test le service web associé à ce channel
            result &= (parser.Cloud.Domain.Equals("data.ourfavoritesongs.com"));
            result &= (parser.Cloud.Port == 80);
            result &= (parser.Cloud.Path.Equals("/RPC2"));
            result &= (parser.Cloud.RegisterProcedure.Equals("ourFavoriteSongs.rssPleaseNotify"));
            result &= (parser.Cloud.Protocol.Equals("xml-rpc"));

            Assert.IsTrue(result);
        }
    }
}
