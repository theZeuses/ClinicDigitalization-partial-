using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Repository;


namespace Forms
{
    public partial class LogIn : UserControl
    {
        Form f;
        public LogIn(Form f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            LogInRepo lr = new LogInRepo();
            string query = "SELECT * FROM LogIns WHERE Id="+this.userId.Text+" AND Password='"+this.password.Text+"'";
            Entity.LogIn l = lr.GetUser(query);
            if (l == null)
            {
                MessageBox.Show("Invalid Credentials");
            }
            else
            {
                if (l.Role == 1)
                {
                    DoctorHomePage dhp = new DoctorHomePage(l);
                    dhp.Visible = true;
                    f.Visible=false;
                }
                else if (l.Role == 2)
                {
                    ReceptionistHomePage rhp = new ReceptionistHomePage(l);
                    rhp.Visible = true;
                    f.Visible = false;
                }
                else if (l.Role == 3)
                {
                    AssistantHomePage ahp = new AssistantHomePage(l);
                    ahp.Visible = true;
                    f.Visible = false;
                }
                else if (l.Role == 4)
                {
                    PharmacistHomePage php = new PharmacistHomePage(l);
                    php.Visible = true;
                    f.Visible = false;
                }
                else if (l.Role == 0)
                {
                    AdminHomePage ahp = new AdminHomePage(l);
                    ahp.Visible = true;
                    f.Visible = false;
                }
            }
        }
    }
}
