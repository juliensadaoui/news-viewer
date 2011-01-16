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
    /// Frame de l'interface graphique principale
    /// </summary>
    public partial class frmManager : Form
    {
        #region -- Listview: Liste des articles d'un canal RSS --

        private System.Windows.Forms.ListView ItemsTable
        {
            get { return _tableItems; }
            set { _tableItems = value; }
        }

        #endregion

        #region -- Treeview: Arbre des repertoires et des canaux RSS --

        private System.Windows.Forms.TreeView FoldersTree
        {
            get { return _treeFolders; }
            set { _treeFolders = value; }
        }

        #endregion

        #region -- Controller de la frame principale --

        private frmManagerController _controller;

        public frmManagerController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// Instancie une nouvelle frame.
        /// </summary>
        public frmManager()
        {
            InitializeComponent();
            Controller = new frmManagerController(this);
        }

        /// <summary>
        /// Méthode chargé à la creation de la frame.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            Controller.Load();
            WorkerThread.RunWorkerAsync();
        }

        #endregion

        #region -- Methode du TreeView --

        /// <summary>
        /// Genere une nouvelle treeview (arbre graphique) de repertoires
        ///  et de canaux rss. Une treeview est la representation graphique
        ///  des arbres des repertoires du model de l'application.
        /// </summary>
        public void UpdateTreeView(SyndicationFolder folderRoot)
        {
            // on vide les elements de la treeview actuelle
            FoldersTree.Nodes.Clear();

            // genere une nouvelle treeview
            UpdateTreeView(folderRoot, FoldersTree.Nodes);
        }
        
        /// <summary>
        /// Ajoute un node "noeud" associé à un repertoire et tous les nodes fils
        ///     de ce repertoire, c'est-à-dire les sous-repertoires et tous 
        ///     les canaux RSS du repertoires et de ces sous-repertoires.
        /// </summary>
        /// <param name="folderRoot">repertoire associé au node</param>
        /// <param name="nodes">node pere du repertoire</param>
        public void UpdateTreeView(SyndicationFolder folderParent, TreeNodeCollection nodes)
        {
            // creation des nodes associés au sous-repertoire de ce repertoire.
            foreach (SyndicationFolder folder in folderParent.SubFolders)
            {
                UpdateTreeView(folder, AddNode(nodes, folder).Nodes);
            }

            // creation des nodes associés aux canaux RSS du repertoires
            foreach (Channel channel in folderParent.Channels)
            {
                AddNode(nodes, channel);
            }
        }

        /// <summary>
        /// Met à jour le texte de tous les nodes (noeud) de la treeview.
        /// </summary>
        /// <param name="folderParent">Repertoire associé au node racine</param>
        public void UpdateTreeViewText(SyndicationFolder folderParent)
        {
            UpdateTreeViewText(folderParent, FoldersTree.Nodes);
        }

        /// <summary>
        /// Supprimer un node (noeud) de la treeview
        /// </summary>
        /// <param name="folder">clé du noeud à supprimer</param>
        public void RemoveTreeViewNode(String key)
        {
            TreeNode node = GetNode(key);
            if (node != null) {
                node.Remove();
            }
        }

        /// <summary>
        /// Ajoute un nouveau node (noeud) à la treeview 
        /// </summary>
        /// <param name="key">clé de la node parent</param>
        /// <param name="folder">repertoire associé à la nouvelle node</param>
        public void AddTreeViewNode(SyndicationFolder folder)
        {
            // INIT
            SyndicationFolder parent = null;
            String key = null;
            TreeNode node = null;

            parent = folder.Parent;
            if (parent.IsRoot) { /* Fix Bug pour la recup du node racine */
                AddNode(FoldersTree.Nodes, folder);
            }
            else {
                key = parent.Path;

                // recupere le node parent associé à ce nouveau repertoire
                node = GetNode(key);

                // ajoute le repertoire dans la treeview
                AddNode(node.Nodes, folder);
            } 
        }

        /// <summary>
        /// Ajoute un nouveau node (noeud) à la treeview 
        /// </summary>
        /// <param name="key">clé de la node parent</param>
        /// <param name="channel">channel associé à la nouvelle node</param>
        public void AddTreeViewNode(Channel channel)
        {
            // INIT
            SyndicationFolder parent = null;
            String key = null;
            TreeNode node = null;

            parent = channel.Parent;
            if (parent.IsRoot) { /* Fix Bug pour la recup du node racine */
                AddNode(FoldersTree.Nodes, channel);
            }
            else {
                key = parent.Path;

                // recupere le node parent associé à ce nouveau repertoire
                node = GetNode(key);

                // ajoute le repertoire dans la treeview
                AddNode(node.Nodes, channel);
            }
        }

        /// <summary>
        /// Retourne le node (noeud) de la treeview correspondant 
        ///  à la clé spécifié en parametre
        /// </summary>
        /// <param name="key">clé du noeud</param>
        public TreeNode GetNode(String key)
        {
            // DECLARATION
            int startIndex;
            int endIndex;
            TreeNode node;

            // INITIALISATION
            startIndex = 0;
            endIndex = 0;
            node = null;

            do 
            {
                startIndex = endIndex;
                endIndex = key.IndexOf('/', startIndex + 1);

                if (endIndex != -1) {
                    if (startIndex == 0)  {
                        node = FoldersTree.Nodes[key.Substring(0, endIndex)];
                    }
                    else {
                        node = node.Nodes[key.Substring(0, endIndex)];
                    }
                }
                else {
                    if (startIndex == 0) {
                        node = FoldersTree.Nodes[key.Substring(0, key.Length)];
                    }
                    else {
                        node = node.Nodes[key.Substring(0, key.Length)];
                    }
                }
            }
            while (endIndex != -1);

            return node;
        }
        

        /// <summary>
        /// Met à jour le texte d'un collection (liste) de node ainsi que 
        ///  tous les nodes fils de cette collection
        /// </summary>
        /// <param name="folderParent">repertoire associé à cette collection</param>
        /// <param name="nodes">collection de nodes (noeud)</param>
        private void UpdateTreeViewText(SyndicationFolder folderParent, TreeNodeCollection nodes)
        {
            TreeNode node;

            // update du des nodes associés au sous-repertoire de ce repertoire.
            foreach (SyndicationFolder folder in folderParent.SubFolders)
            {
                node = nodes[folder.Path];
                SetNodeText(node, folder);
                UpdateTreeViewText(folder, node.Nodes);
            }

            // update du texte des nodes associés aux canaux RSS du repertoires
            foreach (Channel channel in folderParent.Channels)
            {
                node = nodes[channel.Path];
                SetNodeText (node, channel);
            }
        }

        /// <summary>
        /// Ajoute un node channel dans le treeview. Le treeview representre
        ///   l'arbre des repertoires sous forme graphique.
        /// </summary>
        /// <param name="nodesFolder"></param>
        /// <param name="channel"></param>
        private void AddNode(TreeNodeCollection nodeFolder, Channel channel)
        {
            // INITAILISATION
            TreeNode node = new TreeNode();

            // text de la node
            SetNodeText(node, channel);

            // informations complementaires sur la node
            node.Tag = "Channel";

            // image associé à la node
            node.ImageIndex = 5;
            node.SelectedImageIndex = 5;

            // menu associé à la node
            node.ContextMenuStrip = TreeFoldersSelectedChannelMenu;
           //node.ContextMenuStrip.Show();

            // ajoute la node à la treeview
            nodeFolder.Add(node);
        }

        /// <summary>
        /// Modifie le texte d'un node de type channel de la treeview
        /// </summary>
        /// <param name="node">node associé au channel</param>
        /// <param name="channel">channel associé à la node</param>
        private void SetNodeText(TreeNode node, Channel channel)
        {
            // INITIALISATION
            int unreadItemCount;

            // nom du node
            node.Name = channel.Path;
            
            // texte afficher sur le node
            node.Text = channel.Title;
            if (channel.Title == null)
            {
                node.Text = channel.Name;
            }

            // police de font du node
            node.NodeFont = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            unreadItemCount = channel.UnreadItemCount;
            if (unreadItemCount != 0) {
                node.Text += " (" + unreadItemCount + ")";
                node.NodeFont = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            // texte de l'aide contextuel
            node.ToolTipText = node.Text;
        }

        /// <summary>
        /// Ajoute un node folder dans le treeview. Le treeview representre
        ///   l'arbre des repertoires sous forme graphique.
        /// </summary>
        /// <param name="nodesFolder"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        public TreeNode AddNode(TreeNodeCollection nodeFolder, SyndicationFolder folder)
        {
            TreeNode node = new TreeNode();

            // text de la node
            SetNodeText(node, folder);

            // informations complementaires sur la node
            node.Tag = "Folder";

            // image associé à la node
            node.ImageIndex = 6;
            node.SelectedImageIndex = 6;

            // menu associé à la node
            node.ContextMenuStrip = TreeFoldersSelectedFolderMenu;

            // ajoute la node à la treeview
            nodeFolder.Add(node);

            return node;
        }

        /// <summary>
        /// Modifie le texte d'un node de type folder de la treeview
        /// </summary>
        /// <param name="node">node à modifier</param>
        /// <param name="folder">repertoire associé à la node</param>
        public void SetNodeText(TreeNode node, SyndicationFolder folder)
        {
            // INITIALISATION
            int totalUnreadItemCount = 0;

            // modifie le nom de la node
            node.Name = folder.Path;

            // modifie le texte de la node
            node.Text = folder.Name;

            // modifie la police du texte
            node.NodeFont = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            totalUnreadItemCount = folder.TotalUnreadItemCount;
            if (totalUnreadItemCount != 0) {
                node.Text += " (" + totalUnreadItemCount + ")";
                node.NodeFont = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            // text de l'aide contextuel
            node.ToolTipText = node.Text;
        }

        #endregion

        #region -- Méthodes du ListView --

        /// <summary>
        /// Genere une nouvelle listview d'articles d'un canal RSS
        /// </summary>
        /// <param name="items">articles du canal RSS</param>
        public void UpdateListView(IEnumerable<Item> items)
        {
            if (items == null)
                return;

            // DECLARATION
            int index = 0; // index des lignes de la listview

            // on vide la listview: supression de toutes les lignes
            ClearListView();

            // on ajoute chaque article du canal RSS de la listview
            foreach (Item item in items)
            {
                AddLine(item, index++);
            }            
        }

        /// <summary>
        /// Supprime une ligne de la listview.
        /// </summary>
        /// <param name="key">clé identifiant la ligne</param>
        public void RemoveListViewLine(String key)
        {
            ListViewItem line = ItemsTable.Items[key];
            if (line != null) {
                ItemsTable.Items.Remove(line);
            }
        }

        /// <summary>
        /// Supprimer toutes les lignes de la listview
        /// </summary>
        public void ClearListView()
        {
            ItemsTable.Items.Clear();
        }

        /// <summary>
        /// Ajoute une nouvelle ligne de la listview. La listview contient
        ///  l'ensemble des articles (actualité) d'un canal RSS. La listView 
        ///  affiche les informations suivants : 
        ///    - le titre de l'actualité
        ///    - la date de publication
        ///    - l'auteur de cette actualité
        ///    - le type de catégorie de l'actuatilé
        /// </summary>
        /// <param name="item">article à ajouter</param>
        /// <param name="index">index de la ligne</param>
        private void AddLine(Item item, int index)
        {
            // DECLARATION
            ListViewItem line;
            String[] lineData;
            int length;
            Font lineFont;

            // INITIALISATION
            length = ItemsTable.Columns.Count;
            lineData = new String[length];
            lineFont = null;
            line = null;

            // creation d'une ligne de données pour la listview
            lineData[0] = item.Title;      // titre de l'actualité
            lineData[1] = item.PubDate;    // date de publication
            lineData[2] = "";// item.Authors[0]; // auteur de l'article
            lineData[3] = item.Category;   // type de categorie
            line = new ListViewItem(lineData);

            // on ajoute des informations à la ligne correspondant
            //  à l'article: lien web vers l'actualité.
            line.Name = item.Guid;
            line.Text = item.Title;
            line.Tag = item.Guid;

            // on modifie la couleur d'arriere plan en alternant 
            //  pour chaque ligne de la façon suivant:
            //      - ligne pair en "White"
            //      - ligne impair en "WhiteSmoke"
            if ((index % 2) != 0)
            {
                line.BackColor = Color.WhiteSmoke;
            }

            // police de la ligne
            lineFont = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (!item.IsRead)
            {
                lineFont = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            line.Font = lineFont;

            // on ajoute la ligne à la listview
            ItemsTable.Items.Add(line);

        }

        #endregion

        #region -- Methode des Events declenchés par les menus de la barre d'outil (ToolStrip) --

        /// <summary>
        /// Methode de l'evenement declenché par le menu "NewChannel" de la
        ///    barre d'outil (ToolStrip). L'utilisateur souhaite ajouter un
        ///    nouveau channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewChannelMenuItem_Click(object sender, EventArgs e)
        {
            Controller.AddChannel(null);
        }

        /// <summary>
        /// Methode de l'evenement declenché par le bouton "NewFolder" de la
        ///    barre d'outil (ToolStrip). L'utilisateur souhaite ajouter un
        ///    nouveau repertoire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFolderMenuItem_Click(object sender, EventArgs e)
        {
            Controller.AddFolder(null);
        }

        /// <summary>
        /// Méthode de l'evenement declenché par le bouton "Marquer toutes les
        ///  actualités comme lues" de la barre d'outil. L'utilisateur souhaite
        ///  marquer toutes les actualités de tous les channels comme lues.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkAllNewsAsReadButton_Click(object sender, EventArgs e)
        {
            Controller.MaskAsReadFolder("root");
        }

        /// <summary>
        /// Méthode de l'evenement declenché par le bouton "Mise à jour 
        ///   d'un flux RSS" de la barre d'outil. L'utilisateur souhaite
        ///   mettre à jour le flux RSS selectionné dans la treeview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateChannelButton_Click(object sender, EventArgs e)
        {
            // INITIALISATION
            String channelPath = null;
            TreeNode channelNode = null;

            channelNode = FoldersTree.SelectedNode;
            if (channelNode != null)
            {
                if (channelNode.Tag.ToString() == "Channel")
                {
                    channelPath = channelNode.Name;
                    Controller.Update(channelPath);
                }
            }
        }

        /// <summary>
        /// Methode de l'evenement du bouton "Update All" de la barre d'outil.
        /// L'utilisateur souhaite mette à jour l'ensemble des flux RSS.
        /// 
        /// Cette opération est lancée dans un thread particulier géré par 
        ///   l'interface graphique (Background Worker).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAllChannelButton_Click(object sender, EventArgs e)
        {
            if (!WorkerThread.IsBusy)
            {
                // Lance l'opération dans un nouveau thread.
                WorkerThread.RunWorkerAsync();
                CancelWorkerButtonToolBar.Enabled = true;
            }
        }

        /// <summary>
        /// Methode de l'evenement du bouton "Cancel Worker" de la barre d'outil.
        /// L'utilisateur souhaite stopper la mise à jour de tous les flux RSS
        ///   réalisé par le Background Worker de l'interface graphique.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelWorkerButtonToolBar_Click(object sender, EventArgs e)
        {
            if (WorkerThread.IsBusy)
            {
                CancelWorkerButtonToolBar.Enabled = false;
                WorkerThread.CancelAsync();
            }
        }

        #endregion

        #region -- Evens des sous-menus du menu de la treeview (canal RSS) --

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Marquer comme lu" 
        ///   du menu de la treview lors de la selection d'un node channel.
        ///   L'utilisateur souhaite marquer un channel comme lu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkNewsAsRead_Click(object sender, EventArgs e)
        {
            // INITIALISATION
            String channelPath = null;
            TreeNode channelNode = null;

            channelNode = FoldersTree.SelectedNode;
            if (channelNode.Tag.ToString() == "Channel")
            {
                channelPath = channelNode.Name;
                Controller.MaskAsReadChannel(channelPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Delete" 
        ///   du menu de la treview lors de la selection d'un node channel.
        ///   L'utilisateur souhaite supprimer un nouveau channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteChannelMenuItem_Click(object sender, EventArgs e)
        {  
            // INITIALISATION
            String channelPath = null;
            TreeNode channelNode = null;

            channelNode = FoldersTree.SelectedNode;
            if (channelNode.Tag.ToString() == "Channel")
            {
                channelPath = channelNode.Name;
                Controller.DeleteChannel(channelPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "CopyLink" 
        ///   du menu de la treview lors de la selection d'un node channel.
        ///   L'utilisateur souhaite copier le lien du channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyLinkMenuItem_Click(object sender, EventArgs e)
        {
            // INITIALISATION
            String channelPath = null;
            TreeNode channelNode = null;

            channelNode = FoldersTree.SelectedNode;
            if (channelNode.Tag.ToString() == "Channel")
            {
                channelPath = channelNode.Name;
                Controller.CopyLinkChannel(channelPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Deplacer"
        ///  du menu associé à un node channel de la treeview. L'utilisateur
        ///   souhaite deplacer un channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveChannelMenuItem_Click(object sender, EventArgs e)
        {
            // INITIALISATION
            String channelPath = null;
            TreeNode channelNode = null;

            channelNode = FoldersTree.SelectedNode;
            if (channelNode.Tag.ToString() == "Channel")
            {
                channelPath = channelNode.Name;
                Controller.MoveChannel(channelPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Update"
        ///  du menu associé à un node channel de la treeview. L'utilisateur
        ///   souhaite mettre à jour un flux RSS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateChannelMenuItem_Click(object sender, EventArgs e)
        {
            // INITIALISATION
            String channelPath = null;
            TreeNode channelNode = null;

            channelNode = FoldersTree.SelectedNode;
            if (channelNode.Tag.ToString() == "Channel")
            {
                channelPath = channelNode.Name;
                Controller.Update(channelPath);
            }
        }

        #endregion

        #region -- Events des sous-menus du menu de la treeview (folder) --

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "NewFolder" 
        ///   du menu de la treview lors de la selection d'un node repertoire.
        ///   L'utilisateur souhaite ajouter un nouveau repertorie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFolder2MenuItem_Click(object sender, EventArgs e)
        {
            // DECLARATION & INITIALISATION
            String folderPath = null;
            TreeNode folderNode = null;

            folderNode = FoldersTree.SelectedNode;
            if (folderNode.Tag.ToString() == "Folder")
            {
                folderPath = folderNode.Name;
                Controller.AddFolder(folderPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "NewChannel" 
        ///   du menu de la treview lors de la selection d'un node repertoire.
        ///   L'utilisateur souhaite ajouter un nouveau channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewChannel2MenuItem_Click(object sender, EventArgs e)
        {
            // DECLARATION & INITIALISATION
            String folderPath = null;
            TreeNode folderNode = null;

            folderNode = FoldersTree.SelectedNode;
            if (folderNode.Tag.ToString() == "Folder")
            {
                folderPath = folderNode.Name;
                Controller.AddChannel(folderPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "MaskAsRead" 
        ///   du menu de la treeview lors de la selection d'un node repertoire. 
        ///   L'utilisateur souhaite marquer tous les articles (item) associés
        ///   à ce repertoire comme lus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskNewsAsRead2MenuItem_Click(object sender, EventArgs e)
        {
            // DECLARATION & INITIALISATION
            String folderPath = null;
            TreeNode folderNode = null;

            folderNode = FoldersTree.SelectedNode;
            if (folderNode.Tag.ToString() == "Folder")
            {
                folderPath = folderNode.Name;
                Controller.MaskAsReadFolder(folderPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Delete" 
        ///   du menu de la treview lors de la selection d'un node repertoire.
        ///   L'utilisateur souhaite supprimer un repertoire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteFolderItemMenu_Click(object sender, EventArgs e)
        {
            // DECLARATION & INITIALISATION
            String folderPath = null;
            TreeNode folderNode = null;

            folderNode = FoldersTree.SelectedNode;
            if (folderNode.Tag.ToString() == "Folder")
            {
                folderPath = folderNode.Name;
                Controller.DeleteFolder(folderPath);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Deplacer"
        ///  du menu associé au node repertoire de la treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveFolderMenuItem_Click(object sender, EventArgs e)
        {
            // DECLARATION & INITIALISATION
            String folderPath = null;
            TreeNode folderNode = null;

            folderNode = FoldersTree.SelectedNode;
            if (folderNode.Tag.ToString() == "Folder")
            {
                folderPath = folderNode.Name;
                Controller.MoveFolder(folderPath);
            }
        }

        /// <summary>
        /// Se produit lors d'un click sur un node du treeview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // INITIALISATION
            String channelPath = null;
            TreeNode channelNode = null;

            channelNode = FoldersTree.SelectedNode;
            if (channelNode != null)
            {
                if (channelNode.Tag.ToString() == "Channel")
                {
                    channelPath = channelNode.Name;
                    Controller.DisplayItem(channelPath);
                }
            }
        }



        /// <summary>
        /// Evenement declenché par le click droit de la souris dans la treeview
        /// Permet de selectionner un node de la treeview lorsque l'evenement
        ///  click droit de la souris se produit sur le node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _treeFolders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                FoldersTree.SelectedNode = FoldersTree.GetNodeAt(e.X, e.Y);
            }
        }

        #endregion

        #region -- Events des sous-menus du menu de la listview --

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "MaskAsRead" 
        ///   du menu de la listview lors de la selection d'une ligne d'un article.
        ///   L'utilisateur souhaite marquer un article comme lu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskAsReadMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsTable.SelectedItems.Count == 1)
            {
                String guid = ItemsTable.SelectedItems[0].Tag.ToString();
                Controller.MaskAsReadItem(guid);
            } 
        }
        
        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Delete" 
        ///   du menu de la listview lors de la selection d'une ligne 
        ///   d'un article. L'utilisateur souhaite supprimer un article.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteNewMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsTable.SelectedItems.Count == 1)
            {
                String guid = ItemsTable.SelectedItems[0].Tag.ToString();
                Controller.DeleteItem(guid);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "CopyLink" 
        ///   du menu de la listview lors de la selection d'une ligne d'un
        ///   article. L'utilisateur souhaite copier le lien de l'article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyLinkItemMenu_Click(object sender, EventArgs e)
        {
            if (ItemsTable.SelectedItems.Count == 1)
            {
                String guid = ItemsTable.SelectedItems[0].Tag.ToString();
                Controller.CopyLinkItem(guid);
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par double click sur une ligne
        ///   de la listview. Le double click produit l'ouverture de la page
        ///   web d'un article (actualité) dans le webrowser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChannelDoubleClick(object sender, EventArgs e)
        {
            if (_tableItems.SelectedItems.Count == 1)
            {
                String guid = ItemsTable.SelectedItems[0].Tag.ToString();
                Controller.NavigateTo(guid);
            }
        }


        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "CopyLink" 
        ///   du menu de la listview lors de la selection d'une ligne d'un
        ///   article. L'utilisateur souhaite copier le lien de l'article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBrowerMenuItem_Click(object sender, EventArgs e)
        {
            if (_tableItems.SelectedItems.Count == 1)
            {
                String guid = ItemsTable.SelectedItems[0].Tag.ToString();
                Controller.NavigateTo(guid);
            }
        }

        #endregion

        #region -- Methode des evenements des menus de la barre des menus --

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "NewFolder" 
        ///  de la barre des menus. L'utilisateur souhaite ajouter un
        ///  nouveau repertorie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFolderMenuItemFileMenu_Click(object sender, EventArgs e)
        {
            Controller.AddFolder(null);
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "NewFolder" 
        ///  de la barre des menus. L'utilisateur souhaite ajouter un
        ///  nouveau repertorie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewChannelMenuItemFileMenu_Click(object sender, EventArgs e)
        {
            Controller.AddChannel(null);
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Close" 
        ///  de la barre des menus. L'utilisateur souhaite fermer l'application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseMenuItemFileMenu_Click(object sender, EventArgs e)
        {
            // Sauvegarde la model
            Controller.Save();

            // stoppe le BackGround Worker en cours d'execution
            if (WorkerThread.IsBusy) {
                WorkerThread.CancelAsync();
            }
            // ferme la frame
            Dispose();

            Application.Exit();
        }
        
        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Explorer" du
        ///   menu "Affichage" de la barre d'outil. L'utilisateur souhaite afficher
        ///   ou cacher l'explorateur des repertoires des flux RSS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayExplorerMenuItemViewMenu_Click(object sender, EventArgs e)
        {
            if (DisplayExplorerMenuItemViewMenu.CheckState == CheckState.Checked)
            {
                FoldersTree.Hide();
                DisplayExplorerMenuItemViewMenu.CheckState = CheckState.Unchecked;
            }
            else
            {
                FoldersTree.Show();
                DisplayExplorerMenuItemViewMenu.CheckState = CheckState.Checked;
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Barre d'outil" du
        ///   menu "Affichage" de la barre d'outil. L'utilisateur souhaite afficher
        ///   ou cacher la barre d'outil.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayToolBarMenuItemViewMenu_Click(object sender, EventArgs e)
        {
            if (DisplayToolBarMenuItemViewMenu.CheckState == CheckState.Checked)
            {
                this.toolStripManager.Hide();
                DisplayToolBarMenuItemViewMenu.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.toolStripManager.Show();
                DisplayToolBarMenuItemViewMenu.CheckState = CheckState.Checked;
            }
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Barre d'état" du
        ///   menu "Affichage" de la barre d'outil. L'utilisateur souhaite afficher
        ///   ou cacher la barre d'état.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayStatusBarMenuItemViewMenu_Click(object sender, EventArgs e)
        {
            if (DisplayStatusBarMenuItemViewMenu.CheckState == CheckState.Checked)
            {
                this.StatusBar.Hide();
                DisplayStatusBarMenuItemViewMenu.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.StatusBar.Show();
                DisplayStatusBarMenuItemViewMenu.CheckState = CheckState.Checked;
            }
        }

        #endregion

        #region -- Events des sous-menus du menu de la treeview --

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Nouveau Repertoire"
        ///  du menu de la treeview associé à aucune node. L'utilisateur souhaite
        ///  ajouter un repertoire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFolder3MenuItem_Click(object sender, EventArgs e)
        {
            Controller.AddFolder(null);
        }

        /// <summary>
        /// Methode de l'evenement declenché par le sous-menu "Nouveau Channel"
        ///  du menu de la treeview associé à aucune node. L'utilisateur souhaite
        ///  ajouter un channel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewChannel3MenuItem_Click(object sender, EventArgs e)
        {
            Controller.AddChannel(null);
        }

        #endregion

        #region -- Methode associé au background Worker --

        /// <summary>
        /// Lance une opération asynchrone de mise à jour de tous les flux RSS
        ///  de l'application en utilisant le mecanisme Background Worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            // ATTENTION :
            //
            // Cette ligne est indispensable au bon fonctionnement du 
            // BackgroundWorker (et est très mal documentée dans la documentation
            // MSDN).
            CheckForIllegalCrossThreadCalls = false;

            // Lance l'opération asynchrone..
            e.Result = Controller.UpdateAll(WorkerThread);
        }

        /// <summary>
        /// Affiche la progression de l'opération asynchrone dans la 
        /// ProgressBar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Méthode lancée à la fin du background worker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // A la fin de l'operation du BackgroundWorker, on met
            //   à jour l'interface graphique.
            UpdateTreeViewText(Controller.Manager.Root);
            if (Controller.Channel != null)
            {
                UpdateListView(Controller.Channel.Items);
            }

            CancelWorkerButtonToolBar.Enabled = false;
            ProgressBar.Value = 0;

            if (e.Result is String)
            {
                String errorMessage = e.Result as String;
                if (errorMessage != null)
                {
                    MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
