namespace Forms
{
    partial class ReceptionistHomePage
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
            this.rentBtn = new System.Windows.Forms.Button();
            this.prepareBillBtn = new System.Windows.Forms.Button();
            this.enterPatientBtn = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.receptionistProfile = new System.Windows.Forms.Button();
            this.receptionistName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rentBtn
            // 
            this.rentBtn.Location = new System.Drawing.Point(142, 314);
            this.rentBtn.Name = "rentBtn";
            this.rentBtn.Size = new System.Drawing.Size(89, 56);
            this.rentBtn.TabIndex = 17;
            this.rentBtn.Text = "Rent Room/Bed";
            this.rentBtn.UseVisualStyleBackColor = true;
            this.rentBtn.Click += new System.EventHandler(this.rentBtn_Click);
            // 
            // prepareBillBtn
            // 
            this.prepareBillBtn.Location = new System.Drawing.Point(142, 426);
            this.prepareBillBtn.Name = "prepareBillBtn";
            this.prepareBillBtn.Size = new System.Drawing.Size(89, 45);
            this.prepareBillBtn.TabIndex = 16;
            this.prepareBillBtn.Text = "Prepare Bill";
            this.prepareBillBtn.UseVisualStyleBackColor = true;
            this.prepareBillBtn.Click += new System.EventHandler(this.prepareBillBtn_Click);
            // 
            // enterPatientBtn
            // 
            this.enterPatientBtn.Location = new System.Drawing.Point(142, 211);
            this.enterPatientBtn.Name = "enterPatientBtn";
            this.enterPatientBtn.Size = new System.Drawing.Size(89, 50);
            this.enterPatientBtn.TabIndex = 15;
            this.enterPatientBtn.Text = "Enter New Patient";
            this.enterPatientBtn.UseVisualStyleBackColor = true;
            this.enterPatientBtn.Click += new System.EventHandler(this.enterPatientBtn_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(1193, 22);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(75, 23);
            this.logOut.TabIndex = 14;
            this.logOut.Text = "log out";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // receptionistProfile
            // 
            this.receptionistProfile.Location = new System.Drawing.Point(1068, 22);
            this.receptionistProfile.Name = "receptionistProfile";
            this.receptionistProfile.Size = new System.Drawing.Size(75, 23);
            this.receptionistProfile.TabIndex = 13;
            this.receptionistProfile.Text = "profile";
            this.receptionistProfile.UseVisualStyleBackColor = true;
            this.receptionistProfile.Click += new System.EventHandler(this.receptionistProfile_Click);
            // 
            // receptionistName
            // 
            this.receptionistName.AutoSize = true;
            this.receptionistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receptionistName.Location = new System.Drawing.Point(247, 94);
            this.receptionistName.Name = "receptionistName";
            this.receptionistName.Size = new System.Drawing.Size(92, 31);
            this.receptionistName.TabIndex = 12;
            this.receptionistName.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Welcome back,";
            // 
            // ReceptionistHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.rentBtn);
            this.Controls.Add(this.prepareBillBtn);
            this.Controls.Add(this.enterPatientBtn);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.receptionistProfile);
            this.Controls.Add(this.receptionistName);
            this.Controls.Add(this.label1);
            this.Name = "ReceptionistHomePage";
            this.Text = "ReceptionistHomePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReceptionistHomePage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Button receptionistProfile;
        private System.Windows.Forms.Label receptionistName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button rentBtn;
        public System.Windows.Forms.Button prepareBillBtn;
        public System.Windows.Forms.Button enterPatientBtn;
    }
}