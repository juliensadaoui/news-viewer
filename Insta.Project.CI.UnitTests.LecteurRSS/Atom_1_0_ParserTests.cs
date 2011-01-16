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
    ///   utilisant la norme Atom 1.0
    /// </summary>
    [TestFixture()]
    public class Atom_1_0_ParserTests
    {
        /// <summary>
        /// Fichier XML contenant le flux de syndication RSS 0.91
        /// </summary>
        String sampleAtomXml = global::Insta.Project.CI.UnitTests.LecteurRSS.Properties.Resources.sampleAtom1;

        /// <summary>
        /// Analyseur de fichier Xml pour les flux de syndication RSS 0.91
        /// </summary>
        AbstractSyndicationParser parser;

        [SetUp()]
        public void Initialise()
        {
            // creation d'un document de fichier XML
            XmlDocument document = new XmlDocument();

            // charge le fichier XML en memoire
            document.LoadXml(sampleAtomXml);

            // initialise un analyseur de flux de syndication RSS 0.91
            parser = new ATOM_1_0_Parser(document, new Channel("Test", "http://example.org/", null), "Atom 1.0");
        }

        /// <summary>
        /// Test de la méthode TestParse
        /// 
        /// Test l'analyse d'un fichier XML d'un flux de syndication Atom 1.0
        /// </summary>
        [Test()]
        public void TestParse()
        {
            // DECLARATION
            bool result = true;

            parser.Parse();

            result &= (parser.Title != null);
            result &= (parser.Link != null);
            result &= (parser.ManagingEditor != null);
            result &= (parser.Items.Count == 1);

            Assert.IsTrue(result);
        }
    }
}
