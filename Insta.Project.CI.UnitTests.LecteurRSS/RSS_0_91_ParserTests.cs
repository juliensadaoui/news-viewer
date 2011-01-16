using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ressources pour les tests unitaires
using NUnit.Framework;

// ressources du projet
using Insta.Project.LecteurRSS;
using Insta.Project.LecteurRSS.Model;
using Insta.Project.LecteurRSS.SyndicationParser;

// ressources pour analyser les fichiers XML
using System.Xml;

namespace Insta.Project.CI.UnitTests.LecteurRSS
{
    /// <summary>
    /// Test la classe qui analyse les flux de syndication 
    ///   utilisant la norme RSS 0.91
    /// </summary>
    [TestFixture()]
    public class RSS_0_91_ParserTests
    {
        /// <summary>
        /// Fichier XML contenant le flux de syndication RSS 0.91
        /// </summary>
        String sampleRss091Xml = Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleRss091;

        /// <summary>
        /// Analyseur de fichier Xml pour les flux de syndication RSS 0.91
        /// </summary>
        RSS_0_91_Parser parser;

        [SetUp()]
        public void Initialise()
        {
            // creation d'un document de fichier XML
            XmlDocument document = new XmlDocument();

            // charge le fichier XML en memoire
            document.LoadXml(sampleRss091Xml);

            // initialise un analyseur de flux de syndication RSS 0.91
            parser = new RSS_0_91_Parser(document, new Channel("Test", "http://writetheweb.com", null), "RSS 0.91");
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
            Item item1, item2;
            Image image;

            parser.Parse();

            // on test si l'analyseur a bien recupéré toutes les informations
            //      generales du channel contenu dans le fichier
            result &= (parser.Title.Equals("WriteTheWeb"));
            result &= (parser.Link.Equals("http://writetheweb.com"));
            result &= (parser.Description.Equals("News for web users that write back"));
            result &= (parser.Language.Equals("en-us"));
            result &= (parser.Copyright.Equals("Copyright 2000, WriteTheWeb team."));
            result &= (parser.ManagingEditor.Equals("editor@writetheweb.com"));
            result &= (parser.WebMaster.Equals("webmaster@writetheweb.com"));

            // on test un article contenu le channel
            item1 = parser.Items["Giving the world a pluggable Gnutella"];
            result &= (item1.Title.Equals("Giving the world a pluggable Gnutella"));
            result &= (item1.Link.Equals("http://writetheweb.com/read.php?item=24"));
            result &= (item1.Description.Equals("WorldOS is a framework on which to build programs that work like Freenet or Gnutella -allowing distributed applications using peer-to-peer routing."));

            // on test un deuxieme article contenu dans le channel
            item2 = parser.Items["Personal web server integrates file sharing and messaging"];
            result &= (item2.Title.Equals("Personal web server integrates file sharing and messaging"));
            result &= (item2.Link.Equals("http://writetheweb.com/read.php?item=22"));
            result &= (item2.Description.Equals("The Magi Project is an innovative project to create a combined personal web server and messaging system that enables the sharing and synchronization of information across desktop, laptop and palmtop devices."));

            // test l'image
            image = parser.Image;
            result &= (image.Title.Equals("WriteTheWeb"));
            result &= (image.Url.Equals("http://writetheweb.com/images/mynetscape88.gif"));
            result &= (image.Link.Equals("http://writetheweb.com"));
            result &= (image.Description.Equals("News for web users that write back"));
            result &= (image.Width == 88);
            result &= (image.Height == 31); 

            Assert.IsTrue(result);
        }
    }
}
