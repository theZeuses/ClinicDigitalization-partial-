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

namespace Forms
{
    public partial class MedPurchaseHistoryForm : Form
    {
        List<MedPurchaseHistory> list;
        Button b1, b2;

        public MedPurchaseHistoryForm(List<MedPurchaseHistory> list,Button b1,Button b2)
        {
            InitializeComponent();
            this.list = list;
            this.b1 = b1;
            this.b2 = b2;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            dataGridView1.DataSource = list;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;

            List<MedPurchaseHistory> newList = new List<MedPurchaseHistory>();
            foreach (MedPurchaseHistory temp in list)
            {
                if (temp != null)
                {
                    newList.Add(temp);
                }
            }
            list = newList;

            if (keyword.Length == 0)
            { 
                dataGridView1.DataSource = list;
            }
            else
            {
                List<MedPurchaseHistory> searchedList = list.FindAll(X => (X.DrugName.ToLower()).Contains(keyword.ToLower()));
                dataGridView1.DataSource = searchedList;
            }
        }

        private void MedPurchaseHistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.b1.Enabled = true;
            this.b2.Enabled = true;
        }
    }
}
