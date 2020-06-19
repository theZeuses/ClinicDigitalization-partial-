using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DatabaseConnectionClass
    {
        private SqlConnection myConnection;
        private SqlCommand myCommand;

        public DatabaseConnectionClass()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\alsan\Documents\Visual Studio 2012\Projects\DoctorPatientPortal\DoctorPatientPortalDB.mdf;Integrated Security=True;Connect Timeout=30";
            myConnection = new SqlConnection(connectionString);
        }

        public void ConnectWithDB()
        {
            myConnection.Open();
        }
        public void CloseConnection()
        {
            myConnection.Close();
        }

        public SqlDataReader GetData(string query)
        {
            myCommand = new SqlCommand(query, myConnection);
            return myCommand.ExecuteReader();
        }
        public int ExecuteSQL(string query)
        {
            myCommand = new SqlCommand(query, myConnection);
            return myCommand.ExecuteNonQuery();
        }
    }
}
