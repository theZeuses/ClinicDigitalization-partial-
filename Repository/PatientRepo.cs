using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;

namespace Repository
{
    public class PatientRepo:IPatientRepo
    {
        DatabaseConnectionClass dbc;

        public PatientRepo()
        {
            dbc =new DatabaseConnectionClass();
        }

        public bool DeletePatient(Patient p)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient(string query)
        {
            Patient p = null; ;
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    p = new Patient();
                    p.Id = data["Id"].ToString();
                    p.Name = data["Name"].ToString();
                    p.BedNo = data["BedNo"].ToString();
                    p.Age = Convert.ToInt32(data["Age"]);
                    p.ContactNo = data["ContactNo"].ToString();
                    p.Credit = Convert.ToDouble(data["Credit"]);
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

        public List<Patient> GetPatientList(string query)
        {
            List<Patient> list = new List<Patient>();
            try
            {
                dbc.ConnectWithDB();
                SqlDataReader data = dbc.GetData(query);
                while (data.Read())
                {
                    Patient p = new Patient();
                    p.Id = data["Id"].ToString();
                    p.Name = data["Name"].ToString();
                    p.BedNo = data["BedNo"].ToString();
                    p.Age = Convert.ToInt32(data["Age"]);
                    p.ContactNo = data["ContactNo"].ToString();
                    p.Credit = Convert.ToDouble(data["Credit"]);
                    list.Add(p);
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

        public bool InsertPatient(Patient p)
        {
            string query = "INSERT INTO Patients(Id,Name,Age,ContactNo) VALUES("+p.Id+",'"+p.Name+"',"+p.Age+",'"+p.ContactNo+"')";

            try
            {
                dbc.ConnectWithDB();
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

        public bool UpdatePatient(Patient p)
        {
            try
            {
                dbc.ConnectWithDB();
                string query = "UPDATE Patients SET Name='"+p.Name+"',Age="+p.Age+",BedNo="+p.BedNo+",Credit="+p.Credit+",ContactNo='"+p.ContactNo+"' WHERE Id="+p.Id;
                dbc.ExecuteSQL(query);

                dbc.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                dbc.CloseConnection();
                return false;
            }
        }
    }
}
