using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Entity;
using System.Data.SqlClient;

namespace Repository
{
    public class RequestedMedRepo:IRequestedMedRepo
    {
        DatabaseConnectionClass dbc;

        public RequestedMedRepo()
        {
            dbc = new DatabaseConnectionClass();
        }

        public bool InsertRequestedMed(RequestedMed r)
        {
            string query = "INSERT INTO RequestedMeds VALUES('" + r.Name + "'," + r.Quantity + ")";
            try
            {
                dbc.ConnectWithDB();
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

        public bool DeleteRequestedMed(RequestedMed r)
        {
            string query = "DELETE FROM RequestedMeds WHERE Name='"+r.Name.ToUpper()+"'";
            try
            {
                dbc.ConnectWithDB();
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

        public bool UpdateRequestedMed(RequestedMed r)
        {
            throw new NotImplementedException();
        }

        public RequestedMed GetRequestedMed(string query)
        {
            throw new NotImplementedException();
        }

        public List<RequestedMed> GetRequestedMedList(string query)
        {
            List<RequestedMed> list = new List<RequestedMed>();
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    RequestedMed r = new RequestedMed();
                    r.Name = data["Name"].ToString();
                    r.Quantity = Convert.ToDouble(data["Quantity"]);
                    list.Add(r);
                }
                dbc.CloseConnection();
                return list;
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return list;
            }
        }
    }
}
