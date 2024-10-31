using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class BasicButton : System.Windows.Forms.Button , IDecoratedButton
    {
        public void ApplyDecoration() {}
        public Control GetControl()
        {
            return this;
        }
    }
}
