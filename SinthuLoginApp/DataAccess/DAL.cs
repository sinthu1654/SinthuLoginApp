using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SinthuLoginApp.DataAccess
{
    public class DAL
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ToString());

        public static bool IsValidUser (string username, string password)
        {
            bool authenthicated = false;

            string query = string.Format("SELECT * FROM [User] WHERE Username = '{0}' AND Password = '{1}'", username, password);

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            authenthicated = sdr.HasRows;
            conn.Close();
            return (authenthicated);
        }
    }
}