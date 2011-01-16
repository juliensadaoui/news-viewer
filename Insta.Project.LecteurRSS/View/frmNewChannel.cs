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
    ///  pour ajouter un canal
    /// </summary>
    public partial class frmNewChannel : Form
    {
        #region -- Controller de la vue --

        private frmNewChannelController _controller;

        public frmNewChannelController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        #endregion

        #region -- Constructeur --

        /// <summary>
        /// Instancie un nouvelle frame pour creer un channel
        /// </summary>
        /// <param name="manager">model de l'application</param>
        /// <param name="folderPref">repertorie par defaut</param>
        public frmNewChannel(SyndicationManager manager, 
                             String folderPref)
        {
            InitializeComponent();
            InitializeComboBox(manager.Root);
            if (folderPref != null)
            {
                FolderComboBox.SelectedItem = folderPref;
            }
            Controller = new frmNewChannelController(this, manager);
        }

        #endregion

        #region -- Initialize ComboBox --

        /// <summary>
        /// Initialise la combox en ajoutant l'arbre des repertoires
        ///  à partir du repertoire root
        /// </summary>
        /// <param name="folderRoot">repertoire root</param>
        public void InitializeComboBox(SyndicationFolder folderRoot)
        {
            if (folderRoot.Path == "")
                FolderComboBox.Items.Add("Default");

            foreach (SyndicationFolder folder in folderRoot.SubFolders)
            {
                FolderComboBox.Items.Add(folder.Path);
                InitializeComboBox(folder);
            }
        }

        #endregion

        #region -- Methode des events declenchés par l'utilisateur --

        /// <summary>
        /// Evenement declenché lorsque la zone de saisie (EditBox)
        ///  du nom du channel est en cours de modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChangedNameRSS(object sender, EventArgs e)
        {
            CheckNewChannelInfo();
        }

        /// <summary>
        /// Evenement declenché lorsque la zone de saisie (EditBox)
        ///  du lien du channel est en cours de modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChangedLienRSS(object sender, EventArgs e)
        {
            CheckNewChannelInfo();
        }

        /// <summary>
        /// Evenement declenché lorsque la selection du repertoire
        ///  (ComboBox) est en cours de modification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectedChangedFolder(object sender, EventArgs e)
        {
            CheckNewChannelInfo();
        }

        /// <summary>
        /// Evenement declenché lorsque l'utilisateur a cliqué sur le 
        ///     bouton "Annuler"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnnulerButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Evenement declenché lorsque l'utilisateur a cliqué 
        ///  sur le bouton ajouté.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterButton_Click(object sender, EventArgs e)
        {
            String name, link, folderPath;

            // on recupere les informations du channel
            name = NameChannelTextBox.Text;
            link = LinkChannelTextBox.Text;
            folderPath = ((String) FolderComboBox.SelectedItem);

            // on ajoute le channel
            Controller.AddChannel(name, link, folderPath);
        }

        #endregion

        #region -- Methode de verification des informations du channel --

        /// <summary>
        /// Active ou desactive le boutton ajouter en fonction de la saisie 
        ///  des informations du channel par l'utilisateur
        /// </summary>
        public void CheckNewChannelInfo()
        {
            if ((NameChannelTextBox.Text != "") &&
                (LinkChannelTextBox.Text != "") &&
                (FolderComboBox.SelectedIndex != -1))
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
