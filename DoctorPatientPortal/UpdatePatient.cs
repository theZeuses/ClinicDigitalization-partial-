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
    public partial class UpdatePatient : UserControl
    {
        List<Patient> list;

        string bedNo, credit;
        Form f;

        public UpdatePatient(Form f)
        {
            InitializeComponent();

            this.f = f;
            list = AllPatientList();
            dataGridView1.DataSource = list;
            this.Update.Enabled = false;
            this.updateMedHisBtn.Enabled = false;
        }

        List<Patient> AllPatientList()
        {
            List<Patient> l = new List<Patient>();
            PatientRepo pr = new PatientRepo();
            string query = "SELECT * FROM Patients";

            l = pr.GetPatientList(query);
            return l;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idLabel.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.nameTB.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.ageTB.Text=dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.bedNo = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            this.credit = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.cnTB.Text=dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Substring(4);

            this.Update.Enabled = true;
            this.updateMedHisBtn.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            list = AllPatientList();
            string keyword = this.textBox1.Text;
            if (keyword.Count() == 0)
                dataGridView1.DataSource = list;
            else
            { 
                List<Patient> searchedList=list.FindAll(X=>(X.Name.ToLower()).Contains(keyword.ToLower()));
                dataGridView1.DataSource = searchedList;
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                Double ageD = Convert.ToDouble(this.ageTB.Text);
                Double cnD = Convert.ToDouble(this.cnTB.Text);
                if (nameTB.Text.Count() != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to update the patient info?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        PatientRepo pr = new PatientRepo();
                        Patient p = new Patient();
                        p.Name = nameTB.Text;
                        p.Age = ageD;
                        p.ContactNo = "+880"+cnTB.Text;
                        p.Id = idLabel.Text;
                        p.BedNo = this.bedNo;
                        p.Credit = Convert.ToDouble(this.credit);

                        bool updated = pr.UpdatePatient(p);

                        if (updated)
                        {
                            MessageBox.Show("Patient Updated");
                            this.idLabel.Text = "00000";
                            this.ageTB.Text = "";
                            this.nameTB.Text = "";
                            this.cnTB.Text = "";
                            this.Update.Enabled = false;
                            this.updateMedHisBtn.Enabled = false;

                            textBox1_TextChanged(sender,e);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Input");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void updateMedHisBtn_Click(object sender, EventArgs e)
        {
            UpdateMedicalHistory umh = new UpdateMedicalHistory(this.idLabel.Text, f);
            umh.Visible = true;
            f.Enabled = false;
        }
    }
}
