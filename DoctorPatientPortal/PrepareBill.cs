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
    public partial class PrepareBill : Form
    {
        Form f;
        UserControl u;
        Patient p;
        List<Bill> list;
        BillRepo br;

        public PrepareBill(Form f,UserControl u,Patient p)
        {
            InitializeComponent();
            this.f = f;
            this.u = u;
            this.p = p;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            br = new BillRepo();
            list = br.GetBillList("SELECT * FROM Bills WHERE PatientId='" + p.Id + "'");

            this.idLabel.Text = p.Id;
            this.nameLabel.Text = p.Name;
            this.ageLabel.Text = p.Age+"";

            double docs = 0;
            double beds = 0;
            double meds = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).SlotId !="" && list.ElementAt(i).Fee != "")
                {
                    dataGridView1.Rows.Add(list.ElementAt(i).SlotId, list.ElementAt(i).Fee);
                    docs += Convert.ToDouble(list.ElementAt(i).Fee);
                }
                if (list.ElementAt(i).BedId != "" && list.ElementAt(i).Rent != "" && list.ElementAt(i).RentingDate != "")
                {
                    dataGridView2.Rows.Add(list.ElementAt(i).BedId, list.ElementAt(i).Rent, list.ElementAt(i).RentingDate);
                    DateTime d1 = DateTime.Parse(list.ElementAt(i).RentingDate);
                    DateTime d2 = DateTime.Now;
                    beds += (d2 - d1).Days * Convert.ToDouble(list.ElementAt(i).Rent);
                }
                if (list.ElementAt(i).MedName != "" && list.ElementAt(i).Price != "" && list.ElementAt(i).Quantity != "")
                {
                    dataGridView3.Rows.Add(list.ElementAt(i).MedName, list.ElementAt(i).Price, list.ElementAt(i).Quantity);
                    meds += Convert.ToDouble(list.ElementAt(i).Price) * Convert.ToDouble(list.ElementAt(i).Quantity);
                }
            }

            this.totalBedFee.Text = beds+"";
            this.totalDoctorFee.Text = docs+"";
            this.totalMedicineFee.Text = meds+"";

            double total = beds + docs + meds;

            this.totalLabel.Text = total + "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                MessageBox.Show("Payment is already cleared.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to continue?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Bill b = new Bill();
                    b.PatientId = p.Id;

                    Patient q = new Patient();
                    q.Id = p.Id;
                    q.Name = p.Name;
                    q.BedNo = "0";
                    q.Credit = 0;
                    q.ContactNo = p.ContactNo;
                    q.Age = p.Age;

                    Bed d = new Bed();
                    BedRepo bedRepo = new BedRepo();
                    d=bedRepo.GetBed("SELECT * FROM Beds WHERE Id="+p.BedNo);
                    d.Availability="true";

                    PatientRepo pr=new PatientRepo();
                    pr.UpdatePatient(q);
                    bedRepo.UpdateBed(d);
                    br.DeleteBill(b);
                    MessageBox.Show("Operation Successfull");
                    f.Enabled = true;
                    u.Enabled = true;
                    this.Dispose();
                }
            }
        }

        private void PrepareBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
            u.Enabled = true;
        }

    }
}
