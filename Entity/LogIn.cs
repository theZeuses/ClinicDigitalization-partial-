using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class LogIn
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int role;

        public int Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
