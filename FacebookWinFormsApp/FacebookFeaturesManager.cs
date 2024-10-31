using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class FacebookFeaturesManager : IFacebookManager
    {
        private static FacebookFeaturesManager s_Instance = null;
        // $G$ CSS-004 (-3) Bad static readonly members variable name (should be in the form of sr_PamelCase).
        private static readonly object s_Lock = new object();
        private System.Windows.Forms.BindingSource friendsListBindingSource;
        private TextBox m_NewPostBox;
        private TransparentListBox m_AllPostsBox;
        private PictureBox m_PictureBox;
        private List<IMediaItem> m_UserMedia;
        private int m_CurrentPhotoIndex;
        private ListBox m_FriendsListBox;
        private ListBox m_GroupsListBox;

        private FacebookFeaturesManager(
            TextBox i_NewPostBox,
            TransparentListBox i_AllPostsBox,
            PictureBox i_PictureBox,
            ListBox i_FriendsListBox,
            ListBox i_GroupsListBox)
        {
            m_NewPostBox = i_NewPostBox;
            m_AllPostsBox = i_AllPostsBox;
            m_PictureBox = i_PictureBox;
            m_FriendsListBox = i_FriendsListBox;
            m_GroupsListBox = i_GroupsListBox;
            m_UserMedia = new List<IMediaItem>();
            m_CurrentPhotoIndex = 0;

            friendsListBindingSource = new BindingSource();
            m_FriendsListBox.DataSource = friendsListBindingSource;
        }

        public static FacebookFeaturesManager Instance(
            TextBox i_NewPostBox,
            TransparentListBox i_AllPostsBox,
            PictureBox i_PictureBox,
            ListBox i_FriendsListBox,
            ListBox i_GroupsListBox)
        {
            if (s_Instance == null)
            {
                lock (s_Lock)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new FacebookFeaturesManager(i_NewPostBox, i_AllPostsBox, i_PictureBox, i_FriendsListBox, i_GroupsListBox);
                    }
                }
            }
            return s_Instance;
        }

        public void Initialize()
        {
            m_CurrentPhotoIndex = 0;
            m_UserMedia.Clear();
        }

        public async void GetUserPosts(User i_User, Action<FacebookObjectCollection<Post>> i_DisplayPostsCallbackHandler)
        {
            if (i_User != null)
            {
                FacebookObjectCollection<Post> posts = await fetchUserPosts(i_User);
                i_DisplayPostsCallbackHandler?.Invoke(posts);
            }
        }

        private async Task<FacebookObjectCollection<Post>> fetchUserPosts(User i_User)
        {
            FacebookObjectCollection<Post> result = null;
            await Task.Run(() => result = i_User.Posts);
            return result;
        }

        public void AddNewPost(string i_AccessToken, string i_Message)
        {
            if (string.IsNullOrEmpty(i_Message))
            {
                MessageBox.Show("Please enter a message before posting.");
            }
            else
            {
                m_AllPostsBox.Items.Insert(0, i_Message);
            }
        }

        public void AddToPostBox(FacebookObjectCollection<Post> i_UserPosts)
        {
            m_AllPostsBox.Items.Clear();
            foreach (var post in i_UserPosts)
            {
                if (!string.IsNullOrEmpty(post.Message))
                {
                    m_AllPostsBox.Items.Add(post.Message);
                }
            }
        }

        public void FetchAndDisplayFriends(User i_LoggedInUser, Action<FacebookObjectCollection<User>> i_DisplayFriendsCallbackHandler)
        {
            if (i_LoggedInUser != null && i_LoggedInUser.Friends != null && i_LoggedInUser.Friends.Count > 0)
            {
                DisplayFriends(i_LoggedInUser, i_DisplayFriendsCallbackHandler);
            }
            else
            {
                MessageBox.Show("No friends data available.");
            }
        }

        public void DisplayFriends(User i_User, Action<FacebookObjectCollection<User>> i_DisplayFriendsCallbackHandler)
        {
            if (i_User != null && i_User.Friends != null && i_User.Friends.Count > 0)
            {
                friendsListBindingSource.DataSource = i_User.Friends;
                m_FriendsListBox.DisplayMember = "Name";

                i_DisplayFriendsCallbackHandler?.Invoke(i_User.Friends);
            }
            else
            {
                MessageBox.Show("No friends found.");
            }
        }

        public void DisplayGroups(User i_User, Action<FacebookObjectCollection<Group>> i_DisplayGroupsCallbackHandler)
        {
            if (i_User != null)
            {
                FacebookObjectCollection<Group> groups = i_User.Groups;
                i_DisplayGroupsCallbackHandler?.Invoke(groups);
            }
        }

        public void AddToFriendBox(FacebookObjectCollection<User> i_UserFriends)
        {
            friendsListBindingSource.DataSource = i_UserFriends;
            m_FriendsListBox.DisplayMember = "Name";
        }

        public void AddToGroupsBox(FacebookObjectCollection<Group> i_UserGroups)
        {
            m_GroupsListBox.Items.Clear();
            foreach (var group in i_UserGroups)
            {
                m_GroupsListBox.Items.Add(group.Name);
            }
        }

        public void ChangeMedia(int i_AddToIndex)
        {
            if (m_UserMedia.Count > 0)
            {
                m_CurrentPhotoIndex = (m_CurrentPhotoIndex + m_UserMedia.Count + i_AddToIndex) % m_UserMedia.Count;
                DisplayMedia(m_CurrentPhotoIndex);
            }
        }

        public void DisplayMedia(int i_MediaIndex)
        {
            if (m_UserMedia.Count > 0 && i_MediaIndex < m_UserMedia.Count)
            {
                m_UserMedia[i_MediaIndex].Display(m_PictureBox);
            }
        }

        public void ClearPosts()
        {
            m_AllPostsBox.Items.Clear();
        }

        public void ClearPhotos()
        {
            m_UserMedia.Clear();
            m_PictureBox.Image = null;
        }

        public void ClearFriends()
        {
            m_FriendsListBox.Items.Clear();
        }

        public void ClearGroups()
        {
            m_GroupsListBox.Items.Clear();
        }

        public void ExtractPhotosFromAlbum(Album i_PhotoAlbum)
        {
            List<Photo> userPhotosInAlbum = new List<Photo>();

            userPhotosInAlbum.AddRange(i_PhotoAlbum.Photos);
            foreach (Photo photo in userPhotosInAlbum)
            {
                m_UserMedia.Add(new UserPhoto(photo));
            }
        }

        public void ExtractVideos(User i_User)
        {
            List<Video> userVideosInAlbum = new List<Video>();

            userVideosInAlbum.AddRange(i_User.Videos);
            foreach (Video video in userVideosInAlbum)
            {
                m_UserMedia.Add(new UserVideo(video));
            }
        }

        public async void LoadUserMedia(User i_User, Label i_PhotosStatus, Action<int> i_DisplayPhotoCallback)
        {
            m_UserMedia.Clear();
            m_CurrentPhotoIndex = 0;
            if (i_User != null)
            {
                try
                {
                    foreach (Album album in i_User.Albums)
                    {
                        await Task.Run(() => ExtractPhotosFromAlbum(album));
                    }

                    await Task.Run(() => ExtractVideos(i_User));

                    m_UserMedia.Sort((media1, media2) => media1.m_CreatedTime.CompareTo(media2.m_CreatedTime));
                }
                catch (Exception ex)
                {
                    i_PhotosStatus.Location = new System.Drawing.Point(21, 252);
                    i_PhotosStatus.Text = "Error loading photos.";
                }

                if (m_UserMedia.Count > 0)
                {
                    i_DisplayPhotoCallback?.Invoke(m_CurrentPhotoIndex);
                }
            }
        }
    }
}
