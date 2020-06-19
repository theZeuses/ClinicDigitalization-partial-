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
    public partial class ManageReceptionist : Form
    {
        Form f;
        ReceptionistRepo rr;

        public ManageReceptionist(Form f)
        {
            InitializeComponent();
            this.f = f;
            this.rr = new ReceptionistRepo();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            List<Receptionist> list = rr.GetReceptionistList("SELECT * FROM Receptionists");
            dataGridView1.DataSource = list;
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (loadBtn.Text.Equals("Load"))
            {
                Receptionist d = rr.GetReceptionist("SELECT * FROM Receptionists WHERE Id=" + idTb.Text);
                if (d == null)
                {
                    MessageBox.Show("Invalid Id");
                }
                else
                {
                    this.nameTb.Text = d.Name;
                    this.salaryTb.Text = d.Salary + "";
                    this.shiftTb.Text = d.Shift;

                    this.loadBtn.Text = "Refresh";
                    this.idTb.Enabled = false;
                    this.insertBtn.Enabled = false;
                    this.updateBtn.Enabled = true;
                    this.deleteBtn.Enabled = true;
                }
            }
            else
            {
                this.idTb.Enabled = true;
                this.idTb.Text = "";
                this.nameTb.Text = "";
                this.salaryTb.Text = "";
                this.shiftTb.Text = "";
                this.loadBtn.Text = "Load";

                this.insertBtn.Enabled = true;
                this.updateBtn.Enabled = false;
                this.deleteBtn.Enabled = false;
            }
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to insert?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(idTb.Text);
                    int rn = Convert.ToInt32(salaryTb.Text);
                    if (nameTb.Text.Length != 0 && shiftTb.Text.Length != 0)
                    {
                        Receptionist d = new Receptionist();
                        d.Id = idTb.Text;
                        d.Name = nameTb.Text;
                        d.Salary = Convert.ToDouble(salaryTb.Text);
                        d.Shift = shiftTb.Text;
                        bool inserted = rr.InsertReceptionist(d);
                        if (inserted == true)
                        {
                            LogInRepo lr = new LogInRepo();
                            Entity.LogIn l = new Entity.LogIn();

                            l.Id = d.Id;

                            Random rnd = new Random();
                            int myRandomNo = rnd.Next(10000000, 99999999);

                            l.Password = myRandomNo.ToString();
                            l.Role = 2;

                            bool logInserted = lr.InsertUser(l);

                            if (logInserted)
                            {
                                MessageBox.Show("Receptionist inserted with id: " + d.Id + "\nPassword: " + myRandomNo);
                                loadBtn_Click(sender, e);
                                searchTb_TextChanged(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Operation is not successful.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Check ID no.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            List<Receptionist> list = new List<Receptionist>();
            list = rr.GetReceptionistList("SELECT * FROM Receptionists");
            string keyword = this.searchTb.Text;
            if (keyword.Count() == 0)
                dataGridView1.DataSource = list;
            else
            {
                List<Receptionist> searchedList = list.FindAll(X => (X.Name.ToLower()).Contains(keyword.ToLower()));
                dataGridView1.DataSource = searchedList;
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("are you sure to update?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int rn = Convert.ToInt32(salaryTb.Text);
                    if (nameTb.Text.Length != 0 && shiftTb.Text.Length != 0)
                    {
                        Receptionist d = new Receptionist();
                        d.Id = idTb.Text;
                        d.Name = nameTb.Text;
                        d.Salary = Convert.ToDouble(salaryTb.Text);
                        d.Shift = shiftTb.Text;
                        rr.UpdateReceptionist(d);
                        searchTb_TextChanged(sender, e);
                        MessageBox.Show("Receptionist Updated");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are sure to delete Receptionist: " + nameTb.Text + "?", "Confirm to delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Receptionist d = new Receptionist();
                d.Id = idTb.Text;
                rr.DeleteReceptionist(d);
                LogInRepo lr = new LogInRepo();
                Entity.LogIn l = new Entity.LogIn();
                l.Id = d.Id;
                lr.DeleteUser(l);
                MessageBox.Show("Receptionist is deleted.");
                loadBtn_Click(sender, e);
                searchTb_TextChanged(sender, e);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idTb.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.nameTb.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.salaryTb.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.shiftTb.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            this.idTb.Enabled = false;
            this.loadBtn.Text = "Refresh";
            this.insertBtn.Enabled = false;
            this.updateBtn.Enabled = true;
            this.deleteBtn.Enabled = true;
        }

        private void ManageReceptionist_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
            this.Dispose();
        }
    }
}
