namespace Insta.Project.LecteurRSS
{
    partial class frmDeplacer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.frmSummaryLabel = new System.Windows.Forms.Label();
            this.frmSeparatorLabel = new System.Windows.Forms.Label();
            this.newPathLabel = new System.Windows.Forms.Label();
            this.newFolderComboBox = new System.Windows.Forms.ComboBox();
            this.AnnulerButton = new System.Windows.Forms.Button();
            this.ValiderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // frmTitleLabel
            // 
            this.frmTitleLabel.AutoSize = true;
            this.frmTitleLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmTitleLabel.Location = new System.Drawing.Point(10, 10);
            this.frmTitleLabel.Name = "frmTitleLabel";
            this.frmTitleLabel.Size = new System.Drawing.Size(111, 19);
            this.frmTitleLabel.TabIndex = 0;
            this.frmTitleLabel.Text = "Deplacer un ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Insta.Project.LecteurRSS.Properties.Resources.folder1;
            this.pictureBox1.Location = new System.Drawing.Point(396, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 68);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmSummaryLabel
            // 
            this.frmSummaryLabel.AutoSize = true;
            this.frmSummaryLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSummaryLabel.Location = new System.Drawing.Point(15, 45);
            this.frmSummaryLabel.Name = "frmSummaryLabel";
            this.frmSummaryLabel.Size = new System.Drawing.Size(76, 14);
            this.frmSummaryLabel.TabIndex = 2;
            this.frmSummaryLabel.Text = "Deplacer un ";
            // 
            // frmSeparatorLabel
            // 
            this.frmSeparatorLabel.AutoSize = true;
            this.frmSeparatorLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.frmSeparatorLabel.Location = new System.Drawing.Point(-5, 90);
            this.frmSeparatorLabel.Name = "frmSeparatorLabel";
            this.frmSeparatorLabel.Size = new System.Drawing.Size(499, 13);
            this.frmSeparatorLabel.TabIndex = 3;
            this.frmSeparatorLabel.Text = "_________________________________________________________________________________" +
                "_";
            // 
            // newPathLabel
            // 
            this.newPathLabel.AutoSize = true;
            this.newPathLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPathLabel.Location = new System.Drawing.Point(15, 125);
            this.newPathLabel.Name = "newPathLabel";
            this.newPathLabel.Size = new System.Drawing.Size(239, 14);
            this.newPathLabel.TabIndex = 4;
            this.newPathLabel.Text = "Selectionner le nouveau emplacement du ";
            // 
            // newFolderComboBox
            // 
            this.newFolderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newFolderComboBox.FormattingEnabled = true;
            this.newFolderComboBox.Location = new System.Drawing.Point(30, 150);
            this.newFolderComboBox.Name = "newFolderComboBox";
            this.newFolderComboBox.Size = new System.Drawing.Size(442, 21);
            this.newFolderComboBox.TabIndex = 5;
            this.newFolderComboBox.SelectedIndexChanged += new System.EventHandler(this.newFolderComboBox_SelectedIndexChanged);
            // 
            // AnnulerButton
            // 
            this.AnnulerButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnnulerButton.Location = new System.Drawing.Point(382, 195);
            this.AnnulerButton.Name = "AnnulerButton";
            this.AnnulerButton.Size = new System.Drawing.Size(90, 30);
            this.AnnulerButton.TabIndex = 6;
            this.AnnulerButton.Text = "Annuler";
            this.AnnulerButton.UseVisualStyleBackColor = true;
            this.AnnulerButton.Click += new System.EventHandler(this.AnnulerButton_Click);
            // 
            // ValiderButton
            // 
            this.ValiderButton.Enabled = false;
            this.ValiderButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValiderButton.Location = new System.Drawing.Point(286, 195);
            this.ValiderButton.Name = "ValiderButton";
            this.ValiderButton.Size = new System.Drawing.Size(90, 30);
            this.ValiderButton.TabIndex = 7;
            this.ValiderButton.Text = "Valider";
            this.ValiderButton.UseVisualStyleBackColor = true;
            this.ValiderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDeplacer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 239);
            this.Controls.Add(this.ValiderButton);
            this.Controls.Add(this.AnnulerButton);
            this.Controls.Add(this.newFolderComboBox);
            this.Controls.Add(this.newPathLabel);
            this.Controls.Add(this.frmSeparatorLabel);
            this.Controls.Add(this.frmSummaryLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.frmTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDeplacer";
            this.Text = "Deplacer un ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label frmTitleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label frmSummaryLabel;
        private System.Windows.Forms.Label frmSeparatorLabel;
        private System.Windows.Forms.Label newPathLabel;
        private System.Windows.Forms.ComboBox newFolderComboBox;
        private System.Windows.Forms.Button AnnulerButton;
        private System.Windows.Forms.Button ValiderButton;
    }
}