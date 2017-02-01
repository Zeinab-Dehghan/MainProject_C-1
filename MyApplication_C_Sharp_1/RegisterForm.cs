using System.Linq;
using System.Data.Entity;

namespace MyApplication_C_Sharp_1
{
    public partial class registerForm : Infrastructure.BaseForm
    {
        public registerForm()
        {
            InitializeComponent();
        }

        private void registerForm_Load(object sender, System.EventArgs e)
        {

        }

        private void exitButton_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void resetButton_Click(object sender, System.EventArgs e)
        {
            usernameTextBox.Text =string.Empty;
            passwordTextBox.Text = string.Empty;
            fullNameTextBox.Text = string.Empty;

            usernameTextBox.Focus();
        }

        private void registerButton_Click(object sender, System.EventArgs e)
        {
            //****************************************
            if(( string.IsNullOrWhiteSpace(usernameTextBox.Text))||
                (string.IsNullOrWhiteSpace(passwordTextBox.Text)))
            {
                usernameTextBox.Text =
                    usernameTextBox.Text.Trim();
                passwordTextBox.Text = 
                    passwordTextBox.Text.Trim();
                if(usernameTextBox.Text==string.Empty)
                {
                    usernameTextBox.Focus();
                }
                else
                {
                    passwordTextBox.Focus();
                }
                System.Windows.Forms.MessageBox.Show(
                    "Username and Password is requierd!");
            }
            //****************************************

            //****************************************
            string strErrorMessages = string.Empty;

            if (usernameTextBox.Text.Length<6)
            {
                strErrorMessages =
                    "Username length should be at least 6 characters!";
            }

            if (passwordTextBox.Text.Length<8)
            {
                if(strErrorMessages!=string.Empty)
                {
                    strErrorMessages += 
                        System.Environment.NewLine;
                }
                strErrorMessages =
                    "Password length should be at least 8 characters!";
            }
            if (strErrorMessages!=string.Empty)
            {
                System.Windows.Forms.MessageBox.Show(strErrorMessages);
                return;
            }
            //****************************************

            //****************************************
            Models.DatabaseContext oDatabaseContext = null;
            try
            {
                oDatabaseContext = 
                    new Models.DatabaseContext();

                Models.User oUser =
                    oDatabaseContext.Users
                    .Where(current => string.Compare(current.Username,
                                                        usernameTextBox.Text, true) == 0)
                    .FirstOrDefault()
                    ;
                if (oUser!=null)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "This Username is already exist!Please choose another one...");
                    usernameTextBox.Focus();
                    return;
                }
                oUser = new Models.User();

                oUser.IsActive = true;
                oUser.Username = usernameTextBox.Text;
                oUser.Password = passwordTextBox.Text;
                oUser.FullName = fullNameTextBox.Text;

                oDatabaseContext.Users.Add(oUser);
                oDatabaseContext.SaveChanges();

                System.Windows.Forms.MessageBox.Show("Registration Done!");

                usernameTextBox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
                fullNameTextBox.Text = string.Empty;

                usernameTextBox.Focus();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error:"+ex.Message);
            }
            finally
            {
                if (oDatabaseContext!=null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
            //****************************************
        }

        /* private void registerForm_Load(object sender, System.EventArgs e)
         {

         }*/
    }
}
