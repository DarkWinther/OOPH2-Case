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
        /// <returns></returns>
        public static bool Insert(string sqlstring)
        {
            connection.Open();
            try
            {
                cmd.CommandText = "INSERT INTO " + sqlstring;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support! Giv dem denne fejl kode: Error in Insert");
                return false;
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
            catch (SqlException e)
            {
                MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support! Giv dem denne fejl kode: Error in Read");
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
            catch (SqlException e)
            {
                MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support! Giv dem denne fejl kode: Error in Update");
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
            catch (SqlException e)
            {
                MessageBox.Show("Error!\n\nDer er sket en fejl, hvis dette forsætter så kontakt IT-Support! Giv dem denne fejl kode: Error in Delete");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
