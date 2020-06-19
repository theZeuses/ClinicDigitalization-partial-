using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Interfaces
{
    public interface IReceptionistRepo
    {
        bool InsertReceptionist(Receptionist r);
        bool DeleteReceptionist(Receptionist r);
        bool UpdateReceptionist(Receptionist r);
        Receptionist GetReceptionist(string query);
        List<Receptionist> GetReceptionistList(string query);
    }
}
