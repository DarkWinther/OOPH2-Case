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
        static SqlConnection connection = new SqlConnection(@"Server=localhost;Database=OOPH2;Trusted_Connection=True;");
        static SqlCommand cmd = connection.CreateCommand();

        public static void Create(string table, string values)
        {

            connection.Open();

            try
            {
                cmd.CommandText = "INSERT INTO " + table + " values(" + values + ")";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public static void Read(string whattoselect, string table)
        {

            connection.Open();

            try
            {
                cmd.CommandText = "SELECT " + whattoselect + " FROM " + table;
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

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public static void Update(string table, string values, string condition)
        {

            connection.Open();

            try
            {
                cmd.CommandText = "UPDATE " + table + " SET " + values + " WHERE " + condition;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public static void Delete(string table, string columnname, int value)
        {

            connection.Open();

            try
            {
                cmd.CommandText = "DELETE FROM " + table + " WHERE " + columnname + " = " + value;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
