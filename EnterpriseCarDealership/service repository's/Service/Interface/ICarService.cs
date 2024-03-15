using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDCar;

namespace EnterpriseCarDealership.service_repository_s
{
    public interface ICarService
    //Khaled
    {
        public List<Car> GetCarList();

        public Task Addcar(CreateCar car);


        public Task Updatecar(int id, Car car);


        public Car GetCarById(int id);

        public Task Deletecar(int id);

    }
}
