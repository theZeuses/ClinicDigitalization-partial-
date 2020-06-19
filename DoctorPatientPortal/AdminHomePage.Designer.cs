namespace Forms
{
    partial class AdminHomePage
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
            this.manageAssistantBtn = new System.Windows.Forms.Button();
            this.manageDrugBtn = new System.Windows.Forms.Button();
            this.manageReceptionistBtn = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.doctorProfile = new System.Windows.Forms.Button();
            this.adminName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.managePharmacistBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageAssistantBtn
            // 
            this.manageAssistantBtn.Location = new System.Drawing.Point(623, 329);
            this.manageAssistantBtn.Name = "manageAssistantBtn";
            this.manageAssistantBtn.Size = new System.Drawing.Size(127, 72);
            this.manageAssistantBtn.TabIndex = 13;
            this.manageAssistantBtn.Text = "Manage Assistant";
            this.manageAssistantBtn.UseVisualStyleBackColor = true;
            this.manageAssistantBtn.Click += new System.EventHandler(this.manageAssistantBtn_Click);
            // 
            // manageDrugBtn
            // 
            this.manageDrugBtn.Location = new System.Drawing.Point(85, 329);
            this.manageDrugBtn.Name = "manageDrugBtn";
            this.manageDrugBtn.Size = new System.Drawing.Size(127, 63);
            this.manageDrugBtn.TabIndex = 12;
            this.manageDrugBtn.Text = "Manage Drug";
            this.manageDrugBtn.UseVisualStyleBackColor = true;
            this.manageDrugBtn.Click += new System.EventHandler(this.manageDrugBtn_Click);
            // 
            // manageReceptionistBtn
            // 
            this.manageReceptionistBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.manageReceptionistBtn.Location = new System.Drawing.Point(359, 329);
            this.manageReceptionistBtn.Name = "manageReceptionistBtn";
            this.manageReceptionistBtn.Size = new System.Drawing.Size(127, 68);
            this.manageReceptionistBtn.TabIndex = 11;
            this.manageReceptionistBtn.Text = "Manage Receptionist";
            this.manageReceptionistBtn.UseVisualStyleBackColor = false;
            this.manageReceptionistBtn.Click += new System.EventHandler(this.manageReceptionistBtn_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(1196, 97);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(75, 23);
            this.logOut.TabIndex = 10;
            this.logOut.Text = "log out";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // doctorProfile
            // 
            this.doctorProfile.Location = new System.Drawing.Point(1093, 97);
            this.doctorProfile.Name = "doctorProfile";
            this.doctorProfile.Size = new System.Drawing.Size(75, 23);
            this.doctorProfile.TabIndex = 9;
            this.doctorProfile.Text = "profile";
            this.doctorProfile.UseVisualStyleBackColor = true;
            this.doctorProfile.Click += new System.EventHandler(this.doctorProfile_Click);
            // 
            // adminName
            // 
            this.adminName.AutoSize = true;
            this.adminName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminName.Location = new System.Drawing.Point(272, 159);
            this.adminName.Name = "adminName";
            this.adminName.Size = new System.Drawing.Size(92, 31);
            this.adminName.TabIndex = 8;
            this.adminName.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome back,";
            // 
            // managePharmacistBtn
            // 
            this.managePharmacistBtn.Location = new System.Drawing.Point(1159, 329);
            this.managePharmacistBtn.Name = "managePharmacistBtn";
            this.managePharmacistBtn.Size = new System.Drawing.Size(127, 72);
            this.managePharmacistBtn.TabIndex = 13;
            this.managePharmacistBtn.Text = "Manage Pharmacist";
            this.managePharmacistBtn.UseVisualStyleBackColor = true;
            this.managePharmacistBtn.Click += new System.EventHandler(this.managePharmacistBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(902, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 72);
            this.button1.TabIndex = 13;
            this.button1.Text = "Manage Doctor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.managePharmacistBtn);
            this.Controls.Add(this.manageAssistantBtn);
            this.Controls.Add(this.manageDrugBtn);
            this.Controls.Add(this.manageReceptionistBtn);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.doctorProfile);
            this.Controls.Add(this.adminName);
            this.Controls.Add(this.label1);
            this.Name = "AdminHomePage";
            this.Text = "AdminHomePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminHomePage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button manageAssistantBtn;
        public System.Windows.Forms.Button manageDrugBtn;
        public System.Windows.Forms.Button manageReceptionistBtn;
        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Button doctorProfile;
        private System.Windows.Forms.Label adminName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button managePharmacistBtn;
        public System.Windows.Forms.Button button1;
    }
}