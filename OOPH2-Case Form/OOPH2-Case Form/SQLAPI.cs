using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH2_Case_Form
{
    class SQLAPI
    {
        static SqlConnection connection = new SqlConnection(@"Server=localhost;Database=OOPH2;Trusted_Connection=True;");
        static SqlCommand cmd = connection.CreateCommand();

        public static void Create(string databaseStr, string valuesStr)
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

        static public void Read(string whattoselect, string table)
        {

            connection.Open();

            try
            {
                cmd.CommandText = "SELECT " + whattoselect + " FROM " + table;
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

        static public void Update()
        {

            connection.Open();

            try
            {
                cmd.CommandText = "INSERT INTO " + databaseStr + " values(" + valuesStr + ")";
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

        static public void Delete(string table)
        {

            connection.Open();

            try
            {
                cmd.CommandText = "INSERT INTO " + databaseStr + " values(" + valuesStr + ")";
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
