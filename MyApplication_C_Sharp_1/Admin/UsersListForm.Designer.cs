namespace MyApplication_C_Sharp_1.Admin
{
    partial class usersListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fulNameLable = new System.Windows.Forms.Label();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.UsersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // fulNameLable
            // 
            this.fulNameLable.AutoSize = true;
            this.fulNameLable.Location = new System.Drawing.Point(12, 14);
            this.fulNameLable.Name = "fulNameLable";
            this.fulNameLable.Size = new System.Drawing.Size(51, 13);
            this.fulNameLable.TabIndex = 0;
            this.fulNameLable.Text = "Full&Name";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullNameTextBox.Location = new System.Drawing.Point(69, 11);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.fullNameTextBox.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(269, 9);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(78, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "&Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // UsersListBox
            // 
            this.UsersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersListBox.FormattingEnabled = true;
            this.UsersListBox.Location = new System.Drawing.Point(69, 37);
            this.UsersListBox.Name = "UsersListBox";
            this.UsersListBox.Size = new System.Drawing.Size(278, 264);
            this.UsersListBox.TabIndex = 3;
            // 
            // usersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 321);
            this.Controls.Add(this.UsersListBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.fullNameTextBox);
            this.Controls.Add(this.fulNameLable);
            this.MinimumSize = new System.Drawing.Size(375, 359);
            this.Name = "usersListForm";
            this.Text = "UsersList";
            this.Load += new System.EventHandler(this.usersListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fulNameLable;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox UsersListBox;
    }
}