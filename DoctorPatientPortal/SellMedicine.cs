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
using System.IO;
using Microsoft.VisualBasic;

namespace Forms
{
    public partial class SellMedicine : UserControl
    {
        Form f;
        UserControl u;
        Patient p;
        MedicalHistoryRepo mhr;
        DrugRepo dr;
        MedPurchaseHistoryRepo mphr;
        PatientRepo pr;

        List<Drug> dList;
        List<MedicalHistory> mList;
        List<PurchasedDrug> pList;
        string date;

        Button b1, b2;

        public SellMedicine(Form f,UserControl u,Patient p,Button b1,Button b2)
        {
            InitializeComponent();
            this.f = f;
            this.u = u;
            this.p = p;
            this.b1 = b1;
            this.b2 = b2;

            this.patientIdLabel.Text=p.Id;

            mhr=new MedicalHistoryRepo();
            mList=mhr.GetMedicalHistoryList("SELECT * FROM MedicalHistories WHERE PatientId='"+p.Id+"'");

            comboBox1.DataSource=mList;
            comboBox1.DisplayMember="Date";
            comboBox1.ValueMember="Date";

            dr = new DrugRepo();
            dList = dr.GetDrugList("SELECT * FROM Drugs WHERE AvailableQuantity>0");

            dataGridView1.DataSource = dList;

            pList = new List<PurchasedDrug>();
            dataGridView2.DataSource = pList;

            mphr = new MedPurchaseHistoryRepo();
            pr = new PatientRepo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dList = dr.GetDrugList("SELECT * FROM Drugs WHERE AvailableQuantity>0");
            if (textBox1.Text.Length == 0)
            {
                dataGridView1.DataSource = dList;
            }
            else
            {
                List<Drug> searchedList = dList.FindAll(X => (X.Name.ToLower()).Contains(textBox1.Text.ToLower()));
                dataGridView1.DataSource = searchedList;
            }
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            MedicalHistory mh;
            if (comboBox1.SelectedValue.GetType() == typeof(string))
            {
                date = comboBox1.SelectedValue.ToString();
                mh = this.mList.Find(x => x.Date.Equals(date));
            }
            else
            {
                mh = (MedicalHistory)comboBox1.SelectedValue;
                date = mh.Date;
            }
            Image img = Base64ToImage(mh.Data);
            MHFforPharma mhff = new MHFforPharma(img, this.viewBtn, this.historyBtn);
            mhff.Visible = true;
            this.viewBtn.Enabled = false;
            this.historyBtn.Enabled = false;
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            MedicalHistory mh;
            if (comboBox1.SelectedValue.GetType() == typeof(string))
            {
                date = comboBox1.SelectedValue.ToString();
                mh = this.mList.Find(x => x.Date.Equals(date));
            }
            else
            {
                mh = (MedicalHistory)comboBox1.SelectedValue;
                date = mh.Date;
            }

            string query = "SELECT * FROM MedPurchaseHistories WHERE PatientId='"+this.patientIdLabel.Text+"' AND EntryDate='"+this.date+"'";

            List<MedPurchaseHistory> list = mphr.GetMedPurchaseHistoryList(query);

            MedPurchaseHistoryForm mphf = new MedPurchaseHistoryForm(list, this.viewBtn, this.historyBtn);
            mphf.Visible = true;
            this.viewBtn.Enabled = false;
            this.historyBtn.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int quantity = Convert.ToInt32(Interaction.InputBox("Input number of piece of " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), "Quantity", ""));
                if (quantity > 0)
                {
                    double availableQuantity = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    if (availableQuantity >= quantity)
                    {
                        PurchasedDrug pd = new PurchasedDrug();
                        pd.Name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        pd.ProducerComapany = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        pd.Price = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                        pd.AvailableQuantity = availableQuantity;
                        pd.Quantity = quantity;
                        pList.Add(pd);
                        List<PurchasedDrug> p2List = new List<PurchasedDrug>();
                        foreach (PurchasedDrug temppd in pList)
                        {
                            if (temppd != null)
                            {
                                p2List.Add(temppd);
                            }
                        }
                        pList = p2List;
                        dataGridView2.DataSource = pList;
                    }
                    else
                    {
                        MessageBox.Show("Not enough available quantity");
                    }
                }
                else
                {
                    MessageBox.Show("Please input a valid quantity");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input a valid quantity");
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int quantity = Convert.ToInt32(Interaction.InputBox("Input number of piece of " + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString(), "Quantity", dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (quantity == 0)
                {
                    PurchasedDrug pd=pList.Find(x => x.Name.Equals(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    pList.Remove(pd);
                    List<PurchasedDrug> p2List=new List<PurchasedDrug>();
                    foreach (PurchasedDrug temppd in pList)
                    {
                        if (temppd != null)
                        {
                            p2List.Add(temppd);
                        }
                    }
                    pList = p2List;
                    dataGridView2.DataSource = pList;
                }
                else if (quantity > 0)
                {
                    if (Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells[4].Value) >= quantity)
                    {
                        pList.Find(x => x.Name.Equals(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString())).Quantity = quantity;
                        dataGridView2.DataSource = pList;
                    }
                    else
                    {
                        MessageBox.Show("Not enough available quantity");
                    }
                }
                else
                {
                    MessageBox.Show("Please input a valid quantity");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input a valid quantity");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pList.Count != 0)
            {
                DrugRepo dr = new DrugRepo();
                double cost = 0;
                for (int i = 0; i < pList.Count; i++)
                {
                    double price = pList.ElementAt(i).Price;
                    double quantity = pList.ElementAt(i).Quantity;
                    cost += price * quantity;
                }

                DialogResult dialogResult = MessageBox.Show("Total Cost BDT " + cost + "\nAre you sure to continue?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool flag = true;
                    BillRepo br = new BillRepo();
                    for (int i = 0; i < pList.Count; i++)
                    {
                        MedPurchaseHistory mph = new MedPurchaseHistory();
                        Bill b = new Bill();
                        b.PatientId = p.Id;
                        b.MedName = pList.ElementAt(i).Name;
                        b.Price = pList.ElementAt(i).Price+"";
                        b.Quantity = pList.ElementAt(i).Quantity.ToString();
                        b.Rent = "";
                        b.RentingDate = "";
                        b.SlotId = "";
                        b.BedId = "";
                        b.Fee = "";
                        mph.PatientId = p.Id;
                        mph.EntryDate = date;
                        mph.DrugName = pList.ElementAt(i).Name;
                        mph.PurchaseDate = DateTime.Today.ToString("dd-MM-yyyy");
                        mph.Quantity = pList.ElementAt(i).Quantity.ToString();
                        mph.Cost = cost.ToString();

                        flag = mphr.InsertMedPurchaseHistory(mph);
                        if (flag)
                        {
                            this.p.Credit += cost;
                            pr.UpdatePatient(p);

                            Drug d = new Drug();
                            d.Name = pList.ElementAt(i).Name;
                            d.ProducerComapany = pList.ElementAt(i).ProducerComapany;
                            d.Price = pList.ElementAt(i).Price;
                            d.AvailableQuantity = pList.ElementAt(i).AvailableQuantity;
                            d.AvailableQuantity -= pList.ElementAt(i).Quantity;

                            dr.UpdateDrug(d);
                            if (!br.InsertBill(b))
                                MessageBox.Show("Problem");
                        }
                    }
                    if (flag)
                    {
                        MessageBox.Show("Operation SuccesFull.");
                        List<PurchasedDrug> newList = new List<PurchasedDrug>();
                        pList = newList;
                        dataGridView2.DataSource = pList;

                        dList = dr.GetDrugList("SELECT * FROM Drugs WHERE AvailableQuantity>0");

                        dataGridView1.DataSource = dList;
                    }
                    else
                    {
                        MessageBox.Show("Operation is not 100% successfull.");
                        List<PurchasedDrug> newList = new List<PurchasedDrug>();
                        pList = newList;
                        dataGridView2.DataSource = pList;

                        dList = dr.GetDrugList("SELECT * FROM Drugs WHERE AvailableQuantity>0");

                        dataGridView1.DataSource = dList;
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                MessageBox.Show("No Drug selected");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.Controls.Add(u);
            f.Controls.Remove(this);
            b1.Enabled = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            MedicalHistory mh;
            if (comboBox1.SelectedValue.GetType() == typeof(string))
            {
                date = comboBox1.SelectedValue.ToString();
                mh = this.mList.Find(x => x.Date.Equals(date));
            }
            else
            {
                mh = (MedicalHistory)comboBox1.SelectedValue;
                date = mh.Date;
            }
        }

    }
}
