using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Microsoft.Data.SqlClient;

namespace DCYLabourAPI.DAL
{
    public class SqlHelper
    {
        public static string ConnectionString { get; set; } = "server=124.222.114.100;database=LabourEdu;uid=sa;pwd=jhkd5960795.;Encrypt=True;TrustServerCertificate=True;";


        public static DataTable ExecuteTable(string cmdText, params SqlParameter[] sqlParameters)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddRange(sqlParameters);
            return cmd.ExecuteNonQuery();
        }

        

        public static object ExecuteScalar(string sql, params SqlParameter[] sqlParameters)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(sqlParameters);
            return cmd.ExecuteScalar();
        }
    }
}
