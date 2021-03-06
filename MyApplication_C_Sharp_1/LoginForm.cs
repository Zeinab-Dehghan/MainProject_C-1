﻿using System.Linq;
using System.Data.Entity;

namespace MyApplication_C_Sharp_1
{
    public partial class loginForm : Infrastructure.BaseForm
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, System.EventArgs e)
        {

        }

        private void exitButton_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void resetButton_Click(object sender, System.EventArgs e)
        {
            usernameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;

            usernameTextBox.Focus();
        }

        private void registerButton_Click(object sender, System.EventArgs e)
        {            
            registerForm registerForm = new registerForm();
            registerForm.ShowDialog();
        }

        private void loginButton_Click(object sender, System.EventArgs e)
        {
            //**************************************
            if((string.IsNullOrWhiteSpace(usernameTextBox.Text))||
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

            //**************************************
            Models.DatabaseContext oDatabaseContext = null;

            try
            {
                oDatabaseContext = new Models.DatabaseContext();

                Models.User oUser =
                    oDatabaseContext.Users
                    .Where(current => string.Compare(current.Username,
                    usernameTextBox.Text, true) == 0)
                    .FirstOrDefault()
                    ;
                if(oUser==null)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Username and/or Password is not correct!");
                    return;
                }
                if(string.Compare(oUser.Password,passwordTextBox.Text,
                    ignoreCase:false)!=0)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Username and/or Password is not correct!");
                    return;
                }
                if (oUser.IsActive==false)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "You can not login to this application!Please contact support.");
                    return;
                }
                Infrastructure.Utility.AuthenticatedUser = oUser;
                Hide();
                mainForm mainForm = new mainForm();
                mainForm.Show();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error:"+ex.Message);
            }
            finally
            {
                if(oDatabaseContext!=null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
            //**************************************           
        }
    }
}
