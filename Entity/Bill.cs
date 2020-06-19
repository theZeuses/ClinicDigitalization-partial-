using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Bill
    {
        private string patientId;

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private string slotId;

        public string SlotId
        {
            get { return slotId; }
            set { slotId = value; }
        }

        private string fee;

        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }

        private string bedId;

        public string BedId
        {
            get { return bedId; }
            set { bedId = value; }
        }

        private string rent;

        public string Rent
        {
            get { return rent; }
            set { rent = value; }
        }

        private string rentingDate;

        public string RentingDate
        {
            get { return rentingDate; }
            set { rentingDate = value; }
        }

        private string medName;

        public string MedName
        {
            get { return medName; }
            set { medName = value; }
        }

        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        private string quantity;

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
