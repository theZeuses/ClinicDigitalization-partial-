using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Drug
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string producerComapany;

        public string ProducerComapany
        {
            get { return producerComapany; }
            set { producerComapany = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private double availableQuantity;

        public double AvailableQuantity
        {
            get { return availableQuantity; }
            set { availableQuantity = value; }
        }
    }
}
