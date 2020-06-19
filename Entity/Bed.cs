using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Bed
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string bedNo;

        public string BedNo
        {
            get { return bedNo; }
            set { bedNo = value; }
        }

        private string roomNo;

        public string RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        private double rent;

        public double Rent
        {
            get { return rent; }
            set { rent = value; }
        }

        private string availability="true";

        public string Availability
        {
            get { return availability; }
            set { availability = value; }
        }
    }
}
