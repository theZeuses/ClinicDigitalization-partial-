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
    public partial class SelectPatient : UserControl
    {
        Form f;
        Button enterPatientBtn, updatePatientButton, bookCancelSlot;

        public SelectPatient(Form f,Button enterPatientBtn,Button updatePatientButton,Button bookCancelSlot)
        {
            InitializeComponent();

            this.f = f;
            this.enterPatientBtn = enterPatientBtn;
            this.updatePatientButton = updatePatientButton;
            this.bookCancelSlot = bookCancelSlot;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            PatientRepo pr = new PatientRepo();
            string query = "SELECT * FROM Patients WHERE Id="+this.textBox1.Text+"";
            Patient p = pr.GetPatient(query);
            if (p == null)
            {
                MessageBox.Show("Patient ID not valid.");
            }
            else
            {
                BookCancelSlot bcs = new BookCancelSlot(f, this, p,this.enterPatientBtn,this.updatePatientButton,this.bookCancelSlot);
                bcs.Location = new Point(281, 150);

                f.Controls.Add(bcs);
                f.Controls.Remove(this);

                this.updatePatientButton.Enabled = false;
                this.bookCancelSlot.Enabled = false;
                this.enterPatientBtn.Enabled = false;
            }
        }
    }
}
