using System.Collections.Generic;
using System.Data.SqlClient;
using CarsLib
namespace CarsApi.Handlers
{
    public class DbHandler
    {
        static string connectionString = "Server=beersdb.cxjl13cbth6s.us-east-1.rds.amazonaws.com;Database=BeersDB;User Id=admin;password=abcd1234";
        SqlConnection connection;

        public string Connect() {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return "Ok";

        }

}

