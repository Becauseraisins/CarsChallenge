using System.Collections.Generic;
using System.Data.SqlClient;
using CarsLib;
namespace CarsApi.Handlers
{
    public class DbHandler
    {
        static string connectionString = "Server=database-1.ctcz9gxl3kws.us-east-1.rds.amazonaws.com;Database=CarsDB;User Id=admin;password=asdf1234";
        SqlConnection connection;

        public string Connect()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return "Ok";

        }
        public string ReduceSpeed(string rego, int speed)
        {
            string query = "Select * From CAR where registration = @registration";
            Car foundcar = null;
            int rowsaffected;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);

                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@registration";
                nameParam.Value = rego;

                command.Parameters.Add(nameParam);

                connection.Open();

                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    string carRego = result.GetString(0);
                    string carMake = result.GetString(1);
                    string carModel = result.GetString(2);
                    int carYear = result.GetInt32(3);
                    int carSpeed = result.GetInt32(4);

                    foundcar = new Car(carRego, carMake, carModel, carYear, carSpeed);

                }
                command.Parameters.Clear();
                connection.Close();


                foundcar.DecreaseSpeed(speed);
                query = "UPDATE car SET speed = @speed WHERE registration =@registration";

                command = new SqlCommand(query, connection);

                SqlParameter speedParam = new SqlParameter();
                speedParam.ParameterName = "@speed";
                speedParam.Value = foundcar.Speed;

                command.Parameters.Add(speedParam);
                command.Parameters.Add(nameParam);
                connection.Open();
                rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    return $"{foundcar.Rego} is now moving at {foundcar.Speed} km/h ";
                }
                else return "failed";

            }

        }
        public string IncreaseSpeed(string rego, int speed)
        {
            string query = "Select * From CAR where registration = @registration";
            Car foundcar = null;
            int rowsaffected;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);

                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@registration";
                nameParam.Value = rego;

                command.Parameters.Add(nameParam);

                connection.Open();

                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    string carRego = result.GetString(0);
                    string carMake = result.GetString(1);
                    string carModel = result.GetString(2);
                    int carYear = result.GetInt32(3);
                    int carSpeed = result.GetInt32(4);

                    foundcar = new Car(carRego, carMake, carModel, carYear, carSpeed);

                }
                command.Parameters.Clear();
                connection.Close();


                foundcar.IncreaseSpeed(speed);
                query = "UPDATE car SET speed = @speed WHERE registration =@registration";

                command = new SqlCommand(query, connection);

                SqlParameter speedParam = new SqlParameter();
                speedParam.ParameterName = "@speed";
                speedParam.Value = foundcar.Speed;

                command.Parameters.Add(speedParam);
                command.Parameters.Add(nameParam);
                connection.Open();
                rowsaffected = command.ExecuteNonQuery();
                if (rowsaffected > 0)
                {
                    return $"{foundcar.Rego} is now moving at {foundcar.Speed} km/h ";
                }
                else return "failed";

            }

        }
        public List<Car> GetAllCars()
        {
            string query = "Select * From CAR";
            List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    string carRego = result.GetString(0);
                    string carMake = result.GetString(1);
                    string carModel = result.GetString(2);
                    int carYear = result.GetInt32(3);
                    int carSpeed = result.GetInt32(4);
                    cars.Add(new Car(carRego, carMake, carModel, carYear, carSpeed));
                }
                return cars;
            }
        }
        public Car GetCar(string rego)
        {
            string query = "Select * From CAR where registration = @registration";
            Car foundcar = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);

                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@registration";
                nameParam.Value = rego;

                command.Parameters.Add(nameParam);

                connection.Open();

                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    string carRego = result.GetString(0);
                    string carMake = result.GetString(1);
                    string carModel = result.GetString(2);
                    int carYear = result.GetInt32(3);
                    int carSpeed = result.GetInt32(4);

                    foundcar = new Car(carRego, carMake, carModel, carYear, carSpeed);

                }
                return foundcar;
            }
        }
        public string GetAge(string rego)
        {
            string query = "Select * From CAR where registration = @registration";
            Car foundcar = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);

                SqlParameter nameParam = new SqlParameter();
                nameParam.ParameterName = "@registration";
                nameParam.Value = rego;

                command.Parameters.Add(nameParam);

                connection.Open();

                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    string carRego = result.GetString(0);
                    string carMake = result.GetString(1);
                    string carModel = result.GetString(2);
                    int carYear = result.GetInt32(3);
                    int carSpeed = result.GetInt32(4);

                    foundcar = new Car(carRego, carMake, carModel, carYear, carSpeed);

                }
                return $"{foundcar.Rego} is {foundcar.GetAge()} years old";

            }
        }

    }
}

