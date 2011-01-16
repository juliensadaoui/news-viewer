using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insta.Project.LecteurRSS.Model;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace Insta.Project.LecteurRSS.Controller
{
    /// <summary>
    /// Controlleur de la frame principale (vue) de l'application
    /// </summary>
    public class frmManagerController
    {
        /// <summary>
        /// Nom du fichier de sauvegarde
        /// </summary>
        private const String filename = "data.xml";

        #region -- Model de l'application --

        private SyndicationManager _manager;

        public SyndicationManager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        #endregion

        #region -- Vue associé au controller --

        /// <summary>
        /// Vue (frame) associé à ce controller
        /// </summary>
        private frmManager _view;

        /// <summary>
        /// Retourne ou modifie la vue associé au controller.
        /// </summary>
        public frmManager View 
        {
            get { return _view; }
            set { _view = value; }
        }

        #endregion

        #region -- Channel associé à la listview --

        Channel _channel;
        
        /// <summary>
        /// Canal RSS associé à la listview .. 
        /// </summary>
        public Channel Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        #endregion

        #region -- Constructeur

        /// <summary>
        /// Instancie un nouveau controller associé à une frmManager
        /// </summary>
        /// <param name="view">vue associé au controller</param>
        public frmManagerController(frmManager view)
        {
            Manager = SyndicationManager.getInstance();
            View = view;
        }

        #endregion 

        #region -- Methode permettant de modifier le model de l'application (folder) --

        /// <summary>
        /// Affiche le frame permettant le saisie des informations
        ///  du channel pour l'ajouter repertoire au model
        /// </summary>
        /// <param name="defaultFolderPath">
        /// emplacement du repertoire par defaut, peut-etre egal à null
        /// </param>
        public void AddFolder(String defaultFolderPath)
        {
            // creation de la frame pour ajouter un repertoire
            frmNewFolder frm = new frmNewFolder(Manager, defaultFolderPath);

            // on s'abonne a l'evenement indiquant l'ajout du repertoire
            frm.Controller.NewFolderAdded += new NewFolderAddedDelegate(NewFolderAdded);

            // on affiche la frame
            frm.ShowDialog();
        }

        /// <summary>
        /// Supprime le repertoire correspondant au chemin spécifié 
        ///  en parametre du model de l'application
        /// </summary>
        /// <param name="FolderPath">chemin du repertoire à supprimer</param>
        public void DeleteFolder(String folderPath)
        {
            Manager.DeleteFolder(folderPath);
            Manager.Save(filename);

            View.RemoveTreeViewNode(folderPath);
            // ancienne methode
            //View.UpdateTreeView(Manager.Root);
        }

        /// <summary>
        /// Affiche la frame permettant de deplacer un repertoire
        ///   dans le model de l'application.
        /// </summary>
        /// <param name="folderPath"></param>
        public void MoveFolder(string folderPath)
        {
            // INIT
            SyndicationFolder folder = null;

            try
            {
                // recupere le repertoire
                folder = Manager.GetFolder(folderPath);

                // creation de la frame pour deplacer le repertoire
                frmDeplacer frm = new frmDeplacer(Manager, folder);

                // on s'abonne a l'evenement indiquant le deplacement du repertoire
                frm.Controller.ElemMoved +=new Insta.Project.LecteurRSS.Controller.ElemMovedDelegate(ElemMoved);

                // on affiche la frame
                frm.ShowDialog();
                
            }
            catch (FolderNotFoundException exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Marque tous les articles (item) associés à un repertoire comme
        ///  lus. Les articles associés à un repertoire tous les articles 
        ///  associés aux channels de ce repertoire et de ces sous repertoires.
        /// </summary>
        /// <param name="folderPath">
        /// Chemin d'accès du repertoire dans l'arbre des repertoires des flux
        ///  RSS. La valeur du chemin d'accès pour le repertoire racine est root.
        /// </param>
        public void MaskAsReadFolder(string folderPath)
        {
            // INITIALISATION
            SyndicationFolder folder;

            // recupere le repertoire
            if (folderPath == "root")
            {
                folder = Manager.Root;
            }
            else
            {
                folder = Manager.GetFolder(folderPath);
            }

            // marque les articles comme lus
            folder.MarkAllItemsRead();

            // update la frame principale
            View.UpdateTreeViewText(Manager.Root);
            if (Channel != null) {
                View.UpdateListView(Channel.Items);
            }
        }

        #endregion

        #region -- Methode permettant de modifier le model de l'application (channel) --

        /// <summary>
        /// Affiche le frame permettant le saisie des informations
        ///  du channel pour l'ajouter un channel au model
        /// </summary>
        /// <param name="defaultFolderPath">
        /// emplacement du channel par defaut, peut-etre egal à null
        /// </param>
        public void AddChannel (String defaultFolderPath)
        {
            // creation de la frame pour ajouter un channel
            frmNewChannel frm = new frmNewChannel(Manager, defaultFolderPath);
            
            // on s'abonne a l'evenement indiquant l'ajout du channel
            frm.Controller.NewChannelAdded += new NewChannelAddedDelegate(NewChannelAdded);
            
            // affiche la frame
            frm.ShowDialog();
        }

        /// <summary>
        /// Affiche la frame permettant deplacer un channel
        /// </summary>
        /// <param name="channelPath">chemin du channel</param>
        public void MoveChannel(string channelPath)
        {
            // INIT
            Channel channel = null;

            try
            {
                channel = Manager.GetChannel(channelPath);

                // creation de la frame pour deplacer le channel
                frmDeplacer frm = new frmDeplacer(Manager, channel);

                // on s'abonne a l'evenement indiquant le deplacement du channel
                frm.Controller.ElemMoved += new Insta.Project.LecteurRSS.Controller.ElemMovedDelegate(ElemMoved);

                // on affiche la frame
                frm.ShowDialog();

            }
            catch (FolderNotFoundException exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Supprime le canal RSS correspondant au chemin spécifié 
        ///  en parametre du model de l'application
        /// </summary>
        /// <param name="channelPath">chemin du canal RSS</param>
        public void DeleteChannel(String channelPath)
        {
            // INIT
            Channel channel = null;
            String key = null;

            try
            {
                // recupere le channel
                channel = Manager.GetChannel(channelPath);
                key = channel.Path;

                // update la listview si le channel à supprimer
                //   est le channel actuel de la listview
                if (channel == Channel) 
                {
                    View.ClearListView();
                    Channel = null;
                }

                // delete channel
                channel.Delete();

                Manager.Save(filename);

                View.UpdateTreeViewText(Manager.Root);
                View.RemoveTreeViewNode(key);
            }
            catch (ChannelNotFoundException e) {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Marque tous les articles (actualité) comme lus
        ///  d'un canal RSS.
        /// </summary>
        /// <param name="channelPath">chemin du canal RSS</param>
        public void MaskAsReadChannel(String channelPath)
        {
            // INIT
            Channel channel = null;

            // marque le channel comme lu
            channel = Manager.GetChannel(channelPath);
            channel.MarkAllItemsRead();

            // update la frame principale
            View.UpdateTreeViewText(Manager.Root);
            View.UpdateListView(channel.Items);
        }

        /// <summary>
        ///  Copie le lien du site web du channel dans le presse papier
        /// </summary>
        /// <param name="channelPath">chemin du canal RSS</param>
        public void CopyLinkChannel(String channelPath)
        {
            // INIT
            Channel channel = null;
            String link = null;

            // recupere le lien du channel
            channel = Manager.GetChannel(channelPath);
            link = channel.Link;

            Clipboard.SetText(link);
        }

        /// <summary>
        ///  Met à jour un flux RSS de l'application
        /// </summary>
        /// <param name="channelPath">chemin d'accès du channel</param>
        public void Update(String channelPath)
        {
            // INITIALISATION
            Channel channel = null;

            // recupere le channel
            channel = Manager.GetChannel(channelPath);
            
            // update le channel
            channel.Load();

            // verifie l'etat de l'update du channel
            switch (channel.LoadState)
            {
                case SyndicationLoadState.LOADED:
                    View.UpdateTreeViewText(Manager.Root);
                    if (Channel == channel)
                    {
                        View.UpdateListView(channel.Items);
                    }
                    break;
                case SyndicationLoadState.LOAD_FAILED:
                    MessageBox.Show(channel.LoadError , "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Met à jour l'ensemble des flux RSS de l'application.
        /// Cette opération est executé dans un thread particulier,
        ///   appelé BackgroundWorker, géré par l'interface graphiqie.
        ///   Le BackgroundWorker permet de lancer des longues 
        ///   opérations sans bloquer l'interface graphique.
        /// </summary>
        /// <param name="WorkerThread"></param>
        public String UpdateAll(BackgroundWorker WorkerThread)
        {
            // INIT
            List<Channel> channels = new List<Channel>();
            String errorMessage = "";
            Channel channel = null;
            int nbChannelNotLoaded = 0;
            int nbChannelLoaded = 0;

            // recupere tous les flux RSS (channel) de l'application
            foreach (String path in Manager.GetChannelsPath())
            {
                channel = Manager.GetChannel(path);
                channels.Add(channel);
                nbChannelNotLoaded++;
            }
 
            // update l'ensemble des flux RSS (channel)
            for (int i = 0 ; i < channels.Count ; i++)
            {
                channels[i].Load();

                switch (channels[i].LoadState)
                {
                    case SyndicationLoadState.LOAD_FAILED:
                        errorMessage += channels[i].LoadError + "\n";
                        break;
                    case SyndicationLoadState.LOADED:
                        break;
                    default:
                        break;
                }

                // envoie le pourcentage pour la progress bar
                if (nbChannelNotLoaded > 100)
                {
                    WorkerThread.ReportProgress((nbChannelLoaded * 100) / nbChannelNotLoaded);
                }
                else
                {
                    WorkerThread.ReportProgress(nbChannelLoaded);
                }
                nbChannelLoaded++;
            }

            if (nbChannelLoaded < 100)
            {
                for (int i = nbChannelLoaded; i < 100; i++)
                {
                    WorkerThread.ReportProgress(i);
                    Thread.Sleep(2);
                }
            }

            return ((errorMessage == "") ? null : errorMessage);
        }

        #endregion

        #region -- Methode permettant de modifier le model (item) --

        /// <summary>
        /// Marque un article comme lu
        /// </summary>
        /// <param name="guid">identifiant de l'item</param>
        public void MaskAsReadItem(String guid)
        {
            // INIT
            Item item = null;

            if (Channel != null)
            {
                // recupere l'article à marquer comme lu
                item = Channel.GetItem(guid);

                if (item != null)  {
                    item.IsRead = true;

                    // update la frame principale
                    View.UpdateTreeViewText(Manager.Root);
                    View.UpdateListView(Channel.Items);
                }
            }
        }

        /// <summary>
        /// Supprime un article (actualité) d'un channel
        /// </summary>
        /// <param name="guid">Identifiant de l'article</param>
        public void DeleteItem(String guid)
        {
            // INIT
            Item item = null;
            String key = null;

            if (Channel != null)
            {
                item = Channel.GetItem(guid);

                if (item != null){
                    // recupere le clé de l'item
                    key = item.Guid;

                    // supprime l' item
                    item.Delete();

                    // update la frame principale
                    View.UpdateTreeViewText(Manager.Root);
                    View.RemoveListViewLine(key);
                }
            }
        }

        /// <summary>
        ///  Copie le lien du site web de l'article dans le presse papier
        /// </summary>
        /// <param name="channelPath">identifiant de l'article</param>
        public void CopyLinkItem(String guid)
        {
            // INIT
            Item item = null;
            String link = null;

            if (Channel != null)
            {
                item = Channel.GetItem(guid);
                link = item.Link;

                Clipboard.SetText(link);
            }
        }

        /// <summary>
        /// Ouvre une webrowser (nagiteur) sur le lien web de l'article
        /// </summary>
        /// <param name="guid">identifiant de l'article</param>
        public void NavigateTo(String guid)
        {
            // INIT
            Item item = null;
            frmBrowser frmBrowser = null;

            // recupere le lien de l'article
            item = Channel.GetItem(guid);
            if (item.Link != null)
            {
                frmBrowser = new frmBrowser();
                frmBrowser.Show();
                frmBrowser.NavigateTo(item.Link);
                MaskAsReadItem(guid);
            }
            else {
                MessageBox.Show("Cette actualité ne contient pas de lien web !");
            }
        }

        /// <summary>
        /// Affiche la liste des article d'un flux RSS
        ///  dans la listview de la frame principale
        /// </summary>
        /// <param name="channelPath">chemin d'accès du flux RSS</param>
        public void DisplayItem(String channelPath)
        {
            // INITIALISATION
            Channel channel = null;

            // recupere le flux RSS
            channel = Manager.GetChannel(channelPath);

            // configure le channel courant
            Channel = channel;

            // affiche les articles du flux RSS
            View.UpdateListView(channel.Items);
        }

        #endregion

        #region -- Methode des evenements declenchés par les frames apparentées --

        /// <summary>
        /// Methode de l'evenement declenché lors de l'ajout
        ///  d'un channel dans le model de l'application.
        /// On met à jour la treeview de la frame principale
        /// </summary>
        void NewChannelAdded(Channel channel)
        {
            Manager.Save(filename);
            View.AddTreeViewNode(channel);
            View.UpdateTreeViewText(Manager.Root);
            // ancienne methode
            //View.UpdateTreeView(Manager.Root);
        }

        /// <summary>
        /// Methode de l'evenement declenché lors de l'ajout
        ///  d'un repertoire dans le model de l'application.
        /// On met à jour la treeview de la frame principale
        /// </summary>
        void NewFolderAdded(SyndicationFolder folder)
        {
            Manager.Save(filename);
            View.AddTreeViewNode(folder);
            // ancienne methode
            // View.UpdateTreeView(Manager.Root);
        }

        /// <summary>
        /// Methode de l'evenement declenché lors du deplacement
        ///  d'un element dans le model de l'application.
        /// </summary>
        void ElemMoved()
        {
            Manager.Save(filename);
            View.UpdateTreeView(Manager.Root);
        }

        #endregion

        #region -- Methode de sauvegarde et de chargement du model --

        /// <summary>
        /// Charge l'arbre des repertoires des channels RSS
        ///   Methode lancé au démarrage de l'application.
        /// </summary>
        public void Load()
        {
            Manager.Load(filename);
            View.UpdateTreeView(Manager.Root);
        }

        /// <summary>
        /// Sauvegarde l'arbre des repertoires des channels RSS
        /// </summary>
        public void Save()
        {
            Manager.Save(filename);
        }

        #endregion
    } 
}
