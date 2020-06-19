using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;

namespace Forms
{
    public partial class AssistantProfile : Form
    {
        Assistant r;
        Form f;
        Entity.LogIn l;

        public AssistantProfile(Assistant r,Form f,Entity.LogIn l)
        {
            InitializeComponent();
            this.r = r;
            this.f = f;

            this.l = l;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.idLabel.Text = r.Id;
            this.nameLabel.Text = r.Name;
            this.salaryLabel.Text = r.Salary.ToString();
            this.shiftLabel.Text = r.Shift;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            f.Enabled = true;
            this.Dispose();
        }

        private void AssistantProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
            this.Dispose();
        }

        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            ChangePassword Cp = new ChangePassword(l);
            Cp.Visible = true;
        }
    }
}
