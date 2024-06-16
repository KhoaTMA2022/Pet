using System;
using System.Data;
using System.Data.SqlClient;
using PetManagement.Business.Interface;
using PetManagement.DataAccess;

namespace PetManagement.Business.Services
{
    public class PetService : IPetService
    {

        private readonly DBConnection dbConnection;
        public PetService()
        {
            dbConnection = new DBConnection();
        }

        public DataTable FindAll()
        {
            string query = string.Format("SELECT * FROM Pet");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return dbConnection.ExecuteSelectQuery(query, sqlParameters);
        }
    }
}
