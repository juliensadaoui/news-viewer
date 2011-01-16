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
    ///   utilisant la norme RSS 2.0
    /// </summary>
    [TestFixture()]
    public class RSS_2_0_ParserTests
    {
        /// <summary>
        /// 
        /// </summary>
        String sampleRss2Xml = Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleRss2;
        
        /// <summary>
        /// Analyseur de fichier Xml pour les flux de syndication RSS 2.0
        /// </summary>
        RSS_2_0_Parser parser;

        [SetUp()]
        public void Initialize()
        {
            // creation d'un document de fichier XML
            XmlDocument document = new XmlDocument();

            // charge le fichier XML en memoire
            document.LoadXml(sampleRss2Xml);

            // initialise un analyseur de flux de syndication RSS 2.0
            parser = new RSS_2_0_Parser(document, new Channel("Test", "http://www.test.com", null), "RSS 2.0");
        }

        /// <summary>
        /// Test la methode TestParse
        /// 
        /// Test l'analyse d'un fichier XML d'un flux de syndication RSS 2.0
        ///   Le fichier XML pour realiser ce test est le fichier exemple fournit
        ///    par le specification http://www.scriptol.fr/rss/RSS-2.0.html
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
            result &= (parser.Title.Equals("Liftoff News"));
            result &= (parser.Link.Equals("http://liftoff.msfc.nasa.gov/"));
            result &= (parser.Description.Equals("Liftoff to Space Exploration."));
            result &= (parser.Language.Equals("en-us"));
            result &= (parser.PubDate.Equals("Tue, 10 Jun 2003 04:00:00 GMT"));
            result &= (parser.LastBuildDate.Equals("Tue, 10 Jun 2003 09:41:01 GMT"));
            result &= (parser.Docs.Equals("http://blogs.law.harvard.edu/tech/rss"));
            result &= (parser.Generator.Equals("Weblog Editor 2.0"));
            result &= (parser.ManagingEditor.Equals("editor@example.com"));
            result &= (parser.WebMaster.Equals("webmaster@example.com"));

            // on test un article contenu le channel
            item1 = parser.Items["http://liftoff.msfc.nasa.gov/2003/05/30.html#item572"];
            result &= (item1.Link.Equals("http://science.nasa.gov/headlines/y2003/30may_solareclipse.htm"));
            result &= (item1.Description.Equals("Sky watchers in Europe, Asia, and parts of Alaska and Canada will experience a <a href=\"http://science.nasa.gov/headlines/y2003/30may_solareclipse.htm\">partial eclipse of the Sun</a> on Saturday, May 31st."));
            result &= (item1.PubDate.Equals("Fri, 30 May 2003 11:06:42 GMT"));
            result &= (item1.Guid.Equals("http://liftoff.msfc.nasa.gov/2003/05/30.html#item572"));

            // on test un deuxieme article contenu dans le channel
            item2 = parser.Items["http://liftoff.msfc.nasa.gov/2003/05/27.html#item571"];
            result &= (item2.Title.Equals("The Engine That Does More"));
            result &= (item2.Link.Equals("http://liftoff.msfc.nasa.gov/news/2003/news-VASIMR.asp"));
            result &= (item2.Description.Equals("Before man travels to Mars, NASA hopes to design new engines that will let us fly through the Solar System more quickly.  The proposed VASIMR engine would do that."));
            result &= (item2.PubDate.Equals("Tue, 27 May 2003 08:37:32 GMT"));
            result &= (item2.Guid.Equals("http://liftoff.msfc.nasa.gov/2003/05/27.html#item571"));

            // test l'image
            image = parser.Image;
            result &= (image.Title.Equals("Clubic.com - Actualité"));
            result &= (image.Url.Equals("http://www.clubic.com/style/images/logo-clubic.gif"));
            result &= (image.Link.Equals("http://www.clubic.com/"));
		    result &= (image.Width == 144);
            result &= (image.Height == 60); 

            Assert.IsTrue(result);
        }
    }
}
