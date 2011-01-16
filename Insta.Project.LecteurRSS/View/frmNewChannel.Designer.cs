namespace Insta.Project.LecteurRSS
{
    partial class frmNewChannel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewChannel));
            this.frmSummary = new System.Windows.Forms.Label();
            this.AnnulerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameChannelLabel = new System.Windows.Forms.Label();
            this.NameChannelTextBox = new System.Windows.Forms.TextBox();
            this.LinkChannelLabel = new System.Windows.Forms.Label();
            this.AjouterButton = new System.Windows.Forms.Button();
            this.FolderComboBox = new System.Windows.Forms.ComboBox();
            this.frmTitleLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LinkChannelTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // frmSummary
            // 
            this.frmSummary.AutoSize = true;
            this.frmSummary.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSummary.Location = new System.Drawing.Point(15, 45);
            this.frmSummary.Name = "frmSummary";
            this.frmSummary.Size = new System.Drawing.Size(336, 14);
            this.frmSummary.TabIndex = 0;
            this.frmSummary.Text = "Créer un nouveau canal pour lire les actualités d\'un site web";
            // 
            // AnnulerButton
            // 
            this.AnnulerButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnnulerButton.Location = new System.Drawing.Point(379, 320);
            this.AnnulerButton.Name = "AnnulerButton";
            this.AnnulerButton.Size = new System.Drawing.Size(90, 30);
            this.AnnulerButton.TabIndex = 2;
            this.AnnulerButton.Text = "Annuler";
            this.AnnulerButton.UseVisualStyleBackColor = true;
            this.AnnulerButton.Click += new System.EventHandler(this.AnnulerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(-7, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "_________________________________________________________________________________" +
                "___________";
            // 
            // NameChannelLabel
            // 
            this.NameChannelLabel.AutoSize = true;
            this.NameChannelLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameChannelLabel.Location = new System.Drawing.Point(10, 125);
            this.NameChannelLabel.Name = "NameChannelLabel";
            this.NameChannelLabel.Size = new System.Drawing.Size(163, 16);
            this.NameChannelLabel.TabIndex = 5;
            this.NameChannelLabel.Text = "Saisir le nom du canal RSS";
            // 
            // NameChannelTextBox
            // 
            this.NameChannelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameChannelTextBox.Location = new System.Drawing.Point(30, 150);
            this.NameChannelTextBox.Name = "NameChannelTextBox";
            this.NameChannelTextBox.Size = new System.Drawing.Size(438, 21);
            this.NameChannelTextBox.TabIndex = 6;
            this.NameChannelTextBox.TextChanged += new System.EventHandler(this.OnTextChangedNameRSS);
            // 
            // LinkChannelLabel
            // 
            this.LinkChannelLabel.AutoSize = true;
            this.LinkChannelLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkChannelLabel.Location = new System.Drawing.Point(10, 185);
            this.LinkChannelLabel.Name = "LinkChannelLabel";
            this.LinkChannelLabel.Size = new System.Drawing.Size(217, 16);
            this.LinkChannelLabel.TabIndex = 7;
            this.LinkChannelLabel.Text = "Saisir le lien web (url) du Canal RSS";
            // 
            // AjouterButton
            // 
            this.AjouterButton.Enabled = false;
            this.AjouterButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AjouterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AjouterButton.Location = new System.Drawing.Point(282, 320);
            this.AjouterButton.Name = "AjouterButton";
            this.AjouterButton.Size = new System.Drawing.Size(90, 30);
            this.AjouterButton.TabIndex = 9;
            this.AjouterButton.Text = "Ajouter ";
            this.AjouterButton.UseVisualStyleBackColor = true;
            this.AjouterButton.Click += new System.EventHandler(this.AjouterButton_Click);
            // 
            // FolderComboBox
            // 
            this.FolderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FolderComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderComboBox.FormattingEnabled = true;
            this.FolderComboBox.Location = new System.Drawing.Point(30, 270);
            this.FolderComboBox.Name = "FolderComboBox";
            this.FolderComboBox.Size = new System.Drawing.Size(438, 22);
            this.FolderComboBox.TabIndex = 11;
            this.FolderComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedChangedFolder);
            // 
            // frmTitleLabel
            // 
            this.frmTitleLabel.AutoSize = true;
            this.frmTitleLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmTitleLabel.Location = new System.Drawing.Point(10, 10);
            this.frmTitleLabel.Name = "frmTitleLabel";
            this.frmTitleLabel.Size = new System.Drawing.Size(92, 19);
            this.frmTitleLabel.TabIndex = 4;
            this.frmTitleLabel.Text = "Canal RSS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Saisir le repertoire du canal";
            // 
            // LinkChannelTextBox
            // 
            this.LinkChannelTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkChannelTextBox.Location = new System.Drawing.Point(30, 210);
            this.LinkChannelTextBox.Name = "LinkChannelTextBox";
            this.LinkChannelTextBox.Size = new System.Drawing.Size(438, 22);
            this.LinkChannelTextBox.TabIndex = 12;
            this.LinkChannelTextBox.TextChanged += new System.EventHandler(this.OnTextChangedLienRSS);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(392, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 75);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmNewChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 364);
            this.Controls.Add(this.LinkChannelTextBox);
            this.Controls.Add(this.FolderComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AjouterButton);
            this.Controls.Add(this.LinkChannelLabel);
            this.Controls.Add(this.NameChannelTextBox);
            this.Controls.Add(this.NameChannelLabel);
            this.Controls.Add(this.frmTitleLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnnulerButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.frmSummary);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNewChannel";
            this.ShowInTaskbar = false;
            this.Text = "Nouveau Canal RSS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label frmSummary;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AnnulerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameChannelLabel;
        private System.Windows.Forms.TextBox NameChannelTextBox;
        private System.Windows.Forms.Label LinkChannelLabel;
        private System.Windows.Forms.Button AjouterButton;
        private System.Windows.Forms.ComboBox FolderComboBox;
        private System.Windows.Forms.Label frmTitleLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LinkChannelTextBox;
    }
}