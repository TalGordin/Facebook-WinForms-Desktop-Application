using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    internal class UserVideo : IMediaItem
    {
        private UserPhoto m_Thumbnail { get; }
        public string m_VideoURL { get; }
        public DateTime m_CreatedTime { get; }

        public UserVideo(Video i_Video)
        {
            m_VideoURL = i_Video.URL;
            string videoThumbnailURL = i_Video.PictureURL;

            if (i_Video.CreatedTime != null)
            {
                m_CreatedTime = (System.DateTime)i_Video.CreatedTime;
                m_Thumbnail = new UserPhoto(ref videoThumbnailURL, m_CreatedTime);
            }
        }

        public void Display(PictureBox i_PictureBox)
        {
            m_Thumbnail.Display(i_PictureBox);
            System.Diagnostics.Process.Start(m_VideoURL); //Opens video on Facebook in default browser
        }
    }
}
