using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class RequestedMed
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double quantity;

        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
