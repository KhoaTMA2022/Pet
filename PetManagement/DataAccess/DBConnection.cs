using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace PetManagement.DataAccess
{
    public class DBConnection
    {
        private readonly string strConnection;

        public DBConnection()
        {
            strConnection = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        }

        public DataTable ExecuteSelectQuery(String query, SqlParameter[] parameters)
        {

            DataTable dt = new DataTable();

            try
            {                
                using (SqlConnection connection = new SqlConnection(strConnection))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    if (parameters.Any())
                        command.Parameters.AddRange(parameters.ToArray());
                    dataAdapter.SelectCommand = command;
                    connection.Open();
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


    }


}
