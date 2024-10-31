using System;
using System.Windows.Forms;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    // $G$ THE-001 (-18) Grade: 82 on patterns selection / accuracy in implementation / description / document / diagrams (see comments in the document).
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Clipboard.SetText("design.patterns20cc");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
