using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IMediaItem
    {
        DateTime m_CreatedTime { get; }
        void Display(PictureBox i_pictureBox);
    }
}
