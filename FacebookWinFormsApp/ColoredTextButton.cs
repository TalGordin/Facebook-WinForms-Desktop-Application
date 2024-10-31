using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class ColoredTextButton : ButtonDecorator
    {
        private Color m_TextColor;

        public ColoredTextButton(IDecoratedButton i_DecoratedButton, Color i_TextColor) 
            : base(i_DecoratedButton)
        {
            m_TextColor = i_TextColor;
        }

        public override void ApplyDecoration()
        {
            base.ApplyDecoration();

            Button button = getBaseButton(m_Decorated);

            if (button != null)
            {
                button.ForeColor = m_TextColor;
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
