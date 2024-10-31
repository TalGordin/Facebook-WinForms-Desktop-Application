using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IMediaItem
    {
        // $G$ CSS-014 (-3) Bad property name (should be in the form of: CamelCase).
        DateTime m_CreatedTime { get; }
        // $G$ CSS-013 (-3) Bad input variable name (should be in the form of i_PascalCased)
        void Display(PictureBox i_pictureBox);
    }
}
