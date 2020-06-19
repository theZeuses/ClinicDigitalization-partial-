using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Interfaces
{
    public interface IRequestedMedRepo
    {
        bool InsertRequestedMed(RequestedMed r);
        bool DeleteRequestedMed(RequestedMed r);
        bool UpdateRequestedMed(RequestedMed r);
        RequestedMed GetRequestedMed(string query);
        List<RequestedMed> GetRequestedMedList(string query);
    }
}
