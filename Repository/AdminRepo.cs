using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Interfaces;
using System.Data.SqlClient;

namespace Repository
{
    public class AdminRepo:IAdminRepo
    {
        DatabaseConnectionClass dbc;

        public AdminRepo()
        {
            dbc = new DatabaseConnectionClass();
        }

        public bool InsertAdmin(Admin r)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "INSERT INTO Admins VALUES(" + r.Id + ",'" + r.Name + "'," + r.Salary + ",'" + r.Shift + "')";
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

        public bool DeleteAdmin(Admin a)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdmin(Admin r)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "UPDATE Admins SET NAME='" + r.Name + "',Salary=" + r.Salary + ",Shift='" + r.Shift + "' WHERE Id=" + r.Id;
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

        public Admin GetAdmin(string query)
        {
            Admin r = null;
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    r = new Admin();
                    r.Id = data["Id"].ToString();
                    r.Name = data["Name"].ToString();
                    r.Salary = data["Salary"].ToString();
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
    }
}
