using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Interfaces
{
    public interface IBillRepo
    {
        bool InsertBill(Bill b);
        bool DeleteBill(Bill b);
        bool DeleteBill(Bill b,string sId);
        List<Bill> GetBillList(string query);
    }
}
