using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class ManagerFactory
    {
        public enum ManagerType
        {
            BirthdayStats,
            EngagementScore,
            FacebookFeatures,
            FavoritePages
        }

        public IFacebookManager CreateManager(ManagerType managerType, params object[] args)
        {
            IFacebookManager manager = null;

            switch (managerType)
            {
                case ManagerType.BirthdayStats:
                    //Ensure that args contains 2 labels
                    if (args.Length >= 2 && args[0] is Label && args[1] is Label)
                    {
                        manager = BirthdayStatsManager.Instance((Label)args[0], (Label)args[1]);
                    }
                    break;

                case ManagerType.EngagementScore:
                    //Ensure that args contains 2 objects of the correct types
                    if (args.Length >= 2 && args[0] is TextBox && args[1] is Label)
                    {
                        manager = EngagementScoreManager.Instance((TextBox)args[0], (Label)args[1]);
                    }
                    break;

                case ManagerType.FacebookFeatures:
                    //Ensure that args contains the necessary 5 parameters
                    if (args.Length >= 5 && args[0] is TextBox && args[1] is TransparentListBox && args[2] is PictureBox && args[3] is ListBox && args[4] is ListBox)
                    {
                        manager = FacebookFeaturesManager.Instance(
                            (TextBox)args[0],
                            (TransparentListBox)args[1],
                            (PictureBox)args[2],
                            (ListBox)args[3],
                            (ListBox)args[4]
                        );
                    }
                    break;

                case ManagerType.FavoritePages:
                    //Ensure that args contains 2 ListBox objects
                    if (args.Length >= 2 && args[0] is ListBox && args[1] is ListBox)
                    {
                        manager = FavoritePagesManager.Instance(
                            (ListBox)args[0],
                            (ListBox)args[1]
                        );
                    }
                    break;

                default:
                    throw new ArgumentException("Unknown manager type.");
            }

            return manager;
        }
    }
}
