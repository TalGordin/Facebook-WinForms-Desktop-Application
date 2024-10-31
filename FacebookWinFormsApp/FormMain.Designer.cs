using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


namespace BasicFacebookFeatures
{
    partial class FormMain
    {

        //Data Binding
        private System.Windows.Forms.BindingSource friendsListBindingSource;

        //Tabs
        private System.Windows.Forms.TabControl tabControl1;
        private TransparentTabPage tabPage1;
        private TransparentTabPage tabPage2;
        private TransparentTabPage tabPage3;
        private TransparentTabPage tabPage4;

        //Tab1
        private IDecoratedButton buttonLogin;
        private IDecoratedButton buttonLogout;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label appIDLabel;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.TextBox newPost;
        private TransparentListBox allPosts;
        private IDecoratedButton postButton;
        private PictureBox pictureBoxAlbum;
        private IDecoratedButton buttonNextPicture;
        private IDecoratedButton buttonPrevPicture;
        private TransparentListBox friendsList;
        private TransparentListBox groupsList;
        private Label titlePhotos;
        private Label titlePosts;
        private Label titleFriends;
        private Label titleGroups;
        private Label PhotosStatus;

        //Tab2
        private IDecoratedButton buttonAddToFavorites;
        private IDecoratedButton buttonRemoveFromFavorites;
        private TransparentListBox listBoxLikedPages;
        private TransparentListBox listBoxFavoritePages;

        //Tab3
        private System.Windows.Forms.Label engagementScoreTitle;
        private System.Windows.Forms.TextBox engagementScore;
        private System.Windows.Forms.Label engagementDetails;
        private System.Windows.Forms.Label engagementNoticeMessage;

        //Tab4
        private System.Windows.Forms.Label birthdayStatsTitle;
        private System.Windows.Forms.Label birthdayStatsDetails;

