using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Repository;

namespace Forms
{
    public partial class SelectPatientForBill : UserControl
    {
        Form f;
        public SelectPatientForBill(Form f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            PatientRepo pr = new PatientRepo();
            string query = "SELECT * FROM Patients WHERE Id=" + this.textBox1.Text + "";
            Patient p = pr.GetPatient(query);
            if (p == null)
            {
                MessageBox.Show("Patient ID not valid.");
            }
            else
            {
                this.Enabled = false;
                f.Enabled = false;
                PrepareBill pb = new PrepareBill(f, this, p);
                pb.Visible = true;
            }
        }
    }
}
