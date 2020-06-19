using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Slot
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string doctorId;

        public string DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        private string patientId;

        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private string slotTime;

        public string SlotTime
        {
            get { return slotTime; }
            set { slotTime = value; }
        }

        private string slotDate;

        public string SlotDate
        {
            get { return slotDate; }
            set { slotDate = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private string availability="true";

        public string Availability
        {
            get { return availability; }
            set { availability = value; }
        }
    }
}
