using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;
using Entity;


namespace Forms
{
    public partial class RentBed : UserControl
    {
        Form f;
        Button rentBtn, enterPatientBtn, prepareBillBtn;

        public RentBed(Form f,Button rentBtn,Button enterPatientBtn,Button prepareBillBtn)
        {
            InitializeComponent();
            this.f = f;
            this.rentBtn = rentBtn;
            this.enterPatientBtn = enterPatientBtn;
            this.prepareBillBtn = prepareBillBtn;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            Patient p=null;
            PatientRepo pr = new PatientRepo();
            string query = "SELECT * FROM Patients WHERE id="+this.patientId.Text;
            p = pr.GetPatient(query);
            if (p == null)
            {
                MessageBox.Show("Invalid Id.");
            }
            else
            {
                BedRenting br = new BedRenting(f,this,p,this.rentBtn,this.enterPatientBtn,this.prepareBillBtn);
                br.Location = new Point(281, 150);
                f.Controls.Add(br);
                f.Controls.Remove(this);

                this.enterPatientBtn.Enabled = false;
                this.prepareBillBtn.Enabled = false;
                this.rentBtn.Enabled = false;
            }
        }
    }
}
