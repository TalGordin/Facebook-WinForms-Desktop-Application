using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class ColoredFrameButton : ButtonDecorator
    {
        private Color m_FrameColor;

        public ColoredFrameButton(IDecoratedButton i_DecoratedButton, Color i_FrameColor)
            : base(i_DecoratedButton)
        {
            m_FrameColor = i_FrameColor;
        }

        public override void ApplyDecoration()
        {
            base.ApplyDecoration();

            Button button = getBaseButton(m_Decorated);

            if (button != null)
            {
                button.Paint += (sender, e) =>
                {
                    drawFrame(e.Graphics, button);
                };
            }
        }

        private void drawFrame(Graphics i_Graphics, Button i_Button)
        {
            using (Pen framePen = new Pen(m_FrameColor, 1))
            {
                i_Graphics.DrawRectangle(framePen, 0, 0, i_Button.Width - 1, i_Button.Height - 1);
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
