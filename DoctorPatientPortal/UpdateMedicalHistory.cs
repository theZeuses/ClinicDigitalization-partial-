using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Repository;

namespace Forms
{
    public partial class UpdateMedicalHistory : Form
    {
        string pId;
        Form f;
        string selectedFileName = "";

        private static readonly ImageConverter _imageConverter = new ImageConverter();

        public UpdateMedicalHistory(string pId,Form f)
        {
            InitializeComponent();
            this.pId = pId;
            this.f = f;

            this.idLabel.Text = this.pId;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.uploadBtn.Enabled = false;
            
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.png)|*.png";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.selectedFileName = openFileDialog1.FileName;
                if (this.selectedFileName.Length != 0)
                {
                    this.uploadBtn.Enabled = true;
                    this.pictureBox1.ImageLocation = this.selectedFileName;
                    this.fileNameLabel.Text = openFileDialog1.SafeFileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void UpdateMedicalHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Enabled = true;
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            MedicalHistory m = new MedicalHistory();
            m.Data = ImageToBase64(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Png);
            m.PatientId = this.idLabel.Text;
            m.Date = DateTime.Today.ToString("dd-MM-yyyy");

            MedicalHistoryRepo mhr = new MedicalHistoryRepo();
            bool inserted=mhr.InsertMedicalHistory(m);
            if (inserted)
            {
                MessageBox.Show("Prescription Inserted.");
            }
            else
            {
                MessageBox.Show("Operation Failed."+m.Data.Length);

            }
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

    }
}
