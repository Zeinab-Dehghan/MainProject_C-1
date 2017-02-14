using System.Linq;
using System.Data.Entity;

namespace MyApplication_C_Sharp_1
{
    public partial class changePasswordForm : Infrastructure.BaseForm
    {
        public changePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, System.EventArgs e)
        {

        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            string strErrorMessage = string.Empty;

            //**************************************************
            if (string.IsNullOrWhiteSpace(oldPasswordTextBox.Text))
            {
                strErrorMessage = "Old password is requierd!";
            }
            else
            {
                if(oldPasswordTextBox.Text.Length <8)
                {
                    strErrorMessage = "Old password length should be greater than or equal to 8 characters !";
                }
            }
            //**************************************************


            //**************************************************
            if (string.IsNullOrWhiteSpace(newPasswordTextBox.Text))
            {
                if(strErrorMessage!= string.Empty)
                {
                    strErrorMessage +=
                        System.Environment.NewLine;
                }
                strErrorMessage +=
                    "New password is reqierd!";
            }
            else
            {
                if(newPasswordTextBox.Text.Length <8)
                {
                    if (strErrorMessage != string.Empty)
                    {
                        strErrorMessage +=
                            System.Environment.NewLine;
                    }
                    strErrorMessage +=
                        "New password length should be greater than or equal to 8 characters !";
                }                
            }
            //**************************************************


            //**************************************************
            if (string.IsNullOrWhiteSpace(confirmNewPasswordTextBox.Text))
            {
                if (strErrorMessage != string.Empty)
                {
                    strErrorMessage +=
                        System.Environment.NewLine;
                }
                strErrorMessage +=
                    "Confirm New password is reqierd!";
            }
            else
            {
                if(string.Compare(newPasswordTextBox.Text,confirmNewPasswordTextBox.Text)!=0)
                {
                    if (strErrorMessage != string.Empty)
                    {
                        strErrorMessage +=
                            System.Environment.NewLine;
                    }
                    strErrorMessage +=
                        "The confirm New password is not equal to new password!";
                }
            }
            //**************************************************


            //**************************************************
            if (strErrorMessage!= string.Empty)
            {
                System.Windows.Forms.MessageBox.Show(strErrorMessage);
                return;
            }
            //**************************************************


            //**************************************************
            //**************************************************
            //**************************************************
            Models.DatabaseContext oDatabaseContext = null;
            try
            {
                oDatabaseContext = new Models.DatabaseContext();

                Models.User oUser =
                    oDatabaseContext.Users
                    .Where(current => current.Id == Infrastructure.Utility.AuthenticatedUser.Id)
                    .FirstOrDefault()
                    ;

                if(oUser == null)
                {
                    System.Windows.Forms.Application.Exit();
                }

                if(string.Compare(oUser.Password,oldPasswordTextBox.Text,ignoreCase: false)!=0)
                {
                    System.Windows.Forms.MessageBox.Show("The old Password is not correct!");
                    oldPasswordTextBox.Focus();
                    return;
                }
                oUser.Password = newPasswordTextBox.Text;
                oDatabaseContext.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Your password was changed successfully!");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (oDatabaseContext!=null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
            //**************************************************
            //**************************************************
            //**************************************************

        }

        private void exitButton_Click(object sender, System.EventArgs e)
        {
            Hide();
        }
    }
}
