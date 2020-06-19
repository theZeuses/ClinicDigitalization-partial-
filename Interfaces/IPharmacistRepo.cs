using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Interfaces
{
    public interface IPharmacistRepo
    {
        bool InsertPharmacist(Pharmacist a);
        bool DeletePharmacist(Pharmacist a);
        bool UpdatePharmacist(Pharmacist a);
        Pharmacist GetPharmacist(string query);
        List<Pharmacist> GetPharmacistList(string query);
    }
}
