using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    class RoundedButton : ButtonDecorator
    {
        private const int k_ArcSize = 25;

        public RoundedButton(IDecoratedButton i_DecoratedButton)
            : base(i_DecoratedButton)
        {
        }
        
        public override void ApplyDecoration()
        {
            base.ApplyDecoration();

            Button button = getBaseButton(m_Decorated);

            if (button != null)
            {
                GraphicsPath path = new GraphicsPath();
                //Numbers represent rotation angles
                const int k_CornerBottomRight = 0;
                const int k_CornerBottomLeft = 90;
                const int k_CornerTopLeft = 180;
                const int k_CornerTopRight = 270;

                path.AddArc(button.Width - k_ArcSize, button.Height - k_ArcSize, k_ArcSize, k_ArcSize, k_CornerBottomRight, 90); // bottom-right
                path.AddArc(0, button.Height - k_ArcSize, k_ArcSize, k_ArcSize, k_CornerBottomLeft, 90); // bottom-left
                path.AddArc(0, 0, k_ArcSize, k_ArcSize, k_CornerTopLeft, 90); // top-left
                path.AddArc(button.Width - k_ArcSize, 0, k_ArcSize, k_ArcSize, k_CornerTopRight, 90); // top-right
                path.CloseFigure(); 
                button.Region = new Region(path);
            }
        }

        private Button getBaseButton(IDecoratedButton i_DecoratedButton)
        {
            if (i_DecoratedButton is Button button)
            {
                return button;
            }
            else if (i_DecoratedButton is ButtonDecorator decorator)
            {
                return getBaseButton(decorator.m_Decorated);
            }
            else
            {
                return null;
            }
        }
    }
}
