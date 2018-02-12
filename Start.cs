using System;
using System.Windows.Forms;

namespace Aryes
{
    /// <summary>
    /// 
    /// </summary>
    public class Start
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Settings.Default.Save();
                Application.EnableVisualStyles();
                Application.Run(new MainForm());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }
    }
}

