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
        static public void Create(string type)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            try
            {
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

        static public void Read()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            try
            {

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
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            try
            {

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

        static public void Delete()
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            try
            {

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