        private void InitializeComponent()
        {
            List<IDecoratedButton> allButtons = new List<IDecoratedButton>();

            this.titlePhotos = new System.Windows.Forms.Label();
            this.titlePosts = new System.Windows.Forms.Label();
            this.titleFriends = new System.Windows.Forms.Label();
            this.titleGroups = new System.Windows.Forms.Label();
            this.PhotosStatus = new System.Windows.Forms.Label();
            this.friendsList = new BasicFacebookFeatures.TransparentListBox();
            this.groupsList = new BasicFacebookFeatures.TransparentListBox();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new BasicFacebookFeatures.TransparentTabPage();
            this.friendListDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.friendListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonLogout = new ColoredFrameButton(new BasicButton(), Color.FromArgb(237, 178, 83));
            this.buttonLogin = new ColoredFrameButton(new BasicButton(), Color.FromArgb(59, 201, 16));
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.buttonNextPicture = new RoundedButton(new BasicButton());
            this.buttonPrevPicture = new RoundedButton(new BasicButton());
            this.appIDLabel = new System.Windows.Forms.Label();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonLogout = new ColoredFrameButton(new BasicButton(), Color.FromArgb(237, 178, 83));
            this.buttonLogin = new ColoredFrameButton(new BasicButton(), Color.FromArgb(59, 201, 16));
            this.newPost = new System.Windows.Forms.TextBox();
            this.allPosts = new BasicFacebookFeatures.TransparentListBox();
            this.postButton = new ColoredFrameButton(new ColoredTextButton(new RoundedButton(new BasicButton()), Color.FromArgb(0, 72, 255)), Color.FromArgb(0, 72, 255));
            this.pictureBoxAlbum = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new BasicFacebookFeatures.TransparentTabPage();
            this.listBoxLikedPages = new BasicFacebookFeatures.TransparentListBox();
            this.listBoxFavoritePages = new BasicFacebookFeatures.TransparentListBox();
            this.buttonAddToFavorites = new ColoredFrameButton(new RoundedButton(new BasicButton()), Color.FromArgb(59, 201, 16));
            this.buttonRemoveFromFavorites = new ColoredFrameButton(new RoundedButton(new BasicButton()), Color.FromArgb(237, 178, 83));
            this.tabPage3 = new BasicFacebookFeatures.TransparentTabPage();
            this.engagementScoreTitle = new System.Windows.Forms.Label();
            this.engagementScore = new System.Windows.Forms.TextBox();
            this.engagementDetails = new System.Windows.Forms.Label();
            this.engagementNoticeMessage = new System.Windows.Forms.Label();
            this.tabPage4 = new BasicFacebookFeatures.TransparentTabPage();
            this.birthdayStatsTitle = new System.Windows.Forms.Label();
            this.birthdayStatsDetails = new System.Windows.Forms.Label();
            this.friendListBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.friendListBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingNavigator)).BeginInit();
            this.friendListBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePhotos
            // 
            this.titlePhotos.AutoSize = true;
            this.titlePhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.titlePhotos.Location = new System.Drawing.Point(8, 141);
            this.titlePhotos.Name = "titlePhotos";
            this.titlePhotos.Size = new System.Drawing.Size(209, 24);
            this.titlePhotos.TabIndex = 0;
            this.titlePhotos.Text = "Photos and Thumbnails";
            // 
            // titlePosts
            // 
            this.titlePosts.AutoSize = true;
            this.titlePosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.titlePosts.Location = new System.Drawing.Point(550, 141);
            this.titlePosts.Name = "titlePosts";
            this.titlePosts.Size = new System.Drawing.Size(55, 24);
            this.titlePosts.TabIndex = 0;
            this.titlePosts.Text = "Posts";
            // 
            // titleFriends
            // 
            this.titleFriends.AutoSize = true;
            this.titleFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.titleFriends.Location = new System.Drawing.Point(316, 141);
            this.titleFriends.Name = "titleFriends";
            this.titleFriends.Size = new System.Drawing.Size(74, 24);
            this.titleFriends.TabIndex = 0;
            this.titleFriends.Text = "Friends";
            // 
            // titleGroups
            // 
            this.titleGroups.AutoSize = true;
            this.titleGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.titleGroups.Location = new System.Drawing.Point(316, 288);
            this.titleGroups.Name = "titleGroups";
            this.titleGroups.Size = new System.Drawing.Size(72, 24);
            this.titleGroups.TabIndex = 0;
            this.titleGroups.Text = "Groups";
            // 
            // PhotosStatus
            // 
            this.PhotosStatus.AutoSize = true;
            this.PhotosStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.PhotosStatus.Location = new System.Drawing.Point(81, 247);
            this.PhotosStatus.Name = "PhotosStatus";
            this.PhotosStatus.Size = new System.Drawing.Size(0, 24);
            this.PhotosStatus.TabIndex = 0;
            this.PhotosStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // friendsList
            // 
            this.friendsList.BackColor = System.Drawing.Color.Transparent;
            this.friendsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.friendsList.FormattingEnabled = true;
            this.friendsList.ItemHeight = 20;
            this.friendsList.Location = new System.Drawing.Point(243, 167);
            this.friendsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(213, 104);
            this.friendsList.TabIndex = 0;
            // 
            // groupsList
            // 
            this.groupsList.BackColor = System.Drawing.Color.Transparent;
            this.groupsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.groupsList.FormattingEnabled = true;
            this.groupsList.ItemHeight = 20;
            this.groupsList.Location = new System.Drawing.Point(243, 314);
            this.groupsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupsList.Name = "groupsList";
            this.groupsList.Size = new System.Drawing.Size(213, 104);
            this.groupsList.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(704, 682);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedTabChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.friendListDataGridView);
            this.tabPage1.Controls.Add(this.buttonLogout.GetControl());
            this.tabPage1.Controls.Add(this.buttonLogin.GetControl());
            this.tabPage1.Controls.Add(this.labelStatus);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.friendsList);
            this.tabPage1.Controls.Add(this.groupsList);
            this.tabPage1.Controls.Add(this.buttonNextPicture.GetControl());
            this.tabPage1.Controls.Add(this.buttonPrevPicture.GetControl());
            this.tabPage1.Controls.Add(this.appIDLabel);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.labelStatus);
            this.tabPage1.Controls.Add(this.buttonLogout.GetControl());
            this.tabPage1.Controls.Add(this.buttonLogin.GetControl());
            this.tabPage1.Controls.Add(this.newPost);
            this.tabPage1.Controls.Add(this.allPosts);
            this.tabPage1.Controls.Add(this.postButton.GetControl());
            this.tabPage1.Controls.Add(this.titlePhotos);
            this.tabPage1.Controls.Add(this.titlePosts);
            this.tabPage1.Controls.Add(this.titleFriends);
            this.tabPage1.Controls.Add(this.titleGroups);
            this.tabPage1.Controls.Add(this.PhotosStatus);
            this.tabPage1.Controls.Add(this.pictureBoxAlbum);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(696, 653);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Facebook Features";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // friendListDataGridView
            // 
            this.friendListDataGridView.AutoGenerateColumns = false;
            this.friendListDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.friendListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.friendListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.friendListDataGridView.DataSource = this.friendListBindingSource;
            this.friendListDataGridView.Location = new System.Drawing.Point(474, 474);
            this.friendListDataGridView.Name = "friendListDataGridView";
            this.friendListDataGridView.RowHeadersWidth = 62;
            this.friendListDataGridView.RowTemplate.Height = 28;
            this.friendListDataGridView.Size = new System.Drawing.Size(300, 85);
            this.friendListDataGridView.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // friendListBindingSource
            // 
            this.friendListBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.FriendList);
            // 
            // buttonLogin
            // buttonNextPicture
            // 
            this.buttonNextPicture.GetControl().Font = new System.Drawing.Font("Tahoma", 12F);
            this.buttonNextPicture.GetControl().Location = new System.Drawing.Point(152, 376);
            this.buttonNextPicture.GetControl().Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNextPicture.GetControl().Name = "buttonNextPicture";
            this.buttonNextPicture.GetControl().Size = new System.Drawing.Size(74, 30);
            this.buttonNextPicture.GetControl().TabIndex = 9;
            this.buttonNextPicture.GetControl().Text = "=>";
            this.buttonNextPicture.GetControl().Click += new System.EventHandler(this.buttonNextPicture_Click);
            allButtons.Add(this.buttonNextPicture);
            // 
            // buttonPrevPicture
            // 
            this.buttonPrevPicture.GetControl().Font = new System.Drawing.Font("Tahoma", 12F);
            this.buttonPrevPicture.GetControl().Location = new System.Drawing.Point(9, 376);
            this.buttonPrevPicture.GetControl().Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrevPicture.GetControl().Name = "buttonPrevPicture";
            this.buttonPrevPicture.GetControl().Size = new System.Drawing.Size(74, 30);
            this.buttonPrevPicture.GetControl().TabIndex = 10;
            this.buttonPrevPicture.GetControl().Text = "<=";
            this.buttonPrevPicture.GetControl().Click += new System.EventHandler(this.buttonPrevPicture_Click);
            allButtons.Add(this.buttonPrevPicture);
            // 
            // appIDLabel
            // 
            this.appIDLabel.AutoSize = true;
            this.appIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.appIDLabel.Location = new System.Drawing.Point(30, 9);
            this.appIDLabel.Name = "appIDLabel";
            this.appIDLabel.Size = new System.Drawing.Size(402, 24);
            this.appIDLabel.TabIndex = 0;
            this.appIDLabel.Text = "This is the AppID of \"Design Patterns App 2.4\": ";
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxAppID.Location = new System.Drawing.Point(475, 9);
            this.textBoxAppID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(174, 21);
            this.textBoxAppID.TabIndex = 1;
            this.textBoxAppID.Text = "1444193829609811";
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(25, 43);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(89, 80);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 2;
            this.pictureBoxProfile.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(215, 99);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(87, 16);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Not logged in";
            // 
            // buttonLogout
            // 
            this.buttonLogout.GetControl().Enabled = false;
            this.buttonLogout.GetControl().Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonLogout.GetControl().Location = new System.Drawing.Point(120, 91);
            this.buttonLogout.GetControl().Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogout.GetControl().Name = "buttonLogout";
            this.buttonLogout.GetControl().Size = new System.Drawing.Size(89, 32);
            this.buttonLogout.GetControl().TabIndex = 4;
            this.buttonLogout.GetControl().Text = "Logout";
            this.buttonLogout.GetControl().Click += new System.EventHandler(this.buttonLogout_Click);
            allButtons.Add(this.buttonLogout);
            // 
            // buttonLogin
            // 
            this.buttonLogin.GetControl().Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonLogin.GetControl().Location = new System.Drawing.Point(120, 51);
            this.buttonLogin.GetControl().Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.GetControl().Name = "buttonLogin";
            this.buttonLogin.GetControl().Size = new System.Drawing.Size(89, 32);
            this.buttonLogin.GetControl().TabIndex = 5;
            this.buttonLogin.GetControl().Text = "Login";
            this.buttonLogin.GetControl().Click += new System.EventHandler(this.buttonLogin_Click);
            allButtons.Add(this.buttonLogin);
            // 
            // newPost
            // 
            this.newPost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.newPost.Location = new System.Drawing.Point(475, 376);
            this.newPost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newPost.Name = "newPost";
            this.newPost.Size = new System.Drawing.Size(213, 19);
            this.newPost.TabIndex = 1;
            // 
            // allPosts
            // 
            this.allPosts.BackColor = System.Drawing.Color.Transparent;
            this.allPosts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.allPosts.FormattingEnabled = true;
            this.allPosts.ItemHeight = 20;
            this.allPosts.Location = new System.Drawing.Point(475, 167);
            this.allPosts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allPosts.Name = "allPosts";
            this.allPosts.Size = new System.Drawing.Size(213, 204);
            this.allPosts.TabIndex = 0;
            // 
            // postButton
            // 
            this.postButton.GetControl().Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.postButton.GetControl().Location = new System.Drawing.Point(554, 399);
            this.postButton.GetControl().Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.postButton.GetControl().Name = "postButton";
            this.postButton.GetControl().Size = new System.Drawing.Size(68, 34);
            this.postButton.GetControl().TabIndex = 2;
            this.postButton.GetControl().Text = "Post";
            this.postButton.GetControl().Click += new System.EventHandler(this.postButton_Click);
            allButtons.Add(postButton);
            // 
            // pictureBoxAlbum
            // 
            this.pictureBoxAlbum.Location = new System.Drawing.Point(9, 167);
            this.pictureBoxAlbum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxAlbum.Name = "pictureBoxAlbum";
            this.pictureBoxAlbum.Size = new System.Drawing.Size(217, 204);
            this.pictureBoxAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAlbum.TabIndex = 11;
            this.pictureBoxAlbum.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.listBoxLikedPages);
            this.tabPage2.Controls.Add(this.listBoxFavoritePages);
            this.tabPage2.Controls.Add(this.buttonAddToFavorites.GetControl());
            this.tabPage2.Controls.Add(this.buttonRemoveFromFavorites.GetControl());
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(696, 653);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Favorite Pages";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBoxLikedPages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.ItemHeight = 20;
            this.listBoxLikedPages.Location = new System.Drawing.Point(61, 28);
            this.listBoxLikedPages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(267, 264);
            this.listBoxLikedPages.TabIndex = 0;
            // 
            // listBoxFavoritePages
            // 
            this.listBoxFavoritePages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBoxFavoritePages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxFavoritePages.FormattingEnabled = true;
            this.listBoxFavoritePages.ItemHeight = 20;
            this.listBoxFavoritePages.Location = new System.Drawing.Point(363, 28);
            this.listBoxFavoritePages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxFavoritePages.Name = "listBoxFavoritePages";
            this.listBoxFavoritePages.Size = new System.Drawing.Size(267, 264);
            this.listBoxFavoritePages.TabIndex = 1;
            // 
            // buttonAddToFavorites
            // 
            this.buttonAddToFavorites.GetControl().Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAddToFavorites.GetControl().Location = new System.Drawing.Point(61, 319);
            this.buttonAddToFavorites.GetControl().Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddToFavorites.GetControl().Name = "buttonAddToFavorites";
            this.buttonAddToFavorites.GetControl().Size = new System.Drawing.Size(267, 32);
            this.buttonAddToFavorites.GetControl().TabIndex = 2;
            this.buttonAddToFavorites.GetControl().Text = "Add to Favorites";
            this.buttonAddToFavorites.GetControl().Click += new System.EventHandler(this.buttonAddToFavorites_Click);
            allButtons.Add(this.buttonAddToFavorites);
            // 
            // buttonRemoveFromFavorites
            // 
            this.buttonRemoveFromFavorites.GetControl().Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonRemoveFromFavorites.GetControl().Location = new System.Drawing.Point(363, 319);
            this.buttonRemoveFromFavorites.GetControl().Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveFromFavorites.GetControl().Name = "buttonRemoveFromFavorites";
            this.buttonRemoveFromFavorites.GetControl().Size = new System.Drawing.Size(267, 32);
            this.buttonRemoveFromFavorites.GetControl().TabIndex = 3;
            this.buttonRemoveFromFavorites.GetControl().Text = "Remove from Favorites";
            this.buttonRemoveFromFavorites.GetControl().Click += new System.EventHandler(this.buttonRemoveFromFavorites_Click);
            allButtons.Add(this.buttonRemoveFromFavorites);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.engagementScoreTitle);
            this.tabPage3.Controls.Add(this.engagementScore);
            this.tabPage3.Controls.Add(this.engagementDetails);
            this.tabPage3.Controls.Add(this.engagementNoticeMessage);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(696, 653);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Engagement Score";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // engagementScoreTitle
            // 
            this.engagementScoreTitle.AutoSize = true;
            this.engagementScoreTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.engagementScoreTitle.Location = new System.Drawing.Point(201, 25);
            this.engagementScoreTitle.Name = "engagementScoreTitle";
            this.engagementScoreTitle.Size = new System.Drawing.Size(301, 29);
            this.engagementScoreTitle.TabIndex = 0;
            this.engagementScoreTitle.Text = "Your engagement score is:";
            // 
            // engagementScore
            // 
            this.engagementScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.engagementScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.engagementScore.Location = new System.Drawing.Point(302, 69);
            this.engagementScore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.engagementScore.Name = "engagementScore";
            this.engagementScore.Size = new System.Drawing.Size(100, 27);
            this.engagementScore.TabIndex = 1;
            this.engagementScore.Text = "N/A";
            this.engagementScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // engagementDetails
            // 
            this.engagementDetails.AutoSize = true;
            this.engagementDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.engagementDetails.Location = new System.Drawing.Point(152, 118);
            this.engagementDetails.Name = "engagementDetails";
            this.engagementDetails.Size = new System.Drawing.Size(391, 25);
            this.engagementDetails.TabIndex = 2;
            this.engagementDetails.Text = "Please log in to see your engagement score";
            this.engagementDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // engagementNoticeMessage
            // 
            this.engagementNoticeMessage.AutoSize = true;
            this.engagementNoticeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.engagementNoticeMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(148)))), ((int)(((byte)(230)))));
            this.engagementNoticeMessage.Location = new System.Drawing.Point(169, 374);
            this.engagementNoticeMessage.Name = "engagementNoticeMessage";
            this.engagementNoticeMessage.Size = new System.Drawing.Size(342, 50);
            this.engagementNoticeMessage.TabIndex = 3;
            this.engagementNoticeMessage.Text = "Note: Some data might be unavailable\ndue to Facebook restrictions.";
            this.engagementNoticeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.birthdayStatsTitle);
            this.tabPage4.Controls.Add(this.birthdayStatsDetails);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(696, 653);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Birthday Stats";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // birthdayStatsTitle
            // 
            this.birthdayStatsTitle.AutoSize = true;
            this.birthdayStatsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.birthdayStatsTitle.Location = new System.Drawing.Point(110, 30);
            this.birthdayStatsTitle.Name = "birthdayStatsTitle";
            this.birthdayStatsTitle.Size = new System.Drawing.Size(479, 31);
            this.birthdayStatsTitle.TabIndex = 0;
            this.birthdayStatsTitle.Text = "Please log in to see your birthday stats";
            this.birthdayStatsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // birthdayStatsDetails
            // 
            this.birthdayStatsDetails.AutoSize = true;
            this.birthdayStatsDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.birthdayStatsDetails.Location = new System.Drawing.Point(137, 138);
            this.birthdayStatsDetails.Name = "birthdayStatsDetails";
            this.birthdayStatsDetails.Size = new System.Drawing.Size(0, 25);
            this.birthdayStatsDetails.TabIndex = 0;
            this.birthdayStatsDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // friendListBindingNavigator
            // 
            this.friendListBindingNavigator.AddNewItem = this.bindingNavigatorPositionItem;
            this.friendListBindingNavigator.BindingSource = this.friendListBindingSource;
            this.friendListBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.friendListBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.friendListBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.friendListBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.friendListBindingNavigatorSaveItem});
            this.friendListBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.friendListBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.friendListBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.friendListBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.friendListBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.friendListBindingNavigator.Name = "friendListBindingNavigator";
            this.friendListBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.friendListBindingNavigator.Size = new System.Drawing.Size(800, 33);
            this.friendListBindingNavigator.TabIndex = 1;
            this.friendListBindingNavigator.Text = "bindingNavigator1";
            this.friendListBindingNavigator.Visible = false;
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // friendListBindingNavigatorSaveItem
            // 
            this.friendListBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.friendListBindingNavigatorSaveItem.Enabled = false;
            this.friendListBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("friendListBindingNavigatorSaveItem.Image")));
            this.friendListBindingNavigatorSaveItem.Name = "friendListBindingNavigatorSaveItem";
            this.friendListBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 28);
            this.friendListBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 682);
            this.Controls.Add(this.friendListBindingNavigator);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Tal & Keren\'s Facebook Application";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingNavigator)).EndInit();
            this.friendListBindingNavigator.ResumeLayout(false);
            this.friendListBindingNavigator.PerformLayout();
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            decorateAllButtons(allButtons);
            this.PerformLayout();

           
        }

        private void decorateAllButtons(List<IDecoratedButton> i_AllButtons)
        {
            foreach (IDecoratedButton button in i_AllButtons)
            {
                button.ApplyDecoration();
            }
        }

        private DataGridView friendListDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private BindingSource friendListBindingSource;
        private System.ComponentModel.IContainer components;
        private BindingNavigator friendListBindingNavigator;
        private ToolStripButton bindingNavigatorAddNewItem;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorDeleteItem;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private ToolStripButton friendListBindingNavigatorSaveItem;
    }
}