using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Insta.Project.LecteurRSS;

using Insta.Project.LecteurRSS.Model;
using System.IO;

namespace Insta.Project.CI.UnitTests.LecteurRSS
{
    [TestFixture()]
    public class SyndicationManagerTests
    {
        SyndicationManager manager;

        SyndicationFolder folderRoot;

        bool initialize = true;

        [SetUp()]
        public void Initialize()
        {
            if (initialize)
            {
                manager = SyndicationManager.getInstance();

                manager.Root = new SyndicationFolder("root", null);
                folderRoot = manager.Root;

                // creation des repertoires et des channel
                //      /Informatique
                //      /Informatique/clubic/Clubic
                //      /Informatique/zdnet
                //      /informatique/matbe/Marb
                SyndicationFolder informatique = folderRoot.CreateSubFolder("Informatique");
                informatique.CreateSubFolder("clubic").CreateChannel("Clubic", "lien_clubic"); ;
                informatique.CreateSubFolder("zdnet");
                informatique.CreateSubFolder("matbe").CreateChannel("Processeur", "lien_marb");

                // creation des repertoires et channels
                //      /Maison
                //      /Maison/Jardin
                //      /Maison/Cuisine
                //      /Maison/Cuisine/Four
                SyndicationFolder Maison = folderRoot.CreateSubFolder("Maison");
                Maison.CreateSubFolder("Jardin");
                Maison.CreateSubFolder("Cuisine").CreateChannel("Four", "lien_four");

                // creation des repertoires et channels
                //      /monde
                //      /monde/europe
                //      /monde/europe/france
                //      /monde/europe/france/Paris
                //      /monde/asie
                //      /monde/asie/chine
                SyndicationFolder monde = folderRoot.CreateSubFolder("monde");
                monde.CreateSubFolder("europe").CreateSubFolder("france").CreateChannel("Paris", "lien_paris");
                monde.CreateSubFolder("asie").CreateSubFolder("chine");

                initialize = false;
            }
        }

        /// <summary>
        /// Test de la methode TestExistsChannel()
        /// 
        /// Test l'existance de plusieurs channel à partir du manager
        ///     (gestionnaire centrale de l'application)
        /// </summary>
        [Test()]
        public void TestExistsChannel()
        {
            bool result_1, result_2, result_3;

            // test l'existance du channel "/Informatique/clubic/Clubic"
            result_1 = manager.ExistsChannel("/Informatique/clubic/Clubic");

            // test l'existance du channel "/Maison/Cuisine/Four"
            result_2 = manager.ExistsChannel("/Maison/Cuisine/Four");

            // test l'existance d'un faux channel
            result_3 = manager.ExistsChannel("/Sport");

            Assert.IsTrue((result_1) && (result_2) && (!result_3));
        }

        /// <summary>
        /// Test la methode TestGetChannel
        /// 
        /// Test la recuperation de plusieurs channel à partir du manager
        ///     (gestionnaire centrale de l'application)
        /// </summary>
        [Test()]
        public void TestGetChannel()
        {
            Channel Clubic, Processeur, Four;

            // recupere le channel "Clubic" a partir du Manager
            Clubic = manager.GetChannel("/Informatique/clubic/Clubic");

            // recupere le channel "Processeur"
            Processeur = manager.GetChannel("/Informatique/matbe/Processeur");

            // recupere le channel "Four"
            Four = manager.GetChannel("/Maison/Cuisine/Four");


            Assert.IsTrue((Four.Name.Equals("Four")) && (Processeur.Name.Equals("Processeur"))
                && (Clubic.Name.Equals ("Clubic")));
        }

