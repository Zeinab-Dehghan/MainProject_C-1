
using System.Linq;
using System.Data.Entity;

namespace MyApplication_C_Sharp_1.Admin
{
    public partial class updateUserForm : Infrastructure.BaseForm
    {
        public updateUserForm()
        {
            InitializeComponent();
        }

        public System.Guid UserId { get; set; }

        private void updateUserForm_Load(object sender, System.EventArgs e)
        {
            Models.DatabaseContext oDatabaseContext = null;

            try
            {
                oDatabaseContext = new Models.DatabaseContext();

                Models.User oUser =
                    oDatabaseContext.Users
                    .Where(current => current.Id == UserId)
                    .FirstOrDefault()
                    ;

                if(oUser==null)
                {
                    System.Windows.Forms.MessageBox.Show("There is not such a user!");
                    Close();
                }

                isActiveCheckBox.Checked = oUser.IsActive;
                isAdminCheckBox.Checked = oUser.IsAdmin;
                fullNameTextBox.Text = oUser.FullName;
                descriptionTextBox.Text = oUser.Description;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                Close();
            }
            finally
            {

            }
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            Models.DatabaseContext oDatabaseContext = null;

            try
            {
                oDatabaseContext = new Models.DatabaseContext();

                Models.User oUser =
                    oDatabaseContext.Users
                    .Where(current => current.Id == UserId)
                    .FirstOrDefault()
                    ;

                if(oUser==null)
                {
                    System.Windows.Forms.MessageBox.Show("There is not such a user!");
                    Close();
                }

                oUser.IsActive = isActiveCheckBox.Checked;
                oUser.IsAdmin = isAdminCheckBox.Checked;
                oUser.FullName = fullNameTextBox.Text;
                oUser.Description = descriptionTextBox.Text;

                oDatabaseContext.SaveChanges();
                Close();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }

        private void updateUserForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {            
        }
    }
}
