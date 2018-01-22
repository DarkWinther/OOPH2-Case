using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOPH2_Case_Form
{
    class SQLAPI
    {
        public static SqlConnection connection = new SqlConnection(@"Server=localhost;Database=OOPH2;Trusted_Connection=True;");
        static SqlCommand cmd = connection.CreateCommand();

        /// <summary>
        /// Create a SQL Insert statement
        /// </summary>
        /// <param name="sqlstring"></param>
        public static void Insert(string sqlstring)
        {
            connection.Open();
            try
            {
                cmd.CommandText = "INSERT INTO " + sqlstring;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// Create a SQL Read statement
        /// </summary>
        /// <param name="sqlstring"></param>
        public static SqlDataAdapter Read(string sqlstring)
        {
            connection.Open();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT " + sqlstring, connection);
                return adapter;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return null;
        }

        /// <summary>
        /// Create a SQL Update statement
        /// </summary>
        /// <param name="sqlstring"></param>
        public static void Update(string sqlstring)
        {
            connection.Open();
            try
            {
                cmd.CommandText = "UPDATE " + sqlstring;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// Create a SQL Delete statement
        /// </summary>
        /// <param name="sqlstring"></param>
        public static void Delete(string sqlstring)
        {
            connection.Open();
            try
            {
                cmd.CommandText = "DELETE FROM " + sqlstring;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
