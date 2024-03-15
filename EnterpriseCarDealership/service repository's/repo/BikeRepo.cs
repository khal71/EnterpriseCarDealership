using EnterpriseCarDealership.DBContextFolder;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseCarDealership.service_repository_s.repo
{
    public class BikeRepo : IBikeRepo
    //Jakob
    {
        /// <summary>
        /// her injekter vi vores database context
        /// </summary>
        private DealershipContext dBContext = new DealershipContext();
        
        /// <summary>
        /// vi sætter og gemmer en ny bike ved hjælp af database context
        /// </summary>
        /// <param name="bike"></param>
        /// <returns></returns>
        public async Task Addbike(Bike bike)
        {
            dBContext.Bike.Add(bike);
            await dBContext.SaveChangesAsync();
        }

        /// <summary>
        /// vi finder og fjerner en bestemt bike og gemmer ændringer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Deletebike(int id)
        {
            Bike bike = GetBikeById(id);
            dBContext.Bike.Remove(bike);
            await dBContext.SaveChangesAsync();
    
        }

        /// <summary>
        /// vi finder en bestemt Bike ved at tjekke listen og samligne den id med listen's id indtil vi finder den bike
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bike GetBikeById(int id)
        {
            Bike bike = GetBikeList().FirstOrDefault(x => x.NextId == id);
            return bike;
        }
        /// <summary>
        /// vi bare returner en liste af bikes
        /// </summary>
        /// <returns></returns>
        public List<Bike> GetBikeList()
        {
            var bikes = dBContext.Bike.ToList();
            return bikes;
        }
        /// <summary>
        /// here vi update og gemme de ændringer i en bestemt bike
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bike"></param>
        /// <returns></returns>
        public async Task Updatebike(int id, Bike bike)
        {
            Bike newbike = GetBikeById(id);
            //     newbike.NextId = bike.NextId;    
            newbike.Brand = bike.Brand;
            newbike.Type = bike.Type;
            newbike.PrisPrDag = bike.PrisPrDag;
            newbike.Year = bike.Year;
            newbike.Km = bike.Km;
            newbike.Sidebike = bike.Sidebike;
            newbike.LeatherSddle = bike.LeatherSddle;
            newbike.ExtraStorage = bike.ExtraStorage;



            dBContext.Bike.Update(newbike);
            await dBContext.SaveChangesAsync();
        }
    }
}
