using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class FavoritePagesManager : IFacebookManager
    {
        private static FavoritePagesManager s_Instance = null;
        private static readonly object s_Lock = new object();
        private ListBox m_LikedPagesListBox;
        private ListBox m_FavoritePagesListBox;
        private string m_FavoritePagesDirectory;
        private string m_CurrentUserFilePath;

        private FavoritePagesManager(ListBox i_LikedPagesListBox, ListBox i_FavoritePagesListBox)
        {
            m_LikedPagesListBox = i_LikedPagesListBox;
            m_FavoritePagesListBox = i_FavoritePagesListBox;
            m_FavoritePagesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FavoritePagesData");

            if (!Directory.Exists(m_FavoritePagesDirectory))
            {
                Directory.CreateDirectory(m_FavoritePagesDirectory);
            }
        }

        public static FavoritePagesManager Instance(ListBox i_LikedPagesListBox, ListBox i_FavoritePagesListBox)
        {
            if (s_Instance == null)
            {
                lock (s_Lock)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new FavoritePagesManager(i_LikedPagesListBox, i_FavoritePagesListBox);
                    }
                }
            }
            return s_Instance;
        }

        public void Initialize()
        {
        }

        public void LoadLikedPages(User i_LoggedInUser)
        {
            m_LikedPagesListBox.Items.Clear();
            foreach (Page likedPage in i_LoggedInUser.LikedPages)
            {
                m_LikedPagesListBox.Items.Add(likedPage);
            }
        }

        public void SetCurrentUser(User i_LoggedInUser)
        {
            m_CurrentUserFilePath = Path.Combine(m_FavoritePagesDirectory, $"{i_LoggedInUser.Id}_favoritePages.txt");

            LoadFavoritePagesFromFile();
        }

        public void SaveFavoritePagesToFile()
        {
            if (!string.IsNullOrEmpty(m_CurrentUserFilePath))
            {
                using (StreamWriter writer = new StreamWriter(m_CurrentUserFilePath))
                {
                    foreach (Page page in m_FavoritePagesListBox.Items)
                    {
                        writer.WriteLine(page.Id);
                    }
                }
            }
        }

        public void LoadFavoritePagesFromFile()
        {
            m_FavoritePagesListBox.Items.Clear();

            if (!string.IsNullOrEmpty(m_CurrentUserFilePath) && File.Exists(m_CurrentUserFilePath))
            {
                string[] pageIds = File.ReadAllLines(m_CurrentUserFilePath); 

                foreach (string pageId in pageIds)
                {
                    Page page = m_LikedPagesListBox.Items.OfType<Page>().FirstOrDefault(p => p.Id == pageId);

                    if (page != null)
                    {
                        m_FavoritePagesListBox.Items.Add(page);
                    }
                }
            }
        }

        public void AddToFavorites()
        {
            if (m_LikedPagesListBox.SelectedItem != null)
            {
                Page selectedPage = m_LikedPagesListBox.SelectedItem as Page;

                if (!m_FavoritePagesListBox.Items.Contains(selectedPage))
                {
                    m_FavoritePagesListBox.Items.Add(selectedPage);
                    SaveFavoritePagesToFile();
                }
            }
        }

        public void RemoveFromFavorites()
        {
            if (m_FavoritePagesListBox.SelectedItem != null)
            {
                m_FavoritePagesListBox.Items.Remove(m_FavoritePagesListBox.SelectedItem);
                SaveFavoritePagesToFile();
            }
        }

        public void SaveOnLogout()
        {
            SaveFavoritePagesToFile();
        }
    }
}
