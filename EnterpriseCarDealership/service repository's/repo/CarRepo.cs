using DocumentFormat.OpenXml.ExtendedProperties;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;
using Microsoft.Data.SqlClient;

namespace EnterpriseCarDealership.service_repository_s.repo
{//Khaled
    public class CarRepo : ICarRepo

    {
        /// <summary>
        /// her har vi en liste med cars
        /// </summary>
        List<Car> _cars = new List<Car>(); 
        /// <summary>
        /// her bygger vi vores connection string til serveren
        /// </summary>

        private readonly string ConString = "Server=mssql6.unoeuro.com;Database=jhhweb_dk_db_database;User Id=jhhweb_dk;Password=G2ftFgwApBE5ec3Dxn9r;MultipleActiveResultSets=False;Encrypt=False";

        /// <summary>
        /// For Add vi bygger vores query string , laver en sql connection med den constring, åbner for connection,
        /// execute vores query sætter values ind og lukker connection til sidst
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>

        public async Task Addcar(Car car)
        {
            String queryString = "INSERT INTO Car(Brand,Type,PrisPrDag,Year,Km,AC,Sunroof,Screen,DVD,Camera,Sensor) VALUES (@Brand,@Type,@PrisPrDag,@Year,@Km,@AC,@Sunroof,@Screen,@DVD,@Camera,@Sensor)";

            SqlConnection connection = new SqlConnection(ConString);
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand(queryString, connection);
            //command.Parameters.AddWithValue("@NextId", car.NextId);
            command.Parameters.AddWithValue("@Brand", car.Brand.ToString());
            command.Parameters.AddWithValue("@Type", car.Type);
            command.Parameters.AddWithValue("@PrisPrDag", car.PrisPrDag);
            command.Parameters.AddWithValue("@Year", car.Year);
            command.Parameters.AddWithValue("@Km", car.Km);
            command.Parameters.AddWithValue("@AC", car.AC);
            command.Parameters.AddWithValue("@Sunroof", car.Sunroof);
            command.Parameters.AddWithValue("@Screen", car.Screen);
            command.Parameters.AddWithValue("@DVD", car.DVD);
            command.Parameters.AddWithValue("@Camera", car.Camera);
            command.Parameters.AddWithValue("@Sensor", car.Sensor);
            var rows=command.ExecuteNonQuery();
            if(rows!=1)
            {
                throw new ArgumentException("car er ikke opreteret"); 
            }
         
            connection.Close();
            
        }

        /// <summary>
        /// For denne metode vi bygger vores query , efter det vores connection, åbner for vores connection, sætter vi vores command,
        /// og lukker connection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Deletecar(int id)
        {
            string queryString = "Delete from Car where  NextId = @NextId";
            SqlConnection connection = new SqlConnection(ConString);

            await connection.OpenAsync();
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@NextId", id);
            command.ExecuteNonQuery();

            connection.Close();
        }
        /// <summary>
        /// For denne metode vi bygger vores query , efter det vores connection, åbner for vores connection, sætter vi vores command,
        /// vi efter bruger vi vores reader til at læse den og efter lukker vi connection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCarById(int id)
        {
            string query = $"select * from Car where NextId = @NextId";
            SqlConnection connection = new SqlConnection(ConString);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NextId", id);
            SqlDataReader reader = command.ExecuteReader();
            Car car= new Car();
            while (reader.Read())
            {
                car = ReadCar(reader);
            }
            connection.Close();
            return car; 
        }
        /// <summary>
        /// For denne metode vi bygger vores query , efter det vores connection, åbner for vores connection, sætter vi vores command,
        /// vi efter bruger vi vores reader til at læse den og efter lukker vi connection
        /// </summary>
        /// <returns></returns>
        public List<Car> GetCarList()
        {
            string query = "select * from Car";
            SqlConnection connection = new SqlConnection(ConString);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            _cars.Clear();
            while (reader.Read())
            {
                Car car = ReadCar(reader);
                _cars.Add(car);
            }
            connection.Close();

            return _cars; 

        }
        /// <summary>
        /// den metode læser bare de forskellige attributter for vores klasse
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Car ReadCar(SqlDataReader reader)
        {
            Car car=new Car();
            car.NextId = reader.GetInt32(0);
            car.Brand = reader.GetString(1);
            var type= Enum.Parse<MotorType>(reader.GetString(2));
            car.Type=type;
            car.PrisPrDag = reader.GetDouble(3);
            car.Year = reader.GetInt32(4);
            car.Km = reader.GetInt32(5);
            car.AC = reader.GetBoolean(6);
            car.Sunroof=reader.GetBoolean(7);
            car.Screen = reader.GetBoolean(8);
            car.DVD = reader.GetBoolean(9); 
            car.Camera=reader.GetBoolean(10);
            car.Sensor = reader.GetBoolean(11);
            return car; 


        }
        /// <summary>
        /// For Update vi bygger vores query string , laver en sql connection med den constring, åbner for connection,
        /// execute vores query opdaterer values ind og lukker connection til sidst
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task Updatecar(int id, Car car)
        {
            string queryString = "Update Car set  Brand=@Brand,Type=@Type,PrisPrDag=@PrisPrDag,Year=@Year, Km=@Km, Ac=@AC, Sunroof=@Sunroof, Screen=@Screen, DVD=@DVD, Camera=@Camera, Sensor=@Sensor where NextId=@id";
            SqlConnection connection = new SqlConnection(ConString);
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand(queryString, connection);
            //command.Parameters.AddWithValue("@NextId", car.NextId);
            command.Parameters.AddWithValue("@Brand", car.Brand.ToString());
            command.Parameters.AddWithValue("@Type", car.Type);
            command.Parameters.AddWithValue("@PrisPrDag", car.PrisPrDag);
            command.Parameters.AddWithValue("@Year", car.Year);
            command.Parameters.AddWithValue("@Km", car.Km);
            command.Parameters.AddWithValue("@AC", car.AC);
            command.Parameters.AddWithValue("@Sunroof", car.Sunroof);
            command.Parameters.AddWithValue("@Screen", car.Screen);
            command.Parameters.AddWithValue("@DVD", car.DVD);
            command.Parameters.AddWithValue("@Camera", car.Camera);
            command.Parameters.AddWithValue("@Sensor", car.Sensor);
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery(); 
            if(rows!=1)
            {
                throw new ArgumentException("car er ikke opdateret");

            }
            connection.Close();
        }

    }
}

