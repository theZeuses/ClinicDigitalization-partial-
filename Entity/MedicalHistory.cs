using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MedicalHistory
    {
        private string patientId;

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        private string data;

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
