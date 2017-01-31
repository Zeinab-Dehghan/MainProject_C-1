using System.Linq;
using System.Data.Entity;


namespace MyApplication_C_Sharp_1
{
    static class Program
    {
        static Program()
        {
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            //**************************************************
            LoginForm frmStartup = new LoginForm();

            System.Windows.Forms.Application.Run(frmStartup);

            if(frmStartup!=null)
            {
                if(frmStartup.IsDisposed==false)
                {
                    frmStartup.Dispose();
                }
                frmStartup = null;
            }
        }
    }
}
