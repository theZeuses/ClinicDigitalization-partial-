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
    public partial class ManageSlot : UserControl
    {
        List<Button> buttonList;
        SlotRepo sr;
        Doctor d;
        Form f;

        public ManageSlot(Form f,Doctor d)
        {
            InitializeComponent();

            this.d = d;
            this.f = f;

            buttonList = new List<Button>();
            sr = new SlotRepo();

            buttonList.Add(button1);
            buttonList.Add(button2);
            buttonList.Add(button3);
            buttonList.Add(button4);
            buttonList.Add(button5);
            buttonList.Add(button6);
            buttonList.Add(button7);
            buttonList.Add(button8);
            buttonList.Add(button9);
            buttonList.Add(button10);
            buttonList.Add(button11);
            buttonList.Add(button12);
            buttonList.Add(button13);
            buttonList.Add(button14);
            buttonList.Add(button15);
            buttonList.Add(button16);
            buttonList.Add(button17);
            buttonList.Add(button18);
            buttonList.Add(button19);
            buttonList.Add(button20);
            buttonList.Add(button21);
            buttonList.Add(button22);
            buttonList.Add(button23);
            buttonList.Add(button24);
            buttonList.Add(button25);

            HideSlots();
            this.dateTimePicker1.Text = "";
        }

        public void ShowSlots()
        {
            HideSlots();
            List<Slot> slotList = new List<Slot>();

            string date=this.dateTimePicker1.Text;
            Console.WriteLine("date:"+date);
            string query = "SELECT * from Slots where SlotDate='" + date + "' AND DoctorId='"+d.Id+"'";
            slotList = sr.GetSlotList(query);
            if (slotList.Count != 0)
            {
                for (int i = 0; i < slotList.Count; i++)
                {
                    buttonList.ElementAt(i).Text =  slotList.ElementAt(i).SlotTime;
                    buttonList.ElementAt(i).Tag = slotList.ElementAt(i).Id;
                    buttonList.ElementAt(i).Visible = true;
                    if (!slotList.ElementAt(i).Availability.Equals( "true"))
                    {
                        buttonList.ElementAt(i).BackColor = Color.Red;
                    }
                    else
                    {
                        buttonList.ElementAt(i).BackColor = Color.Green;
                    }
                }
                label2.Visible = false;
            }
            else
            {
                label2.Visible = true;
            }

        }

        public void HideSlots()
        {
            foreach (Button b in buttonList) 
            {
                b.Visible = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowSlots();  
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.dateTimePicker1_ValueChanged(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f,this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            AvailUnavailSlot aus = new AvailUnavailSlot(f, this, btn.Tag.ToString());
            aus.Visible = true;
            this.Enabled = false;
            f.Enabled = false;
        }

        private void ManageSlot_EnabledChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1_ValueChanged(sender, e);
        }
        
    }
}
