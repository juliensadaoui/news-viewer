using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// pour pouvoir utiliser la classe SyndicationFolder
using Insta.Project.LecteurRSS;
using Insta.Project.LecteurRSS.Model;

// pour pouvoir utiliser les attributs
//  de l'utilitaire NUnit
using NUnit.Framework;


namespace Insta.Project.CI.UnitTests.LecteurRSS
{
    [TestFixture()]
    public class SyndicationFolderTests
    {
        // retourne l'unique "instance" (objet) de la classe
        //  SyndicationManager. C'est le coeur de l'application.
        //SyndicationManager application;

        SyndicationFolder folderRoot;

        bool initialize = true;

        [SetUp()]
        public void Initialize()
        {
            if (initialize)
            {
                // on recupere le fichier racine
                folderRoot = SyndicationManager.getInstance().Root;

                // creation du repertoire "/Informatique" dans le repertoire
                //  racine "/"
                folderRoot.CreateSubFolder("Informatique");

                // creation du repertoire "/zdnet"
                folderRoot.CreateSubFolder("zdnet");

                // creation du repertoire "/Informatique/Clubic" dans
                //      le repertoire "/Informatique"
                folderRoot.GetSubFolder("Informatique").CreateSubFolder("Clubic");

                // creation du repertoire "/Informatique/Google" dans
                //      le repertoire "/Informatique"
                folderRoot.GetSubFolder("Informatique").CreateSubFolder("Google");

                // creation du repertoire "/Site Web" dans le repertoire 
                //   racine "/"
                folderRoot.CreateSubFolder("Site web");

                // creation du channel "clubic" dans le repertoire "/Informatique"
                folderRoot.GetSubFolder("Informatique").CreateChannel("clubic", "http://www.clubic.com/");

                // creation du repertoire /Informatique/ordinateur
                folderRoot.GetSubFolder("Informatique").CreateSubFolder("ordinateur");

                initialize = false;
            }
        }


        /// <summary>
        /// Test de la methode GetSubFolder()
        /// 
        /// Test la recuperation du repertoire "/Informatique" dans
        ///     le repertoire racine "/"
        /// </summary>
        [Test()]
        public void TestGetSubFolder()
        {
            SyndicationFolder result;

            // on recupere le repertoire "/Informatique" dans le
            //  repertoire racine "/"
            result = folderRoot.GetSubFolder("Informatique");

            // on verifie que 
            //   - le repertoire "/Informatique" n'est pas vide
            //   - le chemin du repertoire "Informatique" est egal à
            //      "/Informatique
            Assert.IsTrue((result != null) 
                && (result.Path.Equals("/Informatique")));
        }

        /// <summary>
        /// Test la methode Delete(... ) de la classe SyndicationFolder
        /// 
        /// Test la supression du repertoire "/Informatique" 
        /// </summary>
        [Test()]
        public void TestDelete()
        {
            SyndicationFolder folder, result;

            // recupere le repertoire "/Informatique" dans le 
            //   repertoire racine "/"
            folder = folderRoot.GetSubFolder("Informatique").GetSubFolder("ordinateur");

            // supprime le repertoire "/Informatique"
            folder.Delete();

            try
            {
                result = folderRoot.GetSubFolder("Informatique").GetSubFolder("ordinateur");
            }
            catch (FolderNotFoundException)
            {
                result = null;
            }

            // verification
            Assert.IsTrue(result == null);
        }

        [Test()]
        public void TestExistsSubFolder()
        {
            Boolean result1, result2;

            // on recupere un repertoire existant // "/Informatique"
            result1 = folderRoot.ExistsSubFolder("Informatique");

            // on recupere un faux repertoire
            result2 = folderRoot.ExistsSubFolder("faux");

            // le premier resultat est bon // le repertoire existe
            // le deuxieme resultat est faux // le repertoire n'existe pas
            Assert.IsTrue((result1 == true) && (result2 == false));
        }

        /// <summary>
        /// Test la methode ExistsChannel()
        /// </summary>
        [Test()]
        public void TestExistsChannel()
        {
            Boolean result1, result2;

            // on recupere un channel qui existe : channel "clubic" dans "/Informatique"
            result1 = folderRoot.GetSubFolder("Informatique").ExistsChannel("clubic");

            // on recupere un channel qui n'existe pas
            result2 = folderRoot.GetSubFolder("Informatique").ExistsChannel("faux");

            // le premier resultat est bon // le channel existe
            // le deuxieme resultat est faux // le channel n'existe pas
            Assert.IsTrue((result1 == true) && (result2 == false));
        }

