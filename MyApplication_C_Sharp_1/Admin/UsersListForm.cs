
using System.Linq;
using System.Data.Entity;

namespace MyApplication_C_Sharp_1.Admin
{
    public partial class usersListForm : Infrastructure.BaseForm
    {
        public usersListForm()
        {
            InitializeComponent();
        }

        private Models.DatabaseContext _myDatabaseContext;

        private void usersListForm_Load(object sender, System.EventArgs e)
        {
            _myDatabaseContext = new Models.DatabaseContext();
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            System.Collections.Generic.List<Models.User> oUser;

            if(string.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                oUser =
                    _myDatabaseContext.Users
                    .OrderBy(current => current.FullName)
                    .ToList()
                    ;
            }
            else
            {
                oUser =
                    _myDatabaseContext.Users
                    .Where(current => current.FullName.Contains(fullNameTextBox.Text))
                    .OrderBy(current=>current.FullName)
                    .ToList()
                    ;
            }

            UsersListBox.ValueMember = "Id";
            UsersListBox.DisplayMember = "FullName";
            UsersListBox.DataSource = oUser;

            if(oUser.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No User Found!");
            }
        }

        private void UsersListBox_DoubleClick(object sender, System.EventArgs e)
        {
            Models.User oSelectedUser =
                UsersListBox.SelectedItem as Models.User;

            if(oSelectedUser!= null)
            {
                Admin.updateUserForm updateUserForm = new Admin.updateUserForm();
                updateUserForm.UserId = oSelectedUser.Id;
                updateUserForm.ShowDialog();
            }
        }

        private void usersListForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if(_myDatabaseContext!=null)
            {
                _myDatabaseContext.Dispose();
                _myDatabaseContext = null;
            }
        }
    }
}
