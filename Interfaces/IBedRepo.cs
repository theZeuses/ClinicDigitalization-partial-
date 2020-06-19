using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Interfaces
{
    public interface IBedRepo
    {
        bool InsertBed(Bed b);
        bool DeleteBed(Bed b);
        bool UpdateBed(Bed b);
        Bed GetBed(string query);
        List<Bed> GetBedList(string query);
    }
}
