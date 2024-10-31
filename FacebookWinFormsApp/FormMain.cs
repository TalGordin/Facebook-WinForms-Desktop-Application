using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private ManagerFactory m_ManagerFactory;
        private IFacebookManager m_FBFeaturesManager;
        private IFacebookManager m_FavoritePagesManager;
        private IFacebookManager m_EngagementScoreManager;
        private IFacebookManager m_BDayStatsManager;

        public FormMain()
        {
            InitializeComponent();

            friendsListBindingSource = new BindingSource();
            setSize(new Size(549, 429));
            FacebookService.s_CollectionLimit = 25;

            m_ManagerFactory = new ManagerFactory();

            m_FBFeaturesManager = m_ManagerFactory.CreateManager(
                ManagerFactory.ManagerType.FacebookFeatures,
                newPost,
                allPosts,
                pictureBoxAlbum,
                friendsList,
                groupsList
            );

            m_FavoritePagesManager = m_ManagerFactory.CreateManager(
                ManagerFactory.ManagerType.FavoritePages,
                listBoxLikedPages,
                listBoxFavoritePages
            );

            m_EngagementScoreManager = m_ManagerFactory.CreateManager(
                ManagerFactory.ManagerType.EngagementScore,
                engagementScore,
                engagementDetails
            );

            m_BDayStatsManager = m_ManagerFactory.CreateManager(
                ManagerFactory.ManagerType.BirthdayStats,
                birthdayStatsTitle,
                birthdayStatsDetails
            );
        }

        private void setSize(Size i_Size)
        {
            Size = i_Size;
            tabControl1.Dock = DockStyle.Fill;
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
                "1444193829609811", // App ID
                "email",
                "public_profile",
                "user_birthday",
                "user_likes",
                "user_posts",
                "user_photos",
                "user_friends"
            /*   - Unfortunately, not authorized to use. We'll pretend like we are.
            "user_videos",
            "groups_access_member_info" 
            */
            );

            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                ((FavoritePagesManager)m_FavoritePagesManager).SetCurrentUser(m_LoggedInUser);

                buttonLogin.GetControl().Text = $"Logged in as {m_LoggedInUser.Name}";
                buttonLogin.GetControl().BackColor = Color.LightGreen;
                pictureBoxProfile.ImageLocation = m_LoggedInUser.PictureNormalURL;
                buttonLogin.GetControl().Enabled = false;
                buttonLogout.GetControl().Enabled = true;
                labelStatus.Text = "Successfully logged in";
                labelStatus.ForeColor = Color.Blue;

                ((FacebookFeaturesManager)m_FBFeaturesManager).GetUserPosts(m_LoggedInUser, DisplayPostsCallbackHandler);
                ((FacebookFeaturesManager)m_FBFeaturesManager).LoadUserMedia(m_LoggedInUser, PhotosStatus, DisplayPhotoCallbackHandler);

                PhotosStatus.Location = new Point(21, 252);
                PhotosStatus.Text = "Loading media.\nThis may take a while.";

                ((FacebookFeaturesManager)m_FBFeaturesManager).DisplayFriends(m_LoggedInUser, DisplayFriendsCallbackHandler);
                ((FacebookFeaturesManager)m_FBFeaturesManager).DisplayGroups(m_LoggedInUser, DisplayGroupsCallbackHandler);
            }
            else
            {
                labelStatus.Text = $"Login failed: {m_LoginResult.ErrorMessage}";
                labelStatus.ForeColor = Color.Red;
                m_LoggedInUser = null;
            }
        }

        public void DisplayPhotoCallbackHandler(int i_PhotoIndex)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayPhotoCallbackHandler(i_PhotoIndex)));
            }
            else
            {
                PhotosStatus.Location = new Point(81, 247);
                PhotosStatus.Text = "";
                ((FacebookFeaturesManager)m_FBFeaturesManager).DisplayMedia(i_PhotoIndex);
            }
        }

        public void DisplayFriendsCallbackHandler(FacebookObjectCollection<User> i_UserFriends)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayFriendsCallbackHandler(i_UserFriends)));
            }
            else
            {
                ((FacebookFeaturesManager)m_FBFeaturesManager).AddToFriendBox(i_UserFriends);
            }
        }

        public void DisplayPostsCallbackHandler(FacebookObjectCollection<Post> i_UserPosts)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayPostsCallbackHandler(i_UserPosts)));
            }
            else
            {
                ((FacebookFeaturesManager)m_FBFeaturesManager).AddToPostBox(i_UserPosts);
            }
        }

        public void DisplayGroupsCallbackHandler(FacebookObjectCollection<Group> i_UserGroups)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayGroupsCallbackHandler(i_UserGroups)));
            }
            else
            {
                ((FacebookFeaturesManager)m_FBFeaturesManager).AddToGroupsBox(i_UserGroups);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser != null)
            {
                ((FavoritePagesManager)m_FavoritePagesManager).SaveOnLogout();
            }

            FacebookService.LogoutWithUI();
            resetUIOnLogout();
        }

        private void resetUIOnLogout()
        {
            buttonLogin.GetControl().Text = "Login";
            buttonLogin.GetControl().BackColor = Color.FromArgb(66, 103, 178);
            m_LoginResult = null;
            m_LoggedInUser = null;
            listBoxLikedPages.Items.Clear();
            listBoxFavoritePages.Items.Clear();
            buttonLogin.GetControl().Enabled = true;
            buttonLogout.GetControl().Enabled = false;
            pictureBoxProfile.Image = null;
            labelStatus.Text = "Successfully logged out";
            labelStatus.ForeColor = Color.Red;

            ((FacebookFeaturesManager)m_FBFeaturesManager).ClearPhotos();
            ((FacebookFeaturesManager)m_FBFeaturesManager).ClearPosts();
            ((FacebookFeaturesManager)m_FBFeaturesManager).ClearFriends();
            ((FacebookFeaturesManager)m_FBFeaturesManager).ClearGroups();
        }

        private void tabControl1_SelectedTabChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    setSize(new Size(549, 429));
                    break;
                case 1:
                    setSize(new Size(549, 429));
                    if (m_LoggedInUser != null)
                    {
                        ((FavoritePagesManager)m_FavoritePagesManager).LoadLikedPages(m_LoggedInUser);
                        ((FavoritePagesManager)m_FavoritePagesManager).LoadFavoritePagesFromFile(); // Load favorite pages for the user
                    }
                    break;
                case 2:
                    setSize(new Size(549, 429));
                    if (m_LoggedInUser != null)
                    {
                        ((EngagementScoreManager)m_EngagementScoreManager).DisplayEngagementDetails(m_LoginResult.AccessToken, ClientSize.Width);
                    }
                    break;
                case 3:
                    setSize(new Size(549, 500));
                    if (m_LoggedInUser != null)
                    {
                        ((BirthdayStatsManager)m_BDayStatsManager).DisplayStats(m_LoggedInUser, ClientSize.Width);
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonAddToFavorites_Click(object sender, EventArgs e)
        {
            ((FavoritePagesManager)m_FavoritePagesManager).AddToFavorites();
        }

        private void buttonRemoveFromFavorites_Click(object sender, EventArgs e)
        {
            ((FavoritePagesManager)m_FavoritePagesManager).RemoveFromFavorites();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser != null)
            {
                ((FacebookFeaturesManager)m_FBFeaturesManager).AddNewPost(m_LoginResult.AccessToken, newPost.Text);
            }
        }

        private void buttonNextPicture_Click(object sender, EventArgs e)
        {
            ((FacebookFeaturesManager)m_FBFeaturesManager).ChangeMedia(1);
        }

        private void buttonPrevPicture_Click(object sender, EventArgs e)
        {
            ((FacebookFeaturesManager)m_FBFeaturesManager).ChangeMedia(-1);
        }

    }
}
