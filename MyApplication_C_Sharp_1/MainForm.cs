﻿using System.Linq;
using System.Data.Entity;

namespace MyApplication_C_Sharp_1
{
    public partial class mainForm : Infrastructure.BaseForm
    {
        public mainForm()
        {
            InitializeComponent();
        }

      /*  private void MainForm_Load(object sender, System.EventArgs e)
        {

        }*/

        private void mainForm_Load(object sender, System.EventArgs e)
        {
            usernameToolStripStatusLabel.Text=
                "Welcome "+ Infrastructure.Utility.AuthenticatedUser.FullName;

            if(Infrastructure.Utility.AuthenticatedUser.IsAdmin==true)
            {
                administratorToolStripMenuItem.Visible = true;
            }
            else
            {
                administratorToolStripMenuItem.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.DialogResult enmResult =
                System.Windows.Forms.MessageBox.Show(
                    text:"آیا به خروج از برنامه اطمینان دارید؟"
                    ,caption:"سوال"
                    ,buttons: System.Windows.Forms.MessageBoxButtons.YesNo
                    ,icon: System.Windows.Forms.MessageBoxIcon.Question
                    ,defaultButton: System.Windows.Forms.MessageBoxDefaultButton.Button2
                    ,options: System.Windows.Forms.MessageBoxOptions.RightAlign |
                    System.Windows.Forms.MessageBoxOptions.RtlReading)
                    ;
            if(enmResult==System.Windows.Forms.DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }            
        }

        private void updateProfileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            updateProfileForm updateProfileForm = new updateProfileForm();            
            updateProfileForm.Show();
            updateProfileForm.MdiParent = this;
        }

        private void userListToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Admin.usersListForm oUserListFrom = new Admin.usersListForm();
            oUserListFrom.MdiParent = this;
            oUserListFrom.Show();
        }

        private void registrationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            registerForm oRegisterForm = new MyApplication_C_Sharp_1.registerForm();
            oRegisterForm.MdiParent = this;
            oRegisterForm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            changePasswordForm changePasswordForm = new changePasswordForm();
            changePasswordForm.MdiParent = this;
            changePasswordForm.Show();
        }
    }
}
