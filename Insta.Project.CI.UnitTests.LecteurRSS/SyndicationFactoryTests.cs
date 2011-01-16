using System;
using System.Collections.Generic;
using System.Text;

// ressources pour les tests unitaires
using NUnit.Framework;
using Insta.Project.LecteurRSS;
using Insta.Project.LecteurRSS.SyndicationParser;
using Insta.Project.LecteurRSS.Model;
using System.Xml;

namespace Insta.Project.CI.UnitTests.LecteurRSS
{
    [TestFixture()]
    public class SyndicationFactoryTest
    {
        // analyseur générique
        AbstractSyndicationParser parser;

        // fichier XML d'un flux RSS 0.91
        String rss_0_91_file;

        // fichier XML d'un flux RSS 0.92
        String rss_0_92_file;

        // fichier XML d'un flux RSS 2.0
        String rss_2_0_file;

        // fichier XML d'un flux RSS 2.0
        String atom_1_0_file;

        // channel associé au flux
        Channel channel;

        /// <summary>
        /// Recupere les fichiers XML correspondant à un fichier exemple d'un norme de flux RSS
        /// </summary>
        [SetUp()]
        public void Initialize()
        {
            channel = new Channel("test", "test", null);
            rss_0_91_file = global::Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleRss091;
            rss_0_92_file = global::Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleRss092;
            rss_2_0_file = global::Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleRss2;
            atom_1_0_file = global::Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleAtom1;
        }

        /// <summary>
        /// Test de la methode GetParser
        /// 
        /// Recupere l'analyseur correspondant au flux RSS 2.0
        /// </summary>
        [Test()]
        public void TestGetParser_1()
        {
            bool result = false;
            XmlDocument document = null;

            // recupere l'analyseur
            document = new XmlDocument();
            document.LoadXml(rss_2_0_file);
            parser = SyndicationFactory.GetParser(document, channel);

            if (parser != null)
            {
                if (parser is RSS_2_0_Parser)
                {
                    result = true;
                }
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test de la methode GetParser
        /// 
        /// Recupere l'analyseur correspondant au flux RSS 0.92
        /// </summary>
        [Test()]
        public void TestGetParser_2()
        {
            bool result = false;
            XmlDocument document = null;

            // recupere l'analyseur
            document = new XmlDocument();
            document.LoadXml(rss_0_92_file);
            parser = SyndicationFactory.GetParser(document, channel);

            if (parser != null)
            {
                if (parser is RSS_0_92_Parser)
                {
                    result = true;
                }
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test de la methode GetParser
        /// 
        /// Recupere l'analyseur correspondant au flux RSS 0.91
        /// </summary>
        [Test()]
        public void TestGetParser_3()
        {
            bool result = false;
            XmlDocument document = null;

            // recupere l'analyseur
            document = new XmlDocument();
            document.LoadXml(rss_0_91_file);
            parser = SyndicationFactory.GetParser(document, channel);

            if (parser != null)
            {
                if (parser is RSS_0_91_Parser)
                {
                    result = true;
                }
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test de la methode GetParser
        /// 
        /// Recupere l'analyseur correspondant au flux Atom 1.0
        /// </summary>
        [Test()]
        public void TestGetParser_4()
        {
            bool result = false;
            XmlDocument document = null;

            // recupere l'analyseur
            document = new XmlDocument();
            document.LoadXml(atom_1_0_file);
            parser = SyndicationFactory.GetParser(document, channel);

            if (parser != null)
            {
                if (parser is ATOM_1_0_Parser)
                {
                    result = true;
                }
            }

            Assert.IsTrue(result);
        }
    }
}
