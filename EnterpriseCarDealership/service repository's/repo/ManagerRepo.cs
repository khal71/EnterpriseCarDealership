using DocumentFormat.OpenXml.Spreadsheet;
using EnterpriseCarDealership.DBContextFolder;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;
using Microsoft.Data.SqlClient;

namespace EnterpriseCarDealership.service_repository_s.repo
{//Jakob
    public class ManagerRepo : IManagerRepo
    {
        /// <summary>
        /// her har vi en liste med managers
        /// </summary>
        List<Manager> _managers = new List<Manager>();
        /// <summary>
        /// her bygger vi vores connection string til serveren
        /// </summary>
        private readonly string ConString = "Server=mssql6.unoeuro.com;Database=jhhweb_dk_db_database;User Id=jhhweb_dk;Password=G2ftFgwApBE5ec3Dxn9r;MultipleActiveResultSets=False;Encrypt=False";


        /// <summary>
        /// For Add vi bygger vores query string , laver en sql connection med den constring, åbner for connection,
        /// execute vores query sætter values ind og lukker connection til sidst
        /// </summary>
        public async Task AddManager(Manager manager)
        {
            string queryString = "INSERT INTO Manager ( Name, Password, IsMedarbejder, IsAdmin, Tlf) VALUES ( @Name, @Password,@IsMedarbejder,@IsAdmin, @Tlf);";

            SqlConnection connection = new SqlConnection(ConString);
            await  connection.OpenAsync();
            SqlCommand command = new SqlCommand(queryString, connection);
            //command.Parameters.AddWithValue("@NextId", manager.NextId);
            command.Parameters.AddWithValue("@Name", manager.Name.ToString());
            command.Parameters.AddWithValue("@Password", manager.Password.ToString());
            command.Parameters.AddWithValue("@IsMedarbejder", manager.IsMedarbejder);
            command.Parameters.AddWithValue("@IsAdmin", manager.IsAdmin);
            command.Parameters.AddWithValue("@Tlf", manager.Tlf.ToString());
            var rows = command.ExecuteNonQuery();
            if (rows != 1)
            {
                throw new ArgumentException("Manager er ikke oprettet");
            }

            connection.Close();
        }
        /// <summary>
        /// For denne metode vi bygger vores query , efter det vores connection, åbner for vores connection, sætter vi vores command,
        /// og lukker connection
        /// </summary>
        public async Task DeleteManager(int id)
        {

            string queryString = "Delete from Manager where  NextId = @NextId";
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
        public Manager GetManagerById(int id)
        {
            string query = $"select * from Manager where NextId = @NextId";
            SqlConnection connection = new SqlConnection(ConString);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NextId", id);
            SqlDataReader reader = command.ExecuteReader();
            Manager m = new Manager();
            while (reader.Read())
            {
                m = ReadManager(reader);
            }
            connection.Close();
            return m;
        }
        /// <summary>
        /// For denne metode vi bygger vores query , efter det vores connection, åbner for vores connection, sætter vi vores command,
        /// vi efter bruger vi vores reader til at læse den og efter lukker vi connection
        /// </summary>
        /// <returns></returns>
        public List<Manager> GetManagerList()
        {
            string query = "select * from Manager";
            SqlConnection connection = new SqlConnection(ConString);

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            _managers.Clear();
            while (reader.Read())
            {
                Manager m = ReadManager(reader);
                _managers.Add(m);
            }
            connection.Close();

            return _managers;
        }
        /// <summary>
        /// den metode læser bare de forskellige attributter for vores klasse
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Manager ReadManager(SqlDataReader reader)
        {
            Manager m = new Manager();
            m.NextId = reader.GetInt32(0);
            m.Name = reader.GetString(1);
            m.Password=reader.GetString(2);
            m.IsMedarbejder = reader.GetBoolean(3);
            m.IsAdmin = reader.GetBoolean(4);
            m.Tlf = reader.GetString(5);
            return m;
        }
        /// <summary>
        /// For Update vi bygger vores query string , laver en sql connection med den constring, åbner for connection,
        /// execute vores query opdaterer values ind og lukker connection til sidst
        /// </summary>
        public async Task UpdateManager(int id, Manager manager)
        {
            string queryString = "update Manager set Name=@Name,Password=@Password, IsMedArbejder=@IsMedarbejder,IsAdmin=@IsAdmin,Tlf=@Tlf where NextId =@id";
            SqlConnection connection = new SqlConnection(ConString);
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand(queryString, connection);
            //command.Parameters.AddWithValue("@NextId", manager.NextId);
            command.Parameters.AddWithValue("@Name", manager.Name.ToString());
            command.Parameters.AddWithValue("@Password", manager.Password.ToString());
            command.Parameters.AddWithValue("@IsMedarbejder", manager.IsMedarbejder);
            command.Parameters.AddWithValue("@IsAdmin", manager.IsAdmin);
            command.Parameters.AddWithValue("@Tlf", manager.Tlf.ToString());
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery();
            if (rows != 1)
            {
                throw new ArgumentException("manager er ikke opdateret");
            }
            connection.Close();
        }
    }
}

    

    
       
    

