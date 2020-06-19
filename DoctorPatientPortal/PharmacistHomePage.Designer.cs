namespace Forms
{
    partial class PharmacistHomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sellMedicineBtn = new System.Windows.Forms.Button();
            this.availableMedicineBtn = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.pharmacistProfile = new System.Windows.Forms.Button();
            this.pharmacistName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sellMedicineBtn
            // 
            this.sellMedicineBtn.Location = new System.Drawing.Point(143, 312);
            this.sellMedicineBtn.Name = "sellMedicineBtn";
            this.sellMedicineBtn.Size = new System.Drawing.Size(89, 51);
            this.sellMedicineBtn.TabIndex = 16;
            this.sellMedicineBtn.Text = "Sell Medicine";
            this.sellMedicineBtn.UseVisualStyleBackColor = true;
            this.sellMedicineBtn.Click += new System.EventHandler(this.sellMedicineBtn_Click);
            // 
            // availableMedicineBtn
            // 
            this.availableMedicineBtn.Location = new System.Drawing.Point(143, 228);
            this.availableMedicineBtn.Name = "availableMedicineBtn";
            this.availableMedicineBtn.Size = new System.Drawing.Size(89, 50);
            this.availableMedicineBtn.TabIndex = 15;
            this.availableMedicineBtn.Text = "Available Medicine";
            this.availableMedicineBtn.UseVisualStyleBackColor = true;
            this.availableMedicineBtn.Click += new System.EventHandler(this.availableMedicineBtn_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(1188, 33);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(75, 23);
            this.logOut.TabIndex = 14;
            this.logOut.Text = "log out";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // pharmacistProfile
            // 
            this.pharmacistProfile.Location = new System.Drawing.Point(1078, 33);
            this.pharmacistProfile.Name = "pharmacistProfile";
            this.pharmacistProfile.Size = new System.Drawing.Size(75, 23);
            this.pharmacistProfile.TabIndex = 13;
            this.pharmacistProfile.Text = "profile";
            this.pharmacistProfile.UseVisualStyleBackColor = true;
            this.pharmacistProfile.Click += new System.EventHandler(this.pharmacistProfile_Click);
            // 
            // pharmacistName
            // 
            this.pharmacistName.AutoSize = true;
            this.pharmacistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pharmacistName.Location = new System.Drawing.Point(252, 88);
            this.pharmacistName.Name = "pharmacistName";
            this.pharmacistName.Size = new System.Drawing.Size(92, 31);
            this.pharmacistName.TabIndex = 12;
            this.pharmacistName.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Welcome back,";
            // 
            // PharmacistHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.sellMedicineBtn);
            this.Controls.Add(this.availableMedicineBtn);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.pharmacistProfile);
            this.Controls.Add(this.pharmacistName);
            this.Controls.Add(this.label1);
            this.Name = "PharmacistHomePage";
            this.Text = "PharmacistHomePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PharmacistHomePage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sellMedicineBtn;
        private System.Windows.Forms.Button availableMedicineBtn;
        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Button pharmacistProfile;
        private System.Windows.Forms.Label pharmacistName;
        private System.Windows.Forms.Label label1;
    }
}