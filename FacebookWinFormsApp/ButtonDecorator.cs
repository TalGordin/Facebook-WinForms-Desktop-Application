using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public abstract class ButtonDecorator : IDecoratedButton
    {
        public IDecoratedButton m_Decorated;
        public ButtonDecorator(IDecoratedButton i_DecoratedButton)
        { 
            m_Decorated = i_DecoratedButton; 
        }

        public virtual void ApplyDecoration()
        {
            m_Decorated.ApplyDecoration();
        }

        public Control GetControl()
        {
            return m_Decorated.GetControl();
        }
    }
}
