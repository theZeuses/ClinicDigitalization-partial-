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
    public partial class ManageDoctor : Form
    {
        Form f;
        DoctorRepo dr;

        public ManageDoctor(Form f)
        {
            InitializeComponent();
            this.f = f;
            this.dr = new DoctorRepo();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            List<Doctor> list = dr.GetDoctorList("SELECT * FROM Doctors");
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idTb.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.nameTb.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.roomNoTb.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            this.expertiseTb.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            this.idTb.Enabled = false;
            this.loadBtn.Text = "Refresh";
            this.insertBtn.Enabled = false;
            this.updateBtn.Enabled = true;
            this.deleteBtn.Enabled = true;
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            if (loadBtn.Text.Equals("Load"))
            {
                Doctor d = dr.GetDoctor("SELECT * FROM Doctors WHERE Id=" + idTb.Text);
                if (d == null)
                {
                    MessageBox.Show("Invalid Id");
                }
                else
                {
                    this.nameTb.Text = d.Name;
                    this.roomNoTb.Text = d.RoomNo + "";
                    this.expertiseTb.Text = d.Expertise;

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
                this.expertiseTb.Text = "";
                this.roomNoTb.Text = "";
                this.loadBtn.Text = "Load";

                this.insertBtn.Enabled = true;
                this.updateBtn.Enabled = false;
                this.deleteBtn.Enabled = false;
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            List<Doctor> list = new List<Doctor>();
            list = dr.GetDoctorList("SELECT * FROM Doctors");
            string keyword = this.searchTb.Text;
            if (keyword.Count() == 0)
                dataGridView1.DataSource = list;
            else
            {
                List<Doctor> searchedList = list.FindAll(X => (X.Name.ToLower()).Contains(keyword.ToLower()));
                dataGridView1.DataSource = searchedList;
            }
        }

        private void ManageDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
            this.Dispose();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to insert?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(idTb.Text);
                    int rn = Convert.ToInt32(roomNoTb.Text);
                    if (nameTb.Text.Length != 0 && expertiseTb.Text.Length != 0)
                    {
                        Doctor d = new Doctor();
                        d.Id = idTb.Text;
                        d.Name = nameTb.Text;
                        d.RoomNo = roomNoTb.Text;
                        d.Expertise = expertiseTb.Text;
                        bool inserted = dr.InsertDoctor(d);
                        if (inserted == true)
                        {
                            LogInRepo lr = new LogInRepo();
                            Entity.LogIn l = new Entity.LogIn();

                            l.Id = d.Id;

                            Random rnd = new Random();
                            int myRandomNo = rnd.Next(10000000, 99999999);

                            l.Password = myRandomNo.ToString();
                            l.Role = 1;

                            bool logInserted = lr.InsertUser(l);

                            if (logInserted)
                            {
                                MessageBox.Show("Doctor inserted with id: " + d.Id + "\nPassword: " + myRandomNo);
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("are you sure to update?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int rn = Convert.ToInt32(roomNoTb.Text);
                    if (nameTb.Text.Length != 0 && expertiseTb.Text.Length != 0)
                    {
                        Doctor d = new Doctor();
                        d.Id = idTb.Text;
                        d.Name = nameTb.Text;
                        d.RoomNo = roomNoTb.Text;
                        d.Expertise = expertiseTb.Text;
                        dr.UpdateDoctor(d);
                        searchTb_TextChanged(sender, e);
                        MessageBox.Show("Doctor Updated");
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
            DialogResult dialogResult = MessageBox.Show("Are sure to delete Doctor: "+nameTb.Text+"?", "Confirm to delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Doctor d = new Doctor();
                d.Id = idTb.Text;
                dr.DeleteDoctor(d);
                LogInRepo lr = new LogInRepo();
                Entity.LogIn l = new Entity.LogIn();
                l.Id = d.Id;
                lr.DeleteUser(l);
                MessageBox.Show("Doctor is deleted.");
                loadBtn_Click(sender, e);
                searchTb_TextChanged(sender, e);
            }
        }
    }
}
