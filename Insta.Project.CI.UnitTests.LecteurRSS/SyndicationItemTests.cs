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
    /// <summary>
    /// Test des méthode de la classe Item
    /// </summary>
    [TestFixture()]
    public class SyndicationItemTests
    {
        // Repertoire associé à l'article
        SyndicationFolder folder;

        // Canal RSS associé à l'article
        Channel channel;

        [SetUp()]
        public void Initialize()
        {
            folder = SyndicationManager.getInstance().Root;

            channel = new Channel("Zdnet", "http://www.zdnet.fr/feeds/rss/", folder);
        }

        /// <summary>
        /// Test la methode Delete(... ) de la classe Item
        /// 
        /// Test la supression d'un article dans un channel
        /// </summary>
        [Test()]
        public void TestDelete()
        {
            String guid = null;
            bool result = true;

            // on charge le channel
            channel.Load();

            foreach (Item item in channel.Items)
            {
                guid = item.Guid;
                item.Delete();
                break;
            }

            result = (channel.GetItem(guid) == null);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test la propriete Delete(... ) de la classe Item
        /// </summary>
        [Test()]
        public void TestIsRead()
        {
            String guid = null;
            bool result = true;

            // on charge le channel
            channel.Load();

            foreach (Item item in channel.Items)
            {
                guid = item.Guid;
                item.IsRead = true;
                break;
            }

            result = (channel.GetItem(guid).IsRead);

            Assert.IsTrue(result);
        }
    }
}
