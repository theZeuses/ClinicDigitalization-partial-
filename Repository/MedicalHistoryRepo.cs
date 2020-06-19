using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Interfaces;
using System.Data.SqlClient;

namespace Repository
{
    public class MedicalHistoryRepo:IMedicalHistoryRepo
    {
        DatabaseConnectionClass dbc;
        public MedicalHistoryRepo()
        {
            dbc = new DatabaseConnectionClass();
        }
        public bool InsertMedicalHistory(MedicalHistory m)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "INSERT INTO MedicalHistories VALUES('" + m.PatientId + "','" + m.Date + "','" + m.Data + "')";
                int i = dbc.ExecuteSQL(query);
                if (i != 0)
                {
                    dbc.CloseConnection();
                    return true;
                }
                else
                {
                    dbc.CloseConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return false;
            }
        }

        public bool DeleteMedicalHistory(MedicalHistory m)
        {
            throw new NotImplementedException();
        }

        public List<MedicalHistory> GetMedicalHistoryList(string query)
        {
            List<MedicalHistory> list = new List<MedicalHistory>();
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    MedicalHistory m = new MedicalHistory();
                    m.PatientId = data["PatientId"].ToString();
                    m.Date = data["Date"].ToString();
                    m.Data = data["Data"].ToString();
                    list.Add(m);
                }
                dbc.CloseConnection();
                return list;
            }
            catch(Exception ex)
            {
                dbc.CloseConnection();
                return list;
            }
        }
    }
}