        /// <summary>
        /// Test la methode TestGetChannel
        /// 
        /// Troisieme test de la méthode avec un chemin d'accès 
        ///   d'un channel qui n'existe pas.
        /// </summary>
        [Test()]
        public void TestGetChannel_2()
        {
            bool result = false;
            Channel judo = null;

            // recupere le faux channel "Judo"
            try
            {
                judo = manager.GetChannel("/Sport/Judo");
            }
            catch (ChannelNotFoundException) {
                result = true;
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test la methode TestGetChannel
        /// 
        /// Troisieme test de la méthode avec un valeur null pour le chemin
        ///   d'accès du canal
        /// </summary>
        [Test()]
        public void TestGetChannel_3()
        {
            bool result = false;

            try
            {
                manager.GetChannel(null);
            }
            catch (ChannelNotFoundException) {
                result = true;
            }

            Assert.IsTrue(result);
        }
        
        /// <summary>
        /// Test de la methode TestExistsFolder()
        /// 
        /// Test l'existance de plusieurs repertoires à partir du manager
        ///     (gestionnaire centrale de l'application)
        /// </summary>
        [Test()]
        public void TestExistsFolder()
        {
            bool result_1, result_2, result_3;

            // test l'existance du repertoire "/Informatique/clubic"
            result_1 = manager.ExistsFolder("/Informatique/clubic");

            // test l'existance du repertoire "/Maison/Cuisine"
            result_2 = manager.ExistsFolder("/Maison/Cuisine");

            // test l'existance d'un faux repertoire
            result_3 = manager.ExistsFolder("/Sport");

            Assert.IsTrue((result_1) && (result_2) && (!result_3));
        }


        /// <summary>
        /// Test la methode TestGetFolder
        /// 
        /// Test la recuperation d'un repertoire à partir du manager
        ///     (annuaire des flux RSS)
        /// </summary>
        [Test()]
        public void TestGetFolder()
        {
            bool result = false;
            SyndicationFolder clubic = null;

            // recupere le repertoire "/Informatique/clubic" a partir du Manager
            clubic = manager.GetFolder("/Informatique/clubic");

            result = (clubic.Name.Equals("clubic"));

            Assert.IsTrue(result);

        }

        /// <summary>
        /// Test la methode TestGetFolder
        /// 
        /// Deuxieme test de la méthode avec un chemin d'accès d'un
        ///   repertoire qui n'existe pas.
        /// </summary>
        [Test()]
        public void TestGetFolder_2()
        {
            bool result = false;
            SyndicationFolder judo = null;

            // recupere le faux repertoire "/Sport/Judo"
            try
            {
                judo = manager.GetFolder("/Sport/Judo");
            }
            catch (FolderNotFoundException) {
                result = true;
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test la methode TestGetFolder
        /// 
        /// Troisieme test de la méthode avec une valeur null
        /// </summary>
        [Test()]
        public void TestGetFolder_3()
        {
            bool result = false;

            // valeur null pour l'argument
            try
            {
                manager.GetFolder(null);
            }
            catch (FolderNotFoundException) {
                result = true;
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test de la methode TestIsRegistered()
        /// 
        /// Verifie que le canal avec le lien "lien_four" est enregistré
        ///  dans le manager
        /// </summary>
        [Test()]
        public void TestIsRegistered()
        {
            bool result = false;

            result = manager.IsRegistered("lien_four");

            Assert.IsTrue(result == true);
        }

        /// <summary>
        /// Test la méthode GetChannelByUrl()
        /// 
        /// Recupere le canal avec le lien "lien_marb" dans le manager
        /// </summary>
        [Test()]
        public void TestGetChannelByUrl()
        {
            bool result = false;

            Channel channel = manager.GetChannelByUrl("lien_marb");

            result = (channel != null);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test la méthode GetChannelByUrl()
        /// 
        /// Essaye de recuperer un channel avec un lien qui n'existe pas
        /// </summary>
        [Test()]
        public void TestGetChannelByUrl_2()
        {
            bool result = false;

            Channel channel = manager.GetChannelByUrl("lien_faux");

            result = (channel == null);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test de la methode DeleteChannel()
        /// 
        /// Supprime le channel "/monde/europe/france/Paris"
        /// </summary>
        [Test()]
        public void TestDeleteChannel()
        {
            bool result = false;
            String channelPath = "/monde/europe/france/Paris"; // chemin d'acces du channel

            manager.DeleteChannel(channelPath);

            try
            {
                manager.GetChannel(channelPath);
            } catch (ChannelNotFoundException)
            {
                result = true;
            }


            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test de la methode DeleteFolder()
        /// 
        /// Supprime le repertoire "/monde/asie/chine"
        /// </summary>
        [Test()]
        public void TestDeleteFolder()
        {
            bool result = false;
            String folderPath = "/monde/asie/chine"; // chemin d'acces du repertoire

            manager.DeleteFolder(folderPath);

            try
            {
                manager.GetFolder(folderPath);
                result = false;
            }
            catch (FolderNotFoundException)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test des méthodes save et load
        /// 
        /// Sauvegarde un l'annuaire des repertoires, supprime l'annauire 
        ///  et charge l'annuaire
        /// </summary>
         [Test()]
        public void TestSave()
        {
            bool result = false;
            String fileName = "dataTest.xml";

            // sauvegarde l'annuaire des flux RSS
            manager.Save(fileName);

            // supprime le repertoire racine de l'annuaire
            manager.Root.Delete();

            // restaure l'annuaire des flux RSS
            manager.Load(fileName);

            result = (manager.GetFolder("/monde") != null);

            Assert.IsTrue(result);
        }
    }
}
