using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class TransparentTabPage : TabPage
    {
        public TransparentTabPage()
        {
            BackColor = Color.Transparent;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(107, 190, 255),
                Color.FromArgb(230, 244, 255),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    }
}