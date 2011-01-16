using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insta.Project.LecteurRSS.Model;
using System.Windows.Forms;

namespace Insta.Project.LecteurRSS.Controller
{
    /// <summary>
    /// Delegate pour l'evenement signalant l'ajout d'un repertoire
    ///   dans le model de l'application
    /// </summary>
    public delegate void NewFolderAddedDelegate(SyndicationFolder folder);

    /// <summary>
    /// Controller de la frame (vue) pour ajouter un repertoire.
    /// La frame pour ajouter un repertorie est composant permettant
    ///   de saisir les informations sur le repertoire (nom et emplacement)
    /// </summary>
    public class frmNewFolderController
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
        ///  saisie des informations sur le dossier.
        /// </summary>
        private frmNewFolder _view;

        /// <summary>
        /// Vue associé à ce controller
        /// </summary>
        public frmNewFolder View
        {
            get { return _view; }
            set { _view = value; }
        }

        #endregion

        #region -- Event --

        /// <summary>
        /// Evenement lors de l'ajout d'un repertoire dans le model
        /// </summary>
        public event NewFolderAddedDelegate NewFolderAdded;

        #endregion

        #region -- Constructeur -- 

        /// <summary>
        /// Instancie un nouveau controller associé à la frame permettant
        ///  la saisie des informations sur un repertoire (ajout).
        /// </summary>
        /// <param name="view">vue associé au controller</param>
        /// <param name="manager">model de l'application</param>
        public frmNewFolderController(frmNewFolder view,
                                SyndicationManager manager)
        {
            View = view;
            Manager = manager;
        }

        #endregion

        #region -- Methode pour ajouter un repertoire --

        /// <summary>
        /// Ajoute un nouveau repertoire dans le model l'application.
        /// </summary>
        /// <param name="name">nom du reperrtoire</param>
        /// <param name="path">emplacement repertoire</param>
        public void AddFolder(String name, String path)
        {
            // DECLARATION
            SyndicationFolder parentFolder, newFolder;

            try
            {
                // recupere le repertoire parent de ce repertoire
                if (path == "Default")
                {
                    parentFolder = Manager.Root;
                }
                else
                {
                    parentFolder = Manager.GetFolder(path);
                }

                try
                {
                    // on cree le repertorie
                    newFolder = parentFolder.CreateSubFolder(name);

                    // declenche l'evenement de l'ajout du repertoire
                    if (NewFolderAdded != null)
                    {
                        NewFolderAdded(newFolder);
                    }

                    View.Dispose();
                }
                catch (IllegalNameException exception1) {
                    MessageBox.Show(exception1.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FolderAlreadyCreatedException exception2) {
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
