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
using Repository;

namespace Forms
{
    public partial class AdminHomePage : Form
    {
        Entity.LogIn l;
        Admin a;

        public AdminHomePage(Entity.LogIn l)
        {
            InitializeComponent();

            this.l = l;

            AdminRepo ar = new AdminRepo();
            a = ar.GetAdmin("SELECT * FROM Admins WHERE Id="+l.Id);
            this.adminName.Text = a.Name;
        }

        private void AdminHomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageDoctor md = new ManageDoctor(this);
            md.Visible = true;
            this.Enabled = false;
        }

        private void manageDrugBtn_Click(object sender, EventArgs e)
        {
            ManageDrug md = new ManageDrug(this);
            md.Visible = true;
            this.Enabled = false;
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            WelcomeForm f = new WelcomeForm();
            f.Visible = true;
        }

        private void doctorProfile_Click(object sender, EventArgs e)
        {
            AdminProfile ap = new AdminProfile(a, this, l);
            this.Enabled = false;
            ap.Visible = true;
        }

        private void manageReceptionistBtn_Click(object sender, EventArgs e)
        {
            ManageReceptionist mr = new ManageReceptionist(this);
            mr.Visible = true;
            this.Enabled = false;
        }

        private void manageAssistantBtn_Click(object sender, EventArgs e)
        {
            ManageAssistant ma = new ManageAssistant(this);
            ma.Visible = true;
            this.Enabled = false;
        }

        private void managePharmacistBtn_Click(object sender, EventArgs e)
        {
            ManagePharmacist mp = new ManagePharmacist(this);
            mp.Visible = true;
            this.Enabled = false;
        }
    }
}
