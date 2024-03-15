using EnterpriseCarDealership.Models;
using Microsoft.Data.SqlClient;

namespace EnterpriseCarDealership.service_repository_s.repo.interfaces
{
    //Khaled
    public interface ICarRepo
    {
        public Car ReadCar(SqlDataReader reader); 
        public  List<Car> GetCarList();

        public Task Addcar(Car car);


        public Task Updatecar(int id, Car car);


        public Car GetCarById(int id);

        public Task Deletecar(int id);

    }
}
