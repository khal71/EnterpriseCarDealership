using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using EnterpriseCarDealership.DBContextFolder;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDCar;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseCarDealership.service_repository_s.sercive
{//Khaled
    public class CarService :ICarService
    {
        /// <summary>
        /// Injektioner og KOnstruktører
        /// </summary>
        private ICarRepo _carRepo; 
     public CarService(ICarRepo carRepo)
        {
            _carRepo = carRepo; 
        }
        /// <summary>
        /// 
        ///  Add Metoden som kalder metoden fra repo for at gemme informationer
        /// </summary>
        /// <param name="createCar"></param>
        /// <returns></returns>
        
        public async Task Addcar(CreateCar createCar)
        {
            Car car = new Car()
            {
                NextId = createCar.NextId,
                Brand = createCar.Brand,
                Type = createCar.Type,
                PrisPrDag = createCar.PrisPrDag,
                Year = createCar.Year,
                Km = createCar.Km,
                AC = createCar.AC,
                Sunroof = createCar.Sunroof,
                Screen = createCar.Screen,
                DVD = createCar.DVD,
                Camera = createCar.Camera,
                Sensor = createCar.Sensor,


            };
            
            await _carRepo.Addcar(car); 
        }
        /// <summary>
        /// Delete metoden som kalder metoden fra repo til at fjerne noget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Deletecar(int id)
        {
            await _carRepo.Deletecar(id);   
        }
        /// <summary>
        /// FindeviaId metoden som kalder metoden fra repo til at finde på noget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetCarById(int id)
        {
            Car car = _carRepo.GetCarById(id); 
            return car; 
        }
        /// <summary>
        /// hent listen metoden som kalder for Listen fra repos
        /// </summary>
        /// <returns></returns>

        public List<Car> GetCarList()
        {
            return _carRepo.GetCarList();
        }
        /// <summary>
        /// vi bruger denne metode for at kalde opdater metoden fra repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        public async Task Updatecar(int id, Car car)
        {
            await _carRepo.Updatecar(id,car); 
        }
        
    }
}
