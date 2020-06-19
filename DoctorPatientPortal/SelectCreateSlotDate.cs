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
    public partial class SelectCreateSlotDate : UserControl
    {
        Form f;
        CreateSlot createSlot;
        Button mngBtn, hsBtn, crtSlot;
        Doctor d;

        public SelectCreateSlotDate(Doctor d,Form f,Button mngBtn,Button hsBtn,Button crtSlot)
        {
            InitializeComponent();
            this.f = f;
            this.mngBtn = mngBtn;
            this.hsBtn = hsBtn;
            this.crtSlot = crtSlot;
            this.d = d;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SlotRepo sr = new SlotRepo();
            List<Slot> slotList = new List<Slot>();

            string query = "SELECT * FROM SLOTS WHERE SlotDate='" + dateTimePicker1.Text + "'";

            slotList = sr.GetSlotList(query);

            if (slotList.Count == 0)
            {
                createSlot = new CreateSlot(d,this, f, mngBtn, hsBtn, crtSlot, dateTimePicker1.Text);
                createSlot.Location = new Point(281, 150);
                f.Controls.Add(this.createSlot);

                mngBtn.Enabled = false;
                hsBtn.Enabled = false;
                crtSlot.Enabled = false;

                f.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("Slots have already been created for this date.");
            }
        }
    }
}
