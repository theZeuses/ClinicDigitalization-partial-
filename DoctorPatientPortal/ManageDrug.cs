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
    public partial class ManageDrug : Form
    {
        DrugRepo dr = new DrugRepo();
        RequestedMedRepo rmr = new RequestedMedRepo();
        List<Drug> list;
        List<RequestedMed> rList;
        Form f;

        public ManageDrug(Form f)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.f = f;

            list = new List<Drug>();
            list = dr.GetDrugList("SELECT * FROM Drugs");

            dataGridView2.DataSource = list;

            rList = new List<RequestedMed>();
            rList = rmr.GetRequestedMedList("SELECT * FROM RequestedMeds");

            dataGridView1.DataSource = rList;

            this.insertBtn.Enabled = true;
            this.updateBtn.Enabled = false;
            this.deleteBtn.Enabled = false;
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            list = new List<Drug>();
            list = dr.GetDrugList("SELECT * FROM Drugs");

            string keyword = searchTb.Text;

            if (keyword.Length == 0)
            {
                dataGridView2.DataSource = list;
            }
            else
            {
                List<Drug> searchedList = list.FindAll(X => (X.Name.ToLower()).Contains(keyword.ToLower()));
                dataGridView2.DataSource = searchedList;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.nameTb.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.producerCompanyTB.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.priceTB.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.quantityTb.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();

            this.loadBtn.Text = "Refresh";
            this.insertBtn.Enabled = false;
            this.updateBtn.Enabled = true;
            this.deleteBtn.Enabled = true;
            this.nameTb.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to mark it as approved?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RequestedMed r = new RequestedMed();
                r.Name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                r.Quantity = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

                if (rmr.DeleteRequestedMed(r))
                {
                    List<RequestedMed> list = rmr.GetRequestedMedList("SELECT * FROM RequestedMeds");
                    dataGridView1.DataSource = list;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to insert?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Drug d = new Drug();
                d.Name = nameTb.Text.ToUpper();
                d.ProducerComapany = producerCompanyTB.Text;
                try
                {
                    d.Price = Convert.ToDouble(priceTB.Text);
                    d.AvailableQuantity = Convert.ToDouble(quantityTb.Text);

                    if (dr.InsertDrug(d))
                    {
                        MessageBox.Show("Inserted Succesfully");
                        loadBtn_Click_1(sender, e);
                        searchTb_TextChanged(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input or drug already in the database.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid input");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }           
        }

        private void ManageDrug_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
        }

        private void loadBtn_Click_1(object sender, EventArgs e)
        {

            if (loadBtn.Text.Equals("Load"))
            {
                Drug d = dr.GetDrug("SELECT * FROM Drugs WHERE Name='" + nameTb.Text.ToUpper()+"'");
                if (d == null)
                {
                    MessageBox.Show("Invalid Name");
                }
                else
                {
                    this.nameTb.Text = d.Name;
                    this.producerCompanyTB.Text = d.ProducerComapany;
                    this.priceTB.Text = d.Price + "";
                    this.quantityTb.Text = d.AvailableQuantity + "";

                    this.loadBtn.Text = "Refresh";
                    this.insertBtn.Enabled = false;
                    this.updateBtn.Enabled = true;
                    this.deleteBtn.Enabled = true;
                    this.nameTb.Enabled = false;
                }
            }
            else
            {
                this.nameTb.Text = "";
                this.producerCompanyTB.Text = "";
                this.priceTB.Text = "";
                this.quantityTb.Text = "";
                this.loadBtn.Text = "Load";

                this.insertBtn.Enabled = true;
                this.updateBtn.Enabled = false;
                this.deleteBtn.Enabled = false;
                this.nameTb.Enabled = true;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double availableQ = Convert.ToDouble(this.quantityTb.Text);
                double price = Convert.ToDouble(this.priceTB.Text);
                DialogResult dialogResult = MessageBox.Show("are you sure to update?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Drug d = new Drug();
                    d.Name = this.nameTb.Text;
                    d.Price = price;
                    d.AvailableQuantity = availableQ;
                    d.ProducerComapany = this.producerCompanyTB.Text;

                    if (dr.UpdateDrug(d))
                    {
                        MessageBox.Show("Drug Updated.");
                        searchTb_TextChanged(sender, e);

                    }
                    else
                    {
                        MessageBox.Show("Operation Failed");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Drug d = new Drug();
                d.Name = this.nameTb.Text;
                if (dr.DeleteDrug(d))
                {
                    MessageBox.Show("Drug Deleted.");
                    loadBtn_Click_1(sender, e);
                    searchTb_TextChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("Operation failed.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
