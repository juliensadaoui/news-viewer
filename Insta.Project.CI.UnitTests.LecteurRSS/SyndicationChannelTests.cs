using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// pour pouvoir utiliser la classe SyndicationFolder
using Insta.Project.LecteurRSS;
// pour pouvoir utiliser les attributs
//  de l'utilitaire NUnit
using NUnit.Framework;
using Insta.Project.LecteurRSS.Model;
using System.Threading;

namespace Insta.Project.CI.UnitTests.LecteurRSS
{
    [TestFixture()]
    public class SyndicationChannelTests
    {
        //Channel channel;
        SyndicationFolder folder;

        bool initialize = true;

        [SetUp()]
        public void Initialize()
        {
            if (initialize)
            {
                // url du channel
                String link = "http://www.clubic.com/xml/news.xml";

                // on cree un repertoire 
                folder = new SyndicationFolder("Informatique", null);

                //Création d'un nouveau channel
                folder.CreateChannel("clubic", link);

                initialize = false;
            }
        }

        /// <summary>
        /// Test la methode Load() 
        /// 
        /// Test la methode de mise à jour d'un channel
        ///   de maniere synchrone
        /// </summary>
        [Test()]
        public void TestToLoad()
        {
            bool result = true;

            Channel channel = folder.GetChannel("clubic");
            channel.Load();

            result &= (channel.LoadState == SyndicationLoadState.LOADED);
            result &= (channel.Title != null);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test la methode LoadAsync() 
        /// 
        /// Test la methode de mise à jour d'un channel
        ///   de maniere asynchrone
        /// </summary>
        [Test()]
        public void TestToLoadAsync()
        {
            bool result = false;

            Channel channel = new Channel("Zdnet", "http://www.zdnet.fr/feeds/rss/", null);
            channel.LoadAsync();

            while ((channel.LoadState != SyndicationLoadState.LOADED)
                && (channel.LoadState != SyndicationLoadState.LOAD_FAILED))
            {
                Thread.Sleep(10);
            }

            result = (channel.LoadState == SyndicationLoadState.LOADED);

            Console.WriteLine(channel.ToString());

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test la methode Load() 
        /// 
        /// Test la methode de mise à jour d'un channel
        ///   de maniere synchrone avec une erreur
        /// </summary>
        [Test()]
        public void TestLoad_2()
        {
            bool result = true;

            // url du channel
            String link = "http://www.clubic.l/news.xml";

            // création d'un nouveau channel
            Channel channel = folder.CreateChannel("clubicerror", link);

            channel.Load();

            result = (channel.LoadState == SyndicationLoadState.LOAD_FAILED);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test de la méthode TestMarkAllItemsRead
        /// 
        /// Test si tous les articles d'un canal RSS sont marqués comme lus 
        /// </summary>
        [Test()]
        public void TestMarkAllItemsRead()
        {
            bool result = false;
            
            // update le channel
            Channel channel = folder.GetChannel("clubic");
            channel.Load();

            // marque toutes les articles comme lus
            channel.MarkAllItemsRead();

            result = (channel.UnreadItemCount == 0);

            Assert.IsTrue(result);
        }
    }
}

    
