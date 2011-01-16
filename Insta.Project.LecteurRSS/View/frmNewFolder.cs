using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// ressources pour le controller
using Insta.Project.LecteurRSS.Controller;

// ressources pour le manager
using Insta.Project.LecteurRSS.Model;

namespace Insta.Project.LecteurRSS
{
    /// <summary>
    /// Frame permettant la saisie des informations
    ///  pour ajouter un repertoire.
    /// </summary>
    public partial class frmNewFolder : Form
    {
        #region -- Controller de la vue --

        private frmNewFolderController _controller;

        /// <summary>
        /// Retourne ou modifie le controller de la vue
        /// </summary>
        public frmNewFolderController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        #endregion

        #region -- Constructeur --

        /// <summary>
        /// Instancie un nouvelle frame pour creer un repertoire
        /// </summary>
        /// <param name="manager">model de l'application</param>
        /// <param name="folderPref">repertorie par defaut</param>
        public frmNewFolder(SyndicationManager manager,
                             String folderPref)
        {
            
            InitializeComponent();
            InitializeComboBox(manager.Root);

            if (folderPref != null)
            {
                LocationFolderComboBox.SelectedItem = folderPref;
                LocationFolderComboBox.SelectedValue = folderPref;
            }
            Controller = new frmNewFolderController(this, manager);
        }

        #endregion

        #region -- Initialize ComboBox --

        /// <summary>
        /// Initialise le ComboBox en ajoutant l'arbre des repertoires
        ///  à partir du repertoire root
        /// </summary>
        /// <param name="folderRoot">repertoire root</param>
        public void InitializeComboBox(SyndicationFolder folderRoot)
        {
            if (folderRoot.Path == "") {
                LocationFolderComboBox.Items.Add("Default");
            }

            foreach (SyndicationFolder folder in folderRoot.SubFolders)
            {
               LocationFolderComboBox.Items.Add(folder.Path);
               InitializeComboBox(folder);
            }
        }

        #endregion

        #region -- Methode des Events declenchés par l'utilisateur --

        /// <summary>
        /// Evenement declenché lorsque la zone de saisie (EditBox)
        ///   du nom du repertoire est en cours de modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameFolder_OnTextChanged(object sender, EventArgs e)
        {
            CheckNewFolderInfo();
        }

        /// <summary>
        /// Evenement declenché lorsque la selection du repertoire
        ///  (ComboBox) est en cours de modification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocationFolder_OnSelectedChanged(object sender, EventArgs e)
        {
            CheckNewFolderInfo();
        }

        /// <summary>
        /// Evenement declenché lorsque l'utilisateur a cliqué 
        ///     sur le bouton "Ajouter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterButton_Click(object sender, EventArgs e)
        {
            String name, path;

            // on recupere les informations du repertoire
            name = NameNewFolderEditBox.Text;
            path = ((String)LocationFolderComboBox.SelectedItem);

            // on ajoute le repertoire en passant par le controller
            Controller.AddFolder(name, path);
        }

        /// <summary>
        /// Evenement declenché lorsque l'utilisateur a cliqué 
        ///     sur le bouton "Annuler"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnnulerButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region -- Methode de verification de la saisie d'informations sur le repertoire -- 

        /// <summary>
        /// Active ou desactive le boutton ajouter en fonction de la saisie 
        ///  des informations du repertoire par l'utilisateur
        /// </summary>
        public void CheckNewFolderInfo()
        {
            if ((NameNewFolderLabel.Text != "") &&
                (LocationFolderComboBox.SelectedIndex != -1))
            {
                AjouterButton.Enabled = true;
            }
            else
            {
                AjouterButton.Enabled = false;
            }    
        }

        #endregion
    }
}
