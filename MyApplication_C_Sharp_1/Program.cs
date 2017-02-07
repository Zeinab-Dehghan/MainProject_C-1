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


            //**************************************************
            Models.DatabaseContext oDatabaseContext = null;

            try
            {
                oDatabaseContext = new Models.DatabaseContext();

                int intIsAdminCount =
                    oDatabaseContext.Users
                    .Where(current => current.IsAdmin)
                    .Count();

                if(intIsAdminCount==0)
                {
                    Models.User oUser = new Models.User();

                    oUser.IsActive = true;
                    oUser.IsAdmin = true;
                    oUser.FullName = "Zeinab Dehghan";
                    oUser.Username = "administrator";
                    oUser.Password = "116145690O";

                    oDatabaseContext.Users.Add(oUser);
                    oDatabaseContext.SaveChanges();
                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

                return;
            }
            finally
            {
                if(oDatabaseContext!=null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }

            }
            //**************************************************

            loginForm frmStartup = new loginForm();

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
