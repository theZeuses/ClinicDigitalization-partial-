using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Entity;
using System.Data.SqlClient;

namespace Repository
{
    public class DoctorRepo:IDoctorRepo
    {
        DatabaseConnectionClass dbc;
        List<Doctor> doctorList;

        public DoctorRepo()
        {
            dbc = new DatabaseConnectionClass();
        }

        public bool DeleteDoctor(Doctor d)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "DELETE FROM Doctors WHERE Id=" + d.Id;
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

        public Doctor GetDoctor(string query)
        {
            Doctor p = null; 
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    p = new Doctor();
                    p.Id = data["Id"].ToString();
                    p.Name = data["Name"].ToString();
                    p.RoomNo = data["RoomNo"].ToString();
                    p.Expertise = data["Expertise"].ToString();
                }
                dbc.CloseConnection();
                return p;
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return p;
            }
        }

        public List<Doctor> GetDoctorList(string query)
        {
            List<Doctor> list=new List<Doctor>();
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    Doctor d = new Doctor();
                    d.Id = data["Id"].ToString();
                    d.Name = data["Name"].ToString();
                    d.RoomNo = data["RoomNo"].ToString();
                    d.Expertise = data["Expertise"].ToString();
                    list.Add(d);
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

        public bool InsertDoctor(Doctor d)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "INSERT INTO Doctors VALUES("+d.Id+",'" + d.Name + "'," + d.RoomNo + ",'" + d.Expertise + "')";
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

        public bool UpdateDoctor(Doctor d)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "UPDATE Doctors SET NAME='"+d.Name+"',RoomNo="+d.RoomNo+",Expertise='"+d.Expertise+"' WHERE Id="+d.Id;
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
    }
}
