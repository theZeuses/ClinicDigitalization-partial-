using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Patient
    {
        private string id;

        public string Id
        {
          get { return id; }
          set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double age;

        public double Age
        {
            get { return age; }
            set { age = value; }
        }

        private string bedNo;

        public string BedNo
        {
            get { return bedNo; }
            set { bedNo = value; }
        }

        private double credit;

        public double Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        private string contactNo;

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }
    }
}
