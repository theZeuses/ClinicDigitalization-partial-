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
    public partial class PharmacistHomePage : Form
    {
        Entity.LogIn l;
        AvailableMedicine am;
        SelectPatientForMed spm;
        Pharmacist p;

        public PharmacistHomePage(Entity.LogIn l)
        {
            InitializeComponent();

            this.l = l;

            this.availableMedicineBtn.Enabled = false;
            this.availableMedicineBtn.BackColor = Color.DimGray;
            this.sellMedicineBtn.BackColor = Color.Silver;
            am = new AvailableMedicine();
            am.Location = new Point(281, 150);
            this.Controls.Add(am);

            PharmacistRepo pr = new PharmacistRepo();
            p = pr.GetPharmacist("SELECT * FROM Pharmacists WHERE Id=" + l.Id);
            this.pharmacistName.Text = p.Name;
        }

        private void availableMedicineBtn_Click(object sender, EventArgs e)
        {
            this.availableMedicineBtn.Enabled = false;
            this.availableMedicineBtn.BackColor = Color.DimGray;
            this.sellMedicineBtn.Enabled = true;
            this.sellMedicineBtn.BackColor = Color.Silver;

            am = new AvailableMedicine();
            am.Location = new Point(281, 150);
            this.Controls.Add(am);
            if (spm != null)
                this.Controls.Remove(spm);
            
        }

        private void PharmacistHomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sellMedicineBtn_Click(object sender, EventArgs e)
        {
            this.availableMedicineBtn.Enabled = true;
            this.availableMedicineBtn.BackColor = Color.Silver;
            this.sellMedicineBtn.Enabled = false;
            this.sellMedicineBtn.BackColor = Color.DimGray;

            spm = new SelectPatientForMed(this,this.availableMedicineBtn,this.sellMedicineBtn);
            spm.Location = new Point(281, 150);
            this.Controls.Add(spm);

            if(am!=null)
            this.Controls.Remove(am);
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            WelcomeForm f = new WelcomeForm();
            f.Visible = true;
        }

        private void pharmacistProfile_Click(object sender, EventArgs e)
        {
            PharmacistProfile ap = new PharmacistProfile(p, this, l);
            this.Enabled = false;
            ap.Visible = true;
        }
    }
}
