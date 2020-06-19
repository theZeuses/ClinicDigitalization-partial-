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
    public partial class PatientMedicalHistory : UserControl
    {
        Form f;
        public PatientMedicalHistory(Form f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            string id = this.textBox1.Text;
            PatientRepo pr = new PatientRepo();
            Patient p = null;
            p=pr.GetPatient("SELECT * FROM Patients WHERE Id="+id);
            if (p == null)
            {
                MessageBox.Show("Invalid Id.");
            }
            else
            {
                MedicalHistoryRepo mr=new MedicalHistoryRepo();
                List<MedicalHistory> list = mr.GetMedicalHistoryList("SELECT * FROM MedicalHistories WHERE PatientId='"+id+"'");
                if (list.Count() == 0)
                {
                    MessageBox.Show("No entry found");
                }
                else
                {
                    MedicalHistoryForm mhf = new MedicalHistoryForm(f,list);
                    mhf.Visible = true;
                    f.Enabled = false;
                }
            }
        }
    }
}
