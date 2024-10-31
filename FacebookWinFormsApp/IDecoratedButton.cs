using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IDecoratedButton
    {
        void ApplyDecoration();
        Control GetControl();
    }
}
