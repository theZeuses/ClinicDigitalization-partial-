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
using System.IO;
using System.Drawing.Imaging;

namespace Forms
{
    public partial class MedicalHistoryForm : Form
    {
        Form f;
        List<MedicalHistory> list;

        private static readonly ImageConverter _imageConverter = new ImageConverter();

        public MedicalHistoryForm(Form f,List<MedicalHistory> list)
        {
            InitializeComponent();
            this.f = f;
            this.list = list;

            this.label2.Text = list.ElementAt(0).PatientId;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.comboBox1.DataSource = this.list;
            this.comboBox1.DisplayMember = "Date";
            this.comboBox1.ValueMember = "Date";
            
        }

        private void MedicalHistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string date;
            MedicalHistory mh;
            if (comboBox1.SelectedValue.GetType() == typeof(string))
            {
                date= comboBox1.SelectedValue.ToString();
                mh = this.list.Find(x => x.Date.Equals(date));
            }
            else
            {
                mh = (MedicalHistory)comboBox1.SelectedValue;
            }
            
            pictureBox1.Image = Base64ToImage(mh.Data);
            //pictureBox1.ImageLocation = @"C:\Users\alsan\Documents\Visual Studio 2012\Projects\DoctorPatientPortal\MedicalHistory\output.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
        
    }
}
