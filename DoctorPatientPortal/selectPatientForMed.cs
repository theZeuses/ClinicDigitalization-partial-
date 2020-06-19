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
    public partial class SelectPatientForMed : UserControl
    {
        Form f;
        Button b1, b2;
        public SelectPatientForMed(Form f,Button b1,Button b2)
        {
            InitializeComponent();
            this.f = f;
            this.b1 = b1;
            this.b2 = b2;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            PatientRepo pr = new PatientRepo();
            MedicalHistoryRepo mhr = new MedicalHistoryRepo();
            Patient p = null;
            p = pr.GetPatient("SELECT * FROM Patients WHERE Id="+textBox1.Text);
            
            if (p == null)
            {
                MessageBox.Show("Invalid Id.");
            }
            else
            {
                if (mhr.GetMedicalHistoryList("SELECT * FROM MedicalHistories WHERE PatientId='" + p.Id + "'").Count==0)
                {
                    MessageBox.Show("Patient has no records.");
                }
                else
                {
                    b1.Enabled = false;
                    SellMedicine sm = new SellMedicine(f, this, p, b1, b2);
                    sm.Location = new Point(281, 150);
                    f.Controls.Add(sm);
                    f.Controls.Remove(this);
                }
            }
        }
    }
}
