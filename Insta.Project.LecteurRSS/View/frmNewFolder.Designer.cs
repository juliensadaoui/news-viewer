namespace Insta.Project.LecteurRSS
{
    partial class frmNewFolder
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
            this.frmTitleLabel = new System.Windows.Forms.Label();
            this.frmSummaryLabel = new System.Windows.Forms.Label();
            this.SeparatorLabel = new System.Windows.Forms.Label();
            this.NameNewFolderLabel = new System.Windows.Forms.Label();
            this.NameNewFolderEditBox = new System.Windows.Forms.TextBox();
            this.LocationFolderLabel = new System.Windows.Forms.Label();
            this.LocationFolderComboBox = new System.Windows.Forms.ComboBox();
            this.AnnulerButton = new System.Windows.Forms.Button();
            this.AjouterButton = new System.Windows.Forms.Button();
            this.frmImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.frmImage)).BeginInit();
            this.SuspendLayout();
            // 
            // frmTitleLabel
            // 
            this.frmTitleLabel.AutoSize = true;
            this.frmTitleLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmTitleLabel.Location = new System.Drawing.Point(10, 10);
            this.frmTitleLabel.Name = "frmTitleLabel";
            this.frmTitleLabel.Size = new System.Drawing.Size(97, 19);
            this.frmTitleLabel.TabIndex = 0;
            this.frmTitleLabel.Text = "Repertoire";
            // 
            // frmSummaryLabel
            // 
            this.frmSummaryLabel.AutoSize = true;
            this.frmSummaryLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSummaryLabel.Location = new System.Drawing.Point(15, 45);
            this.frmSummaryLabel.Name = "frmSummaryLabel";
            this.frmSummaryLabel.Size = new System.Drawing.Size(314, 14);
            this.frmSummaryLabel.TabIndex = 1;
            this.frmSummaryLabel.Text = "Creer un nouveau repertoire contenant des canaux RSS";
            // 
            // SeparatorLabel
            // 
            this.SeparatorLabel.AutoSize = true;
            this.SeparatorLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.SeparatorLabel.Location = new System.Drawing.Point(-9, 90);
            this.SeparatorLabel.Name = "SeparatorLabel";
            this.SeparatorLabel.Size = new System.Drawing.Size(565, 13);
            this.SeparatorLabel.TabIndex = 2;
            this.SeparatorLabel.Text = "_________________________________________________________________________________" +
                "____________";
            // 
            // NameNewFolderLabel
            // 
            this.NameNewFolderLabel.AutoSize = true;
            this.NameNewFolderLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameNewFolderLabel.Location = new System.Drawing.Point(10, 125);
            this.NameNewFolderLabel.Name = "NameNewFolderLabel";
            this.NameNewFolderLabel.Size = new System.Drawing.Size(150, 14);
            this.NameNewFolderLabel.TabIndex = 4;
            this.NameNewFolderLabel.Text = "Saisir le nom du repertoire";
            // 
            // NameNewFolderEditBox
            // 
            this.NameNewFolderEditBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameNewFolderEditBox.Location = new System.Drawing.Point(30, 150);
            this.NameNewFolderEditBox.Name = "NameNewFolderEditBox";
            this.NameNewFolderEditBox.Size = new System.Drawing.Size(440, 22);
            this.NameNewFolderEditBox.TabIndex = 5;
            this.NameNewFolderEditBox.TextChanged += new System.EventHandler(this.NameFolder_OnTextChanged);
            // 
            // LocationFolderLabel
            // 
            this.LocationFolderLabel.AutoSize = true;
            this.LocationFolderLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationFolderLabel.Location = new System.Drawing.Point(15, 185);
            this.LocationFolderLabel.Name = "LocationFolderLabel";
            this.LocationFolderLabel.Size = new System.Drawing.Size(192, 14);
            this.LocationFolderLabel.TabIndex = 6;
            this.LocationFolderLabel.Text = "Saisir l\'emplacement du repertoire";
            // 
            // LocationFolderComboBox
            // 
            this.LocationFolderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationFolderComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationFolderComboBox.FormattingEnabled = true;
            this.LocationFolderComboBox.Location = new System.Drawing.Point(30, 210);
            this.LocationFolderComboBox.Name = "LocationFolderComboBox";
            this.LocationFolderComboBox.Size = new System.Drawing.Size(442, 22);
            this.LocationFolderComboBox.TabIndex = 7;
            this.LocationFolderComboBox.SelectedIndexChanged += new System.EventHandler(this.LocationFolder_OnSelectedChanged);
            // 
            // AnnulerButton
            // 
            this.AnnulerButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnnulerButton.Location = new System.Drawing.Point(382, 260);
            this.AnnulerButton.Name = "AnnulerButton";
            this.AnnulerButton.Size = new System.Drawing.Size(90, 30);
            this.AnnulerButton.TabIndex = 8;
            this.AnnulerButton.Text = "Annuler";
            this.AnnulerButton.UseVisualStyleBackColor = true;
            this.AnnulerButton.Click += new System.EventHandler(this.AnnulerButton_Click);
            // 
            // AjouterButton
            // 
            this.AjouterButton.Enabled = false;
            this.AjouterButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AjouterButton.Location = new System.Drawing.Point(286, 260);
            this.AjouterButton.Name = "AjouterButton";
            this.AjouterButton.Size = new System.Drawing.Size(90, 30);
            this.AjouterButton.TabIndex = 9;
            this.AjouterButton.Text = "Ajouter";
            this.AjouterButton.UseVisualStyleBackColor = true;
            this.AjouterButton.Click += new System.EventHandler(this.AjouterButton_Click);
            // 
            // frmImage
            // 
            this.frmImage.Image = global::Insta.Project.LecteurRSS.Properties.Resources.folder1;
            this.frmImage.Location = new System.Drawing.Point(397, 10);
            this.frmImage.Name = "frmImage";
            this.frmImage.Size = new System.Drawing.Size(75, 65);
            this.frmImage.TabIndex = 3;
            this.frmImage.TabStop = false;
            // 
            // frmNewFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 304);
            this.Controls.Add(this.AjouterButton);
            this.Controls.Add(this.AnnulerButton);
            this.Controls.Add(this.LocationFolderComboBox);
            this.Controls.Add(this.LocationFolderLabel);
            this.Controls.Add(this.NameNewFolderEditBox);
            this.Controls.Add(this.NameNewFolderLabel);
            this.Controls.Add(this.frmImage);
            this.Controls.Add(this.SeparatorLabel);
            this.Controls.Add(this.frmSummaryLabel);
            this.Controls.Add(this.frmTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNewFolder";
            this.ShowInTaskbar = false;
            this.Text = "Nouveau Repertoire";
            ((System.ComponentModel.ISupportInitialize)(this.frmImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label frmTitleLabel;
        private System.Windows.Forms.Label frmSummaryLabel;
        private System.Windows.Forms.Label SeparatorLabel;
        private System.Windows.Forms.PictureBox frmImage;
        private System.Windows.Forms.Label NameNewFolderLabel;
        private System.Windows.Forms.TextBox NameNewFolderEditBox;
        private System.Windows.Forms.Label LocationFolderLabel;
        private System.Windows.Forms.ComboBox LocationFolderComboBox;
        private System.Windows.Forms.Button AnnulerButton;
        private System.Windows.Forms.Button AjouterButton;
    }
}