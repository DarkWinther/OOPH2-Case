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
        static public void Create()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd;
            connection.Open();

            try
            {

            }
            catch
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        static public void Read()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd;
            connection.Open();

            try
            {

            }
            catch
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
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd;
            connection.Open();

            try
            {

            }
            catch
            {

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        static public void Delete()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd;
            connection.Open();

            try
            {

            }
            catch
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
