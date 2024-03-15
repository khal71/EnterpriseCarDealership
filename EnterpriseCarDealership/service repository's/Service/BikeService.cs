using EnterpriseCarDealership.DBContextFolder;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDBike;
using EnterpriseCarDealership.service_repository_s.repo;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace EnterpriseCarDealership.service_repository_s.sercive
{
    public class BikeService : IBikeService
    {
        //Jakob
        /// <summary>
        /// Injektioner og KOnstruktører
        /// </summary>

        private IBikeRepo _Bikerepo;    

        public BikeService(IBikeRepo bikeRepo)
        {
            _Bikerepo = bikeRepo;   
        }
        /// <summary>
        ///  Add Metoden som kalder metoden fra repo for at gemme informationer
        /// </summary>
        /// <param name="createbike"></param>
        /// <returns></returns>
        public async Task Addbike(CreateBike createbike)
        {
            Bike bike = new Bike()
            {
                NextId=createbike.NextId,
                Brand = createbike.Brand,
                Type = createbike.Type,
                PrisPrDag = createbike.PrisPrDag,
                Year = createbike.Year,
                Km = createbike.Km,
                Sidebike = createbike.Sidebike,
                LeatherSddle = createbike.LeatherSddle,
                ExtraStorage = createbike.ExtraStorage,
            };


           await _Bikerepo.Addbike(bike);
        }
        /// <summary>
        /// Delete metoden som kalder metoden fra repo til at fjerne noget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task Deletebike(int id)
        {
            await _Bikerepo.Deletebike(id);  
        }
        /// <summary>
        /// FindeviaId metoden som kalder metoden fra repo til at finde på noget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>

        public Bike GetBikeById(int id)
        {
            Bike bike = _Bikerepo.GetBikeById(id);
            if (bike == null)
            {
                throw new KeyNotFoundException();   
            }
            return bike; 
        }
        /// <summary>
        /// hent listen metoden som kalder for Listen fra repos
        /// </summary>
        /// <returns></returns>

        public List<Bike> GetBikeList()
        {
            return  _Bikerepo.GetBikeList();
        }
        /// <summary>
        /// vi bruger denne metode for at kalde opdater metoden fra repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bike"></param>
        /// <returns></returns>

        public async Task Updatebike(int id,Bike bike)
        {
 

                await _Bikerepo.Updatebike(id, bike);

            

        }
    }
}
