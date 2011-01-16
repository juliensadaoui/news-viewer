using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insta.Project.LecteurRSS.Model;
using System.Windows.Forms;

namespace Insta.Project.LecteurRSS.Controller
{
    /// <summary>
    /// Delegate pour l'evenement signalant l'ajout d'un channel
    ///     dans le model de l'application
    /// </summary>
    /// <param name="channel"></param>
    public delegate void NewChannelAddedDelegate(Channel channel);

    /// <summary>
    /// Controller de la frame (vue) pour ajouter un channel.
    /// La frame pour ajouter un channel est composant permettant
    ///   de saisir les informations sur le channel (nom, lien et emplacement).
    /// </summary>
    public class frmNewChannelController
    {
        #region -- Model de l'application --

        /// <summary>
        /// Model de l'application. Le model de l'application
        /// contient tous les données de l'application.
        /// </summary>
        private SyndicationManager _manager;

        /// <summary>
        /// Retourne ou modifie le model de l'application
        /// </summary>
        public SyndicationManager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        #endregion

        #region -- Vue associé à ce controller --

        /// <summary>
        /// La vue est le composant graphique permettant la 
        ///  saisie des informations sur le channel.
        /// </summary>
        private frmNewChannel _view;

        /// <summary>
        /// Vue associé à ce controller
        /// </summary>
        public frmNewChannel View
        {
            get { return _view; }
            set { _view = value; }
        }

        #endregion

        #region -- Event --

        /// <summary>
        /// Evenement lorsque le channel est ajouté dans le model.
        /// </summary>
        public event NewChannelAddedDelegate NewChannelAdded;

        #endregion

        #region -- Constructeur --

        /// <summary>
        /// Instancie un nouveau controller pour la frame permettant
        /// d'ajouter un channel
        /// </summary>
        /// <param name="view">vue associé à ce controller</param>
        /// <param name="manager">model de l'application</param>
        public frmNewChannelController(frmNewChannel view,
            SyndicationManager manager)
        {
            View = view;
            Manager = manager;
        }

        #endregion  

        #region -- Methode pour ajouter un canal RSS --

        /// <summary>
        /// Ajoute un nouveau canal RSS dans le model (coeur de l'application)
        /// </summary>
        /// <param name="name">nom du canal RSS</param>
        /// <param name="link">lien du canal RSS</param>
        /// <param name="folderPath">chemin du repertoire du channel</param>
        public void AddChannel(String name, String link, String folderPath)
        {
            // DECLARATION
            SyndicationFolder folder;
            Channel canalRSS;

            try
            {                    
                // recupere le repertoire du channel
                if (folderPath == "Default")
                {
                    folder = Manager.Root;
                }
                else
                {
                    folder = Manager.GetFolder(folderPath);
                }

                try
                {
                    // verifie que le lien n'existe pas
                    if (Manager.IsRegistered(link) == false)
                    {
                        // on cree le channel
                        canalRSS = folder.CreateChannel(name, link);

                        // on load le channel
                        canalRSS.Load();

                        if (canalRSS.LoadState == SyndicationLoadState.LOAD_FAILED)
                        {
                            canalRSS.Delete();
                            MessageBox.Show(canalRSS.LoadError, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // declenche l'evenement que le channel est ajouté.
                            if (NewChannelAdded != null)
                            {
                                NewChannelAdded(canalRSS);
                            }

                            // on ferme la frame
                            View.Dispose();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Un canal RSS avec le lien \"" + link + "\" existe déjà.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IllegalNameException exception1) {
                    MessageBox.Show(exception1.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ChannelAlreadyCreatedException exception2) {
                    MessageBox.Show(exception2.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FolderNotFoundException exception3) {
                MessageBox.Show(exception3.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
