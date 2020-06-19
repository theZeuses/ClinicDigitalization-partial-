using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Doctor
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

        private string roomNo;

        public string RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        private string expertise;

        public string Expertise
        {
            get { return expertise; }
            set { expertise = value; }
        }
    }
}
