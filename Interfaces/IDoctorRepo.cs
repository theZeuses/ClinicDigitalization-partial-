using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IDoctorRepo
    {
        bool InsertDoctor(Doctor d);
        bool DeleteDoctor(Doctor d);
        bool UpdateDoctor(Doctor d);
        Doctor GetDoctor(string query);
        List<Doctor> GetDoctorList(string query);
    }
}
