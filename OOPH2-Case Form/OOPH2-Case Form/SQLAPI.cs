using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPH2_Case_Form
{
    class SQLAPI
    {
        public static SqlConnection connection = new SqlConnection(@"Server=localhost;Database=OOPH2;Trusted_Connection=True;");
        static SqlCommand cmd = connection.CreateCommand();

        /// <summary>
        /// Insert SQL statement
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
        /// Read SQL statement
        /// </summary>
        /// <param name="sqlstring"></param>
        public static void Read(string sqlstring)
        {

            connection.Open();

            try
            {
                cmd.CommandText = "SELECT " + sqlstring;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            MessageBox.Show(reader.GetValue(i).ToString());
                        }
                    }
                }
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
        /// Update SQL statement
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
        /// Delete SQL statement
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
