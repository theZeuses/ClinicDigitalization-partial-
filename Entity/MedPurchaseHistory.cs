using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MedPurchaseHistory
    {
        private string patientId;

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private string entryDate;

        public string EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }

        private string drugName;

        public string DrugName
        {
            get { return drugName; }
            set { drugName = value; }
        }

        private string purchaseDate;

        public string PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }

        private string quantity;

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string cost;

        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
