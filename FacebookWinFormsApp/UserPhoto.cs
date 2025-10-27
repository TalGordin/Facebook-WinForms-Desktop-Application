using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class UserPhoto : IMediaItem
    {
        public string m_PictureURL { get; }
        public DateTime m_CreatedTime { get; }

        public UserPhoto(Photo i_Photo)
        {
            m_PictureURL = i_Photo.PictureNormalURL;
            if (i_Photo.CreatedTime != null)
            {
                m_CreatedTime = (System.DateTime)i_Photo.CreatedTime;
            }
        }

        public UserPhoto(ref string io_PhotoURL, DateTime io_CreatedTime) 
        {
            m_PictureURL = io_PhotoURL;
            if (io_PhotoURL != null)
            {
                m_CreatedTime = io_CreatedTime;
            }
        }

        public void Display(PictureBox i_PictureBox)
        {
            i_PictureBox.ImageLocation = m_PictureURL;
        }
    }
}
