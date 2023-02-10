//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StudentAttendance
//{
//    class DBAccess
//    {
//        private static SqlConnection objConnection;
//        private static SqlDataAdapter objDataAdapter;
//        public static string ConnectionString =  "Data Source=.;Initial Catalog=studentrecord;Integrated Security=True";
//        private static void OpenConnection()
//        {
//            try
//            {
//                if (objConnection == null)
//                {
//                    objConnection = new SqlConnection(ConnectionString);
//                    objConnection.Open();
//                }
//                else
//                {
//                    if (objConnection.State != ConnectionState.Open)
//                    {
//                        objConnection = new SqlConnection(ConnectionString);
//                        objConnection.Open();
//                    }
//                }
//            }
//            catch (Exception ex) { }
//        }
//        private static void CloseConnection()
//        {
//            try
//            {
//                if (!(objConnection == null))
//                {
//                    if (objConnection.State == System.Data.ConnectionState.Open)
//                    {
//                        objConnection.Close();
//                        objConnection.Dispose();
//                    }
//                }
//            }
//            catch { }
//        }
//        public static bool ExecuteQuery(string query)
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(ConnectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand(query, connection))
//                    {
//                        connection.Open();
//                        cmd.ExecuteNonQuery();
//                        connection.Close();
//                        return true;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }
//    }
//}
