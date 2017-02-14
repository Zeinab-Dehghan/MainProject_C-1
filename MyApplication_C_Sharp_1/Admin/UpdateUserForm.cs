
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

        }
    }
}
