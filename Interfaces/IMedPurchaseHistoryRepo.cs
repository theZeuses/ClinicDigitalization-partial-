using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Interfaces
{
    public interface IMedPurchaseHistoryRepo
    {
        bool InsertMedPurchaseHistory(MedPurchaseHistory m);
        List<MedPurchaseHistory> GetMedPurchaseHistoryList(string query);
    }
}
