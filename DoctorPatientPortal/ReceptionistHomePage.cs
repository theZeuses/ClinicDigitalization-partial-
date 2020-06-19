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
    public partial class ReceptionistHomePage : Form
    {
        Entity.LogIn l;
        RentBed rb;
        EnterNewPatient enp;
        SelectPatientForBill spfb;
        Receptionist r;


        public ReceptionistHomePage(Entity.LogIn l)
        {
            InitializeComponent();
            this.l = l;

            this.enterPatientBtn.BackColor = Color.DimGray;
            this.rentBtn.BackColor = Color.Silver;
            this.prepareBillBtn.BackColor = Color.Silver;

            enp = new EnterNewPatient();
            enp.Location = new Point(281, 150);
            this.Controls.Add(enp);
            this.enterPatientBtn.Enabled = false;

            r = getReceptionist();

            this.receptionistName.Text = r.Name;

        }

        private void enterPatientBtn_Click(object sender, EventArgs e)
        {
            this.enterPatientBtn.BackColor = Color.DimGray;
            this.rentBtn.BackColor = Color.Silver;
            this.prepareBillBtn.BackColor = Color.Silver;

            enp = new EnterNewPatient();
            enp.Location = new Point(281, 150);
            this.Controls.Add(enp);
            if(rb!=null)
                this.Controls.Remove(rb);
            if(spfb!=null)
                this.Controls.Remove(spfb);
            this.enterPatientBtn.Enabled = false;
            this.rentBtn.Enabled = true;
            this.prepareBillBtn.Enabled = true;
        }

        private void ReceptionistHomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void rentBtn_Click(object sender, EventArgs e)
        {
            this.enterPatientBtn.BackColor = Color.Silver;
            this.rentBtn.BackColor = Color.DimGray;
            this.prepareBillBtn.BackColor = Color.Silver;

            rb = new RentBed(this,this.rentBtn,this.enterPatientBtn,this.prepareBillBtn);
            rb.Location = new Point(281, 150);
            this.Controls.Add(rb);
            if(enp!=null)
                this.Controls.Remove(enp);
            if(spfb!=null)
                this.Controls.Remove(spfb);
            this.rentBtn.Enabled = false;
            this.enterPatientBtn.Enabled = true;
            this.prepareBillBtn.Enabled = true;
        }

        private Receptionist getReceptionist()
        {
            ReceptionistRepo rp = new ReceptionistRepo();
            string query = "SELECT * FROM Receptionists WHERE Id=" + l.Id;
            Receptionist R = rp.GetReceptionist(query);

            return R;
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            WelcomeForm f = new WelcomeForm();
            f.Visible = true;
        }

        private void receptionistProfile_Click(object sender, EventArgs e)
        {
            ReceptionistProfile rp = new ReceptionistProfile(r, this,l);
            this.Enabled = false;
            rp.Visible = true;
        }

        private void prepareBillBtn_Click(object sender, EventArgs e)
        {
            this.enterPatientBtn.BackColor = Color.Silver;
            this.rentBtn.BackColor = Color.Silver;
            this.prepareBillBtn.BackColor = Color.DimGray;

            this.rentBtn.Enabled = true;
            this.enterPatientBtn.Enabled = true;
            this.prepareBillBtn.Enabled = false;

            spfb = new SelectPatientForBill(this);
            spfb.Location = new Point(281, 150);
            this.Controls.Add(spfb);
            if(enp!=null)
                this.Controls.Remove(enp);
            if(rb!=null)
                this.Controls.Remove(rb);
        }
    }
}