        /// <summary>
        /// Test la methode CreateSubFolder(... ) de la classe SyndicationFolder
        /// 
        /// Création d'un nouveau repertoire   
        /// </summary>
        [Test()]
        public void TestCreateSubFolder()
        {
            SyndicationFolder informatiqueFolder;
            String messageException = null;

            //recupere le repertoire "/Informatique" dans le repertoire "/"
            informatiqueFolder = folderRoot.GetSubFolder("Informatique");

            try {
                // on crée le repertoire "/Informatique/Google"
                informatiqueFolder.CreateSubFolder("Google");
            } 
            catch (FolderAlreadyCreatedException e) {
                Console.WriteLine(e.Message);
                messageException = e.Message;
            }

            // on verifie que le dossier "/Google" a bien été crée dans "/Informatique"
            Assert.IsTrue((informatiqueFolder != null) && (messageException != ""));
        }

        /// <summary>
        /// Test la methode Move(... ) de la classe SyndicationFolder
        /// 
        /// Test le deplacement du repertoire "/Informatique/Clubic"
        ///     dans le repertoire "/Site web"
        /// </summary>
        [Test()]
        public void TestMove()
        {
            SyndicationFolder informatiqueFolder, clubicFolder, webFolder, resultFolder;

            // recupere le repertoire "/Informatique" dans le repertoire "/"
            informatiqueFolder = folderRoot.GetSubFolder("Informatique");

            // recupere le repertoire "/Informatique/Clubic"
            clubicFolder = informatiqueFolder.GetSubFolder("Clubic");

            // on deplace le repertoire "/Informatique/Clubic" dans le 
            //   repertoire "/Site web"
            clubicFolder.Move("/Site web");

            try
            {
                resultFolder = informatiqueFolder.GetSubFolder("Clubic");
            } // on rattrape l'exception
            catch (FolderNotFoundException) {
                resultFolder = null;
            }

            webFolder = folderRoot.GetSubFolder("Site web");

            // on verifie que :
            //  - le Path du repertoire "Clubic" est "/Site web/Clubic"
            //  - le repertoire "Clubic" n'est plus present dans le repertorie "/Informatique"
            Assert.IsTrue((resultFolder == null) && (clubicFolder.Path.Equals("/Site web/Clubic"))
                && (webFolder.GetSubFolder("Clubic") != null));
        }

        /// <summary>
        /// Test la methode GetChannel()
        /// 
        /// Test la recuperation du channel "clubic" dans le repertoire "/Informatique"
        /// </summary>
        [Test()]
        public void TestGetChannel()
        {
            Channel channel = null;

            // on recupere la channel "clubic" dans le repertoire "/Informatique"
            channel = folderRoot.GetSubFolder("Informatique").GetChannel("clubic");

            Assert.IsTrue((channel != null) && (channel.Name.Equals("clubic"))
                && (channel.Path.Equals("/Informatique/clubic")));
        }

        /// <summary>
        /// Test de la methode TestCreateChannel()
        /// 
        /// Test de la creation du channel "Manga" dans le repertoire "/Informatique"
        /// </summary>
        [Test()]
        public void TestCreateChannel()
        {
            Channel channel = null;

            // creation du channel "Manga" dans le repertoire "/Informatique"
            folderRoot.GetSubFolder("Informatique").CreateChannel("Manga", "http://www.cluc.com/");

            channel = folderRoot.GetSubFolder("Informatique").GetChannel("Manga");

            Assert.IsTrue((channel != null) && (channel.Name.Equals("Manga"))
                && (channel.Parent.Name.Equals("Informatique")));
        }

        /// <summary>
        /// Test la methode ToString(... ) de la classe SyndicationFolder
        /// 
        /// Affiche l'objet sous forme d'un texte
        /// </summary>
        [Test()]
        public void TestToString()
        {

            SyndicationFolder zdnetFolder;
            String resutToString;

            //recupere le repertoire "/Informatique" dans le repertoire "/"
            zdnetFolder = folderRoot.GetSubFolder("zdnet");
            resutToString = zdnetFolder.ToString();

            // on verifie que la fonction a bien renvoyée:
            //  -le nom du repertoire
            //  -le chemin du repertoir
            Assert.IsTrue(resutToString.Contains("zdnet"));
        }
    }
}
