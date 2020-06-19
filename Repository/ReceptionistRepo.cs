using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Entity;
using System.Data.SqlClient;

namespace Repository
{
    public class ReceptionistRepo:IReceptionistRepo
    {
        DatabaseConnectionClass dbc;

        public ReceptionistRepo()
        {
            dbc = new DatabaseConnectionClass();
        }

        public bool InsertReceptionist(Receptionist r)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "INSERT INTO Receptionists VALUES(" + r.Id + ",'" + r.Name + "'," + r.Salary + ",'" + r.Shift + "')";
                int i = dbc.ExecuteSQL(query);
                if (i == 0)
                {
                    dbc.CloseConnection();
                    return false;
                }
                else
                {
                    dbc.CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return false;
            }
        }

        public bool DeleteReceptionist(Receptionist r)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "DELETE FROM Receptionists WHERE Id=" + r.Id;
                int i = dbc.ExecuteSQL(query);
                if (i == 0)
                {
                    dbc.CloseConnection();
                    return false;
                }
                else
                {
                    dbc.CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return false;
            }
        }

        public bool UpdateReceptionist(Receptionist r)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "UPDATE Receptionists SET NAME='" + r.Name + "',Salary=" + r.Salary + ",Shift='" + r.Shift + "' WHERE Id=" + r.Id;
                int i = dbc.ExecuteSQL(query);
                if (i == 0)
                {
                    dbc.CloseConnection();
                    return false;
                }
                else
                {
                    dbc.CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return false;
            }
        }

        public Receptionist GetReceptionist(string query)
        {
            Receptionist r = null;
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    r = new Receptionist();
                    r.Id = data["Id"].ToString();
                    r.Name = data["Name"].ToString();
                    r.Salary = Convert.ToDouble(data["Salary"]);
                    r.Shift = data["Shift"].ToString();
                }
                dbc.CloseConnection();
                return r;
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return r;
            }
        }

        public List<Receptionist> GetReceptionistList(string query)
        {
            List<Receptionist> list = new List<Receptionist>();
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    Receptionist r = new Receptionist();
                    r.Id = data["Id"].ToString();
                    r.Name = data["Name"].ToString();
                    r.Salary = Convert.ToDouble(data["Salary"]);
                    r.Shift = data["Shift"].ToString();
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
