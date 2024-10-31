using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class TransparentListBox : ListBox
    {
        private readonly Color r_BoxColor = Color.FromArgb(255, 173, 219, 255);
        public TransparentListBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle listBoxBounds = new Rectangle(0, 0, Width, Height);

            if (Parent != null)
            {
                using (var parentGraphics = Parent.CreateGraphics())
                {
                    var parentOffset = Parent.PointToScreen(Location);
                    var parentBounds = new Rectangle(parentOffset.X, parentOffset.Y, Width, Height);

                    e.Graphics.TranslateTransform(-parentOffset.X, -parentOffset.Y);

                    var parentPaintArgs = new PaintEventArgs(parentGraphics, parentBounds);

                    InvokePaintBackground(Parent, parentPaintArgs);
                    InvokePaint(Parent, parentPaintArgs);
                    e.Graphics.TranslateTransform(parentOffset.X, parentOffset.Y);
                }
            }

            for (int i = 0; i < Items.Count; i++)
            {
                var bounds = GetItemRectangle(i);

                if (listBoxBounds.Contains(bounds))
                {
                    var state = (SelectedIndex == i) ? DrawItemState.Selected : DrawItemState.Default;

                    OnDrawItem(new DrawItemEventArgs(e.Graphics, Font, bounds, i, state, ForeColor, BackColor));
                }
            }

            if (Items.Count == 0)
            {
                using (SolidBrush emptyBackgroundBrush = new SolidBrush(r_BoxColor))
                {
                    e.Graphics.FillRectangle(emptyBackgroundBrush, ClientRectangle);
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs i_Args)
        {
            if (i_Args.Index < 0)
                return;

            bool isEmpty = Items.Count == 0;

            i_Args.DrawBackground();
            using (SolidBrush backgroundBrush = new SolidBrush(r_BoxColor))
            {
                i_Args.Graphics.FillRectangle(backgroundBrush, i_Args.Bounds);
            }

            using (SolidBrush textBrush = new SolidBrush(i_Args.ForeColor))
            {
                i_Args.Graphics.DrawString(this.Items[i_Args.Index].ToString(), i_Args.Font, textBrush, i_Args.Bounds);
            }

            i_Args.DrawFocusRectangle();
        }
    }
}
