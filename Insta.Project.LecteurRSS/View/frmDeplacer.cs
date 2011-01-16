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
    /// Frame permettant de deplacer un element.
    /// </summary>
    public partial class frmDeplacer : Form
    {
        #region -- Controller associé à cette frame --

        private frmDeplacerController _controller;

        /// <summary>
        /// Retourne le controller associé à la frame
        /// </summary>
        public frmDeplacerController Controller
        {
            get { return _controller; }
        }

        #endregion

        #region -- Constructeur --

        /// <summary>
        /// Initialise la frame
        /// </summary>
        /// <param name="elem">element à deplacer</param>
        /// <param name="folderRoot">repertoire racine</param>
        public frmDeplacer(SyndicationManager manager, Object elem)
        {
            InitializeComponent();
            _controller = new frmDeplacerController(manager, this, elem);
            InitializeComboBox(manager.Root);

            if (elem is Channel)
            {
                this.Text += "channel";
                this.frmSummaryLabel.Text += "channel.";
                this.frmTitleLabel.Text += "channel.";
                this.newPathLabel.Text += "channel.";
            }
            else if (elem is SyndicationFolder)
            {
                this.Text += "repertoire";
                this.frmSummaryLabel.Text += "repertoire.";
                this.frmTitleLabel.Text += "repertoire.";
                this.newPathLabel.Text += "repertoire.";
            }
            else
            {
                Dispose();
            }
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
                newFolderComboBox.Items.Add("Default");

            foreach (SyndicationFolder folder in folderRoot.SubFolders)
            {
                newFolderComboBox.Items.Add(folder.Path);
                InitializeComboBox(folder);
            }
        }

        #endregion

        #region -- Methode des events declenchés par l'utilisateur --

        /// <summary>
        /// Evenement declenché lorsque la selection du repertoire
        ///  (ComboBox) est en cours de modification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newFolderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValiderButton.Enabled = true;
        }

        /// <summary>
        /// Methode de l'evenement lorsque l'utilisateur a cliqué 
        ///   sur le boutton "Annuler". Ferme la frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnnulerButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// Methode de l'evenement lorsque l'utilisateur a cliqué 
        ///   sur le boutton "Valider".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            String folderPath;

            // repertoire le nouveau emplacement de l'element
            folderPath = ((String)newFolderComboBox.SelectedItem);

            // on deplace l'element
            Controller.MoveElem(folderPath);
        }

        #endregion
    }
}
