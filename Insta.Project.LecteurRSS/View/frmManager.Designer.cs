


namespace Insta.Project.LecteurRSS
{
    partial class frmManager
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (WorkerThread.IsBusy)
            {
                WorkerThread.CancelAsync();
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.TitreHeader = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NouveauMenuItemFichierMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFolderMenuItemFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewChannelMenuItemFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseMenuItemFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayToolBarMenuItemViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayExplorerMenuItemViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this._tableItems = new System.Windows.Forms.ListView();
            this.DateHeader = new System.Windows.Forms.ColumnHeader();
            this.AuteurHeader = new System.Windows.Forms.ColumnHeader();
            this.CategorieHeader = new System.Windows.Forms.ColumnHeader();
            this.TableItemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenBrowerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MaskAsReadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyLinkItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorTreeViewAndListView = new System.Windows.Forms.Splitter();
            this._treeFolders = new System.Windows.Forms.TreeView();
            this.TreeFoldersMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Nouveau2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFolder3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewChannel3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripManager = new System.Windows.Forms.ToolStrip();
            this.ButtonAddFolderAndChannel = new System.Windows.Forms.ToolStripSplitButton();
            this.NewFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewChannelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MarkAllNewsAsReadButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateChannelButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateAllChannelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelWorkerButtonToolBar = new System.Windows.Forms.ToolStripButton();
            this.TreeFoldersSelectedFolderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NouveauMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFolder2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewChannel2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.MaskNewsAsRead2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteFolderItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeFoldersSelectedChannelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MarkNewsAsRead = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteChannelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveChannelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateChannelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyLinkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerThread = new System.ComponentModel.BackgroundWorker();
            this.DisplayStatusBarMenuItemViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.TableItemMenu.SuspendLayout();
            this.TreeFoldersMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.toolStripManager.SuspendLayout();
            this.TreeFoldersSelectedFolderMenu.SuspendLayout();
            this.TreeFoldersSelectedChannelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitreHeader
            // 
            this.TitreHeader.Text = "Titre";
            this.TitreHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TitreHeader.Width = 400;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.ViewMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NouveauMenuItemFichierMenu,
            this.toolStripSeparator8,
            this.CloseMenuItemFileMenu});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(54, 20);
            this.FileMenuItem.Text = "Fichier";
            // 
            // NouveauMenuItemFichierMenu
            // 
            this.NouveauMenuItemFichierMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFolderMenuItemFileMenu,
            this.NewChannelMenuItemFileMenu});
            this.NouveauMenuItemFichierMenu.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add;
            this.NouveauMenuItemFichierMenu.Name = "NouveauMenuItemFichierMenu";
            this.NouveauMenuItemFichierMenu.Size = new System.Drawing.Size(122, 22);
            this.NouveauMenuItemFichierMenu.Text = "Nouveau";
            // 
            // NewFolderMenuItemFileMenu
            // 
            this.NewFolderMenuItemFileMenu.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add_folder;
            this.NewFolderMenuItemFileMenu.Name = "NewFolderMenuItemFileMenu";
            this.NewFolderMenuItemFileMenu.Size = new System.Drawing.Size(128, 22);
            this.NewFolderMenuItemFileMenu.Text = "Repertoire";
            this.NewFolderMenuItemFileMenu.Click += new System.EventHandler(this.NewFolderMenuItemFileMenu_Click);
            // 
            // NewChannelMenuItemFileMenu
            // 
            this.NewChannelMenuItemFileMenu.Image = ((System.Drawing.Image)(resources.GetObject("NewChannelMenuItemFileMenu.Image")));
            this.NewChannelMenuItemFileMenu.Name = "NewChannelMenuItemFileMenu";
            this.NewChannelMenuItemFileMenu.Size = new System.Drawing.Size(128, 22);
            this.NewChannelMenuItemFileMenu.Text = "Channel";
            this.NewChannelMenuItemFileMenu.Click += new System.EventHandler(this.NewChannelMenuItemFileMenu_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(119, 6);
            // 
            // CloseMenuItemFileMenu
            // 
            this.CloseMenuItemFileMenu.Name = "CloseMenuItemFileMenu";
            this.CloseMenuItemFileMenu.Size = new System.Drawing.Size(122, 22);
            this.CloseMenuItemFileMenu.Text = "Quitter";
            this.CloseMenuItemFileMenu.Click += new System.EventHandler(this.CloseMenuItemFileMenu_Click);
            // 
            // ViewMenuItem
            // 
            this.ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisplayToolBarMenuItemViewMenu,
            this.DisplayExplorerMenuItemViewMenu,
            this.DisplayStatusBarMenuItemViewMenu});
            this.ViewMenuItem.Name = "ViewMenuItem";
            this.ViewMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ViewMenuItem.Text = "Affichage";
            // 
            // DisplayToolBarMenuItemViewMenu
            // 
            this.DisplayToolBarMenuItemViewMenu.Checked = true;
            this.DisplayToolBarMenuItemViewMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayToolBarMenuItemViewMenu.Name = "DisplayToolBarMenuItemViewMenu";
            this.DisplayToolBarMenuItemViewMenu.Size = new System.Drawing.Size(173, 22);
            this.DisplayToolBarMenuItemViewMenu.Text = "Barre d\'outil";
            this.DisplayToolBarMenuItemViewMenu.Click += new System.EventHandler(this.DisplayToolBarMenuItemViewMenu_Click);
            // 
            // DisplayExplorerMenuItemViewMenu
            // 
            this.DisplayExplorerMenuItemViewMenu.Checked = true;
            this.DisplayExplorerMenuItemViewMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayExplorerMenuItemViewMenu.Name = "DisplayExplorerMenuItemViewMenu";
            this.DisplayExplorerMenuItemViewMenu.Size = new System.Drawing.Size(173, 22);
            this.DisplayExplorerMenuItemViewMenu.Text = "Volet d\'exploration";
            this.DisplayExplorerMenuItemViewMenu.Click += new System.EventHandler(this.DisplayExplorerMenuItemViewMenu_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this._tableItems);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.SeparatorTreeViewAndListView);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._treeFolders);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.StatusBar);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(800, 553);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(800, 576);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripManager);
            // 
            // _tableItems
            // 
            this._tableItems.AutoArrange = false;
            this._tableItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitreHeader,
            this.DateHeader,
            this.AuteurHeader,
            this.CategorieHeader});
            this._tableItems.ContextMenuStrip = this.TableItemMenu;
            this._tableItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableItems.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tableItems.FullRowSelect = true;
            this._tableItems.Location = new System.Drawing.Point(255, 0);
            this._tableItems.MultiSelect = false;
            this._tableItems.Name = "_tableItems";
            this._tableItems.Size = new System.Drawing.Size(545, 531);
            this._tableItems.TabIndex = 3;
            this._tableItems.UseCompatibleStateImageBehavior = false;
            this._tableItems.View = System.Windows.Forms.View.Details;
            this._tableItems.DoubleClick += new System.EventHandler(this.OnChannelDoubleClick);
            // 
            // DateHeader
            // 
            this.DateHeader.Text = "Date";
            this.DateHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DateHeader.Width = 150;
            // 
            // AuteurHeader
            // 
            this.AuteurHeader.Text = "Auteur";
            this.AuteurHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AuteurHeader.Width = 150;
            // 
            // CategorieHeader
            // 
            this.CategorieHeader.Text = "Categorie";
            this.CategorieHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CategorieHeader.Width = 150;
            // 
            // TableItemMenu
            // 
            this.TableItemMenu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TableItemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenBrowerMenuItem,
            this.toolStripSeparator3,
            this.MaskAsReadMenuItem,
            this.toolStripSeparator4,
            this.DeleteNewMenuItem,
            this.UpdateNewMenuItem,
            this.toolStripSeparator5,
            this.CopyLinkItemMenu});
            this.TableItemMenu.Name = "TableItemMenu";
            this.TableItemMenu.Size = new System.Drawing.Size(185, 132);
            // 
            // OpenBrowerMenuItem
            // 
            this.OpenBrowerMenuItem.AutoToolTip = true;
            this.OpenBrowerMenuItem.Name = "OpenBrowerMenuItem";
            this.OpenBrowerMenuItem.Size = new System.Drawing.Size(184, 22);
            this.OpenBrowerMenuItem.Text = "Ouvrir";
            this.OpenBrowerMenuItem.ToolTipText = "Ouvrir une actualité dans un navigateur";
            this.OpenBrowerMenuItem.Click += new System.EventHandler(this.OpenBrowerMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // MaskAsReadMenuItem
            // 
            this.MaskAsReadMenuItem.AutoToolTip = true;
            this.MaskAsReadMenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.mark_channel_read;
            this.MaskAsReadMenuItem.Name = "MaskAsReadMenuItem";
            this.MaskAsReadMenuItem.Size = new System.Drawing.Size(184, 22);
            this.MaskAsReadMenuItem.Text = "Marquer comme lu";
            this.MaskAsReadMenuItem.ToolTipText = "Mettre une actualité comme lue";
            this.MaskAsReadMenuItem.Click += new System.EventHandler(this.MaskAsReadMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(181, 6);
            // 
            // DeleteNewMenuItem
            // 
            this.DeleteNewMenuItem.AutoToolTip = true;
            this.DeleteNewMenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.delete;
            this.DeleteNewMenuItem.Name = "DeleteNewMenuItem";
            this.DeleteNewMenuItem.Size = new System.Drawing.Size(184, 22);
            this.DeleteNewMenuItem.Text = "Supprimer";
            this.DeleteNewMenuItem.ToolTipText = "Supprimer une actualité";
            this.DeleteNewMenuItem.Click += new System.EventHandler(this.DeleteNewMenuItem_Click);
            // 
            // UpdateNewMenuItem
            // 
            this.UpdateNewMenuItem.AutoToolTip = true;
            this.UpdateNewMenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.reload;
            this.UpdateNewMenuItem.Name = "UpdateNewMenuItem";
            this.UpdateNewMenuItem.Size = new System.Drawing.Size(184, 22);
            this.UpdateNewMenuItem.Text = "Mise à jour";
            this.UpdateNewMenuItem.ToolTipText = "Mettre à jour une channel";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(181, 6);
            // 
            // CopyLinkItemMenu
            // 
            this.CopyLinkItemMenu.AutoToolTip = true;
            this.CopyLinkItemMenu.Name = "CopyLinkItemMenu";
            this.CopyLinkItemMenu.Size = new System.Drawing.Size(184, 22);
            this.CopyLinkItemMenu.Text = "Copier le lien";
            this.CopyLinkItemMenu.ToolTipText = "Copier le lien de l\'actualité";
            this.CopyLinkItemMenu.Click += new System.EventHandler(this.CopyLinkItemMenu_Click);
            // 
            // SeparatorTreeViewAndListView
            // 
            this.SeparatorTreeViewAndListView.Location = new System.Drawing.Point(250, 0);
            this.SeparatorTreeViewAndListView.Name = "SeparatorTreeViewAndListView";
            this.SeparatorTreeViewAndListView.Size = new System.Drawing.Size(5, 531);
            this.SeparatorTreeViewAndListView.TabIndex = 2;
            this.SeparatorTreeViewAndListView.TabStop = false;
            // 
            // _treeFolders
            // 
            this._treeFolders.AllowDrop = true;
            this._treeFolders.ContextMenuStrip = this.TreeFoldersMenu;
            this._treeFolders.Dock = System.Windows.Forms.DockStyle.Left;
            this._treeFolders.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._treeFolders.FullRowSelect = true;
            this._treeFolders.ImageIndex = 0;
            this._treeFolders.ImageList = this.imageList1;
            this._treeFolders.ItemHeight = 25;
            this._treeFolders.Location = new System.Drawing.Point(0, 0);
            this._treeFolders.Name = "_treeFolders";
            this._treeFolders.PathSeparator = "/";
            this._treeFolders.SelectedImageIndex = 0;
            this._treeFolders.Size = new System.Drawing.Size(250, 531);
            this._treeFolders.TabIndex = 1;
            this._treeFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this._treeFolders_MouseClick);
            this._treeFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnNodeClick);
            // 
            // TreeFoldersMenu
            // 
            this.TreeFoldersMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nouveau2MenuItem});
            this.TreeFoldersMenu.Name = "TreeFoldersSelectedFolderMenu";
            this.TreeFoldersMenu.Size = new System.Drawing.Size(123, 26);
            // 
            // Nouveau2MenuItem
            // 
            this.Nouveau2MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFolder3MenuItem,
            this.NewChannel3MenuItem});
            this.Nouveau2MenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add;
            this.Nouveau2MenuItem.Name = "Nouveau2MenuItem";
            this.Nouveau2MenuItem.Size = new System.Drawing.Size(122, 22);
            this.Nouveau2MenuItem.Text = "Nouveau";
            // 
            // NewFolder3MenuItem
            // 
            this.NewFolder3MenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add_folder;
            this.NewFolder3MenuItem.Name = "NewFolder3MenuItem";
            this.NewFolder3MenuItem.Size = new System.Drawing.Size(128, 22);
            this.NewFolder3MenuItem.Text = "Repertoire";
            this.NewFolder3MenuItem.Click += new System.EventHandler(this.NewFolder3MenuItem_Click);
            // 
            // NewChannel3MenuItem
            // 
            this.NewChannel3MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewChannel3MenuItem.Image")));
            this.NewChannel3MenuItem.Name = "NewChannel3MenuItem";
            this.NewChannel3MenuItem.Size = new System.Drawing.Size(128, 22);
            this.NewChannel3MenuItem.Text = "Channel";
            this.NewChannel3MenuItem.Click += new System.EventHandler(this.NewChannel3MenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "stop.gif");
            this.imageList1.Images.SetKeyName(1, "add_category_pop.gif");
            this.imageList1.Images.SetKeyName(2, "add_category_small.gif");
            this.imageList1.Images.SetKeyName(3, "add_feed.gif");
            this.imageList1.Images.SetKeyName(4, "delete.gif");
            this.imageList1.Images.SetKeyName(5, "feed.gif");
            this.imageList1.Images.SetKeyName(6, "folder.gif");
            this.imageList1.Images.SetKeyName(7, "folder_unread.gif");
            this.imageList1.Images.SetKeyName(8, "Image1.gif");
            this.imageList1.Images.SetKeyName(9, "mark_feed_read.gif");
            this.imageList1.Images.SetKeyName(10, "mark_read.gif");
            this.imageList1.Images.SetKeyName(11, "next_unread.gif");
            this.imageList1.Images.SetKeyName(12, "reload_all.gif");
            this.imageList1.Images.SetKeyName(13, "reload_browser.gif");
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar});
            this.StatusBar.Location = new System.Drawing.Point(0, 531);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(800, 22);
            this.StatusBar.TabIndex = 4;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripManager
            // 
            this.toolStripManager.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonAddFolderAndChannel,
            this.toolStripSeparator1,
            this.MarkAllNewsAsReadButton,
            this.toolStripSeparator2,
            this.UpdateChannelButton,
            this.UpdateAllChannelButton,
            this.toolStripSeparator11,
            this.CancelWorkerButtonToolBar});
            this.toolStripManager.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripManager.Location = new System.Drawing.Point(3, 0);
            this.toolStripManager.Name = "toolStripManager";
            this.toolStripManager.Size = new System.Drawing.Size(703, 23);
            this.toolStripManager.TabIndex = 0;
            // 
            // ButtonAddFolderAndChannel
            // 
            this.ButtonAddFolderAndChannel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonAddFolderAndChannel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFolderMenuItem,
            this.NewChannelMenuItem});
            this.ButtonAddFolderAndChannel.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add;
            this.ButtonAddFolderAndChannel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAddFolderAndChannel.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.ButtonAddFolderAndChannel.Name = "ButtonAddFolderAndChannel";
            this.ButtonAddFolderAndChannel.Size = new System.Drawing.Size(32, 20);
            this.ButtonAddFolderAndChannel.Text = "Ajouter";
            // 
            // NewFolderMenuItem
            // 
            this.NewFolderMenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add_folder;
            this.NewFolderMenuItem.Name = "NewFolderMenuItem";
            this.NewFolderMenuItem.Size = new System.Drawing.Size(184, 22);
            this.NewFolderMenuItem.Text = "Ajouter un repertoire";
            this.NewFolderMenuItem.Click += new System.EventHandler(this.NewFolderMenuItem_Click);
            // 
            // NewChannelMenuItem
            // 
            this.NewChannelMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewChannelMenuItem.Image")));
            this.NewChannelMenuItem.Name = "NewChannelMenuItem";
            this.NewChannelMenuItem.Size = new System.Drawing.Size(184, 22);
            this.NewChannelMenuItem.Text = "Ajouter un channel";
            this.NewChannelMenuItem.Click += new System.EventHandler(this.NewChannelMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // MarkAllNewsAsReadButton
            // 
            this.MarkAllNewsAsReadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MarkAllNewsAsReadButton.Image = global::Insta.Project.LecteurRSS.Properties.Resources.mark_read;
            this.MarkAllNewsAsReadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MarkAllNewsAsReadButton.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.MarkAllNewsAsReadButton.Name = "MarkAllNewsAsReadButton";
            this.MarkAllNewsAsReadButton.Size = new System.Drawing.Size(23, 20);
            this.MarkAllNewsAsReadButton.Text = "Marquer toutes les actualités comme lues";
            this.MarkAllNewsAsReadButton.Click += new System.EventHandler(this.MarkAllNewsAsReadButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // UpdateChannelButton
            // 
            this.UpdateChannelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdateChannelButton.Image = global::Insta.Project.LecteurRSS.Properties.Resources.reload;
            this.UpdateChannelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateChannelButton.Margin = new System.Windows.Forms.Padding(10, 1, 5, 2);
            this.UpdateChannelButton.Name = "UpdateChannelButton";
            this.UpdateChannelButton.Size = new System.Drawing.Size(23, 20);
            this.UpdateChannelButton.Text = "Mise à jour du channel";
            this.UpdateChannelButton.Click += new System.EventHandler(this.UpdateChannelButton_Click);
            // 
            // UpdateAllChannelButton
            // 
            this.UpdateAllChannelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdateAllChannelButton.Image = global::Insta.Project.LecteurRSS.Properties.Resources.reload_all;
            this.UpdateAllChannelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateAllChannelButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.UpdateAllChannelButton.Name = "UpdateAllChannelButton";
            this.UpdateAllChannelButton.Size = new System.Drawing.Size(23, 20);
            this.UpdateAllChannelButton.Text = "Mise à jour de tous les channels";
            this.UpdateAllChannelButton.Click += new System.EventHandler(this.UpdateAllChannelButton_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // CancelWorkerButtonToolBar
            // 
            this.CancelWorkerButtonToolBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelWorkerButtonToolBar.Enabled = false;
            this.CancelWorkerButtonToolBar.Image = global::Insta.Project.LecteurRSS.Properties.Resources.cancel_worker;
            this.CancelWorkerButtonToolBar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelWorkerButtonToolBar.Margin = new System.Windows.Forms.Padding(10, 1, 500, 2);
            this.CancelWorkerButtonToolBar.Name = "CancelWorkerButtonToolBar";
            this.CancelWorkerButtonToolBar.Size = new System.Drawing.Size(23, 20);
            this.CancelWorkerButtonToolBar.Text = "Stoppe la mise à jour des flux RSS";
            this.CancelWorkerButtonToolBar.Click += new System.EventHandler(this.CancelWorkerButtonToolBar_Click);
            // 
            // TreeFoldersSelectedFolderMenu
            // 
            this.TreeFoldersSelectedFolderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NouveauMenuItem,
            this.toolStripSeparator9,
            this.MaskNewsAsRead2MenuItem,
            this.toolStripSeparator10,
            this.DeleteFolderItemMenu,
            this.MoveFolderMenuItem});
            this.TreeFoldersSelectedFolderMenu.Name = "TreeFoldersMenu";
            this.TreeFoldersSelectedFolderMenu.Size = new System.Drawing.Size(180, 104);
            // 
            // NouveauMenuItem
            // 
            this.NouveauMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFolder2MenuItem,
            this.NewChannel2MenuItem});
            this.NouveauMenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add;
            this.NouveauMenuItem.Name = "NouveauMenuItem";
            this.NouveauMenuItem.Size = new System.Drawing.Size(179, 22);
            this.NouveauMenuItem.Text = "Nouveau";
            // 
            // NewFolder2MenuItem
            // 
            this.NewFolder2MenuItem.AutoToolTip = true;
            this.NewFolder2MenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.add_folder;
            this.NewFolder2MenuItem.Name = "NewFolder2MenuItem";
            this.NewFolder2MenuItem.Size = new System.Drawing.Size(128, 22);
            this.NewFolder2MenuItem.Text = "Repertoire";
            this.NewFolder2MenuItem.ToolTipText = "Ajouter un nouveau repertoire";
            this.NewFolder2MenuItem.Click += new System.EventHandler(this.NewFolder2MenuItem_Click);
            // 
            // NewChannel2MenuItem
            // 
            this.NewChannel2MenuItem.AutoToolTip = true;
            this.NewChannel2MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewChannel2MenuItem.Image")));
            this.NewChannel2MenuItem.Name = "NewChannel2MenuItem";
            this.NewChannel2MenuItem.Size = new System.Drawing.Size(128, 22);
            this.NewChannel2MenuItem.Text = "Channel";
            this.NewChannel2MenuItem.ToolTipText = "Ajouter un nouveau channel";
            this.NewChannel2MenuItem.Click += new System.EventHandler(this.NewChannel2MenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(176, 6);
            // 
            // MaskNewsAsRead2MenuItem
            // 
            this.MaskNewsAsRead2MenuItem.AutoToolTip = true;
            this.MaskNewsAsRead2MenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.mark_read;
            this.MaskNewsAsRead2MenuItem.Name = "MaskNewsAsRead2MenuItem";
            this.MaskNewsAsRead2MenuItem.Size = new System.Drawing.Size(179, 22);
            this.MaskNewsAsRead2MenuItem.Text = "Marquer comme lu ";
            this.MaskNewsAsRead2MenuItem.ToolTipText = "tous les channels du repertoire";
            this.MaskNewsAsRead2MenuItem.Click += new System.EventHandler(this.MaskNewsAsRead2MenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(176, 6);
            // 
            // DeleteFolderItemMenu
            // 
            this.DeleteFolderItemMenu.AutoToolTip = true;
            this.DeleteFolderItemMenu.Image = global::Insta.Project.LecteurRSS.Properties.Resources.delete;
            this.DeleteFolderItemMenu.Name = "DeleteFolderItemMenu";
            this.DeleteFolderItemMenu.Size = new System.Drawing.Size(179, 22);
            this.DeleteFolderItemMenu.Text = "Supprimer";
            this.DeleteFolderItemMenu.ToolTipText = "Supprimer le repertoire";
            this.DeleteFolderItemMenu.Click += new System.EventHandler(this.DeleteFolderItemMenu_Click);
            // 
            // MoveFolderMenuItem
            // 
            this.MoveFolderMenuItem.AutoToolTip = true;
            this.MoveFolderMenuItem.Name = "MoveFolderMenuItem";
            this.MoveFolderMenuItem.Size = new System.Drawing.Size(179, 22);
            this.MoveFolderMenuItem.Text = "Deplacer";
            this.MoveFolderMenuItem.ToolTipText = "Deplace un repertoire";
            this.MoveFolderMenuItem.Click += new System.EventHandler(this.MoveFolderMenuItem_Click);
            // 
            // TreeFoldersSelectedChannelMenu
            // 
            this.TreeFoldersSelectedChannelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MarkNewsAsRead,
            this.toolStripSeparator6,
            this.DeleteChannelMenuItem,
            this.MoveChannelMenuItem,
            this.toolStripSeparator12,
            this.UpdateChannelMenuItem,
            this.toolStripSeparator7,
            this.CopyLinkMenuItem});
            this.TreeFoldersSelectedChannelMenu.Name = "TreeFoldersSelectedChannelMenu";
            this.TreeFoldersSelectedChannelMenu.Size = new System.Drawing.Size(177, 132);
            // 
            // MarkNewsAsRead
            // 
            this.MarkNewsAsRead.AutoToolTip = true;
            this.MarkNewsAsRead.Image = global::Insta.Project.LecteurRSS.Properties.Resources.mark_read;
            this.MarkNewsAsRead.Name = "MarkNewsAsRead";
            this.MarkNewsAsRead.Size = new System.Drawing.Size(176, 22);
            this.MarkNewsAsRead.Text = "Marquer comme lu";
            this.MarkNewsAsRead.ToolTipText = "Marquer toutes les actualités comme lues";
            this.MarkNewsAsRead.Click += new System.EventHandler(this.MarkNewsAsRead_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(173, 6);
            // 
            // DeleteChannelMenuItem
            // 
            this.DeleteChannelMenuItem.AutoToolTip = true;
            this.DeleteChannelMenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.delete;
            this.DeleteChannelMenuItem.Name = "DeleteChannelMenuItem";
            this.DeleteChannelMenuItem.Size = new System.Drawing.Size(176, 22);
            this.DeleteChannelMenuItem.Text = "Supprimer";
            this.DeleteChannelMenuItem.ToolTipText = "Supprimer le channel";
            this.DeleteChannelMenuItem.Click += new System.EventHandler(this.DeleteChannelMenuItem_Click);
            // 
            // MoveChannelMenuItem
            // 
            this.MoveChannelMenuItem.Name = "MoveChannelMenuItem";
            this.MoveChannelMenuItem.Size = new System.Drawing.Size(176, 22);
            this.MoveChannelMenuItem.Text = "Deplacer";
            this.MoveChannelMenuItem.ToolTipText = "Deplacer un channel";
            this.MoveChannelMenuItem.Click += new System.EventHandler(this.MoveChannelMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(173, 6);
            // 
            // UpdateChannelMenuItem
            // 
            this.UpdateChannelMenuItem.AutoToolTip = true;
            this.UpdateChannelMenuItem.Image = global::Insta.Project.LecteurRSS.Properties.Resources.reload;
            this.UpdateChannelMenuItem.Name = "UpdateChannelMenuItem";
            this.UpdateChannelMenuItem.Size = new System.Drawing.Size(176, 22);
            this.UpdateChannelMenuItem.Text = "Mise à jour";
            this.UpdateChannelMenuItem.ToolTipText = "Met à jour les actualités du channel";
            this.UpdateChannelMenuItem.Click += new System.EventHandler(this.UpdateChannelMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(173, 6);
            // 
            // CopyLinkMenuItem
            // 
            this.CopyLinkMenuItem.AutoToolTip = true;
            this.CopyLinkMenuItem.Name = "CopyLinkMenuItem";
            this.CopyLinkMenuItem.Size = new System.Drawing.Size(176, 22);
            this.CopyLinkMenuItem.Text = "Copier le lien";
            this.CopyLinkMenuItem.ToolTipText = "Copie le lien du channel";
            this.CopyLinkMenuItem.Click += new System.EventHandler(this.CopyLinkMenuItem_Click);
            // 
            // WorkerThread
            // 
            this.WorkerThread.WorkerReportsProgress = true;
            this.WorkerThread.WorkerSupportsCancellation = true;
            this.WorkerThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerThread_DoWork);
            this.WorkerThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerThread_RunWorkerCompleted);
            this.WorkerThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WorkerThread_ProgressChanged);
            // 
            // DisplayStatusBarMenuItemViewMenu
            // 
            this.DisplayStatusBarMenuItemViewMenu.Checked = true;
            this.DisplayStatusBarMenuItemViewMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DisplayStatusBarMenuItemViewMenu.Name = "DisplayStatusBarMenuItemViewMenu";
            this.DisplayStatusBarMenuItemViewMenu.Size = new System.Drawing.Size(173, 22);
            this.DisplayStatusBarMenuItemViewMenu.Text = "Barre d\'état";
            this.DisplayStatusBarMenuItemViewMenu.Click += new System.EventHandler(this.DisplayStatusBarMenuItemViewMenu_Click);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmManager";
            this.Text = "Lecteur RSS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.TableItemMenu.ResumeLayout(false);
            this.TreeFoldersMenu.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.toolStripManager.ResumeLayout(false);
            this.toolStripManager.PerformLayout();
            this.TreeFoldersSelectedFolderMenu.ResumeLayout(false);
            this.TreeFoldersSelectedChannelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStripManager;
        private System.Windows.Forms.ToolStripSplitButton ButtonAddFolderAndChannel;
        private System.Windows.Forms.ToolStripMenuItem NewFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewChannelMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MarkAllNewsAsReadButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton UpdateChannelButton;
        private System.Windows.Forms.ToolStripButton UpdateAllChannelButton;
        private System.Windows.Forms.Splitter SeparatorTreeViewAndListView;
        private System.Windows.Forms.TreeView _treeFolders;
        private System.Windows.Forms.ListView _tableItems;
        private System.Windows.Forms.ColumnHeader DateHeader;
        private System.Windows.Forms.ColumnHeader AuteurHeader;
        private System.Windows.Forms.ColumnHeader CategorieHeader;
        private System.Windows.Forms.ContextMenuStrip TableItemMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenBrowerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MaskAsReadMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem DeleteNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateNewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem CopyLinkItemMenu;
        private System.Windows.Forms.ContextMenuStrip TreeFoldersSelectedChannelMenu;
        private System.Windows.Forms.ToolStripMenuItem MarkNewsAsRead;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem DeleteChannelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateChannelMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem CopyLinkMenuItem;
        private System.Windows.Forms.ContextMenuStrip TreeFoldersSelectedFolderMenu;
        private System.Windows.Forms.ToolStripMenuItem NouveauMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFolder2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewChannel2MenuItem;
        private System.Windows.Forms.ContextMenuStrip TreeFoldersMenu;
        private System.Windows.Forms.ToolStripMenuItem Nouveau2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFolder3MenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewChannel3MenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem MaskNewsAsRead2MenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem DeleteFolderItemMenu;
        private System.Windows.Forms.ColumnHeader TitreHeader;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NouveauMenuItemFichierMenu;
        private System.Windows.Forms.ToolStripMenuItem NewFolderMenuItemFileMenu;
        private System.Windows.Forms.ToolStripMenuItem NewChannelMenuItemFileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItemFileMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayToolBarMenuItemViewMenu;
        private System.Windows.Forms.ToolStripMenuItem DisplayExplorerMenuItemViewMenu;
        private System.Windows.Forms.ToolStripMenuItem MoveFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveChannelMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.ComponentModel.BackgroundWorker WorkerThread;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton CancelWorkerButtonToolBar;
        private System.Windows.Forms.ToolStripMenuItem DisplayStatusBarMenuItemViewMenu;

    }
}

