using EnterpriseCarDealership.Models;


namespace EnterpriseCarDealership.service_repository_s.repo.interfaces
{
    public interface IBikeRepo
    {
        //Jakob
        public List<Bike> GetBikeList();

        public Task Addbike(Bike bike);


        public Task Updatebike(int id, Bike bike);


        public Bike GetBikeById(int id);

        public Task Deletebike(int id);
    }
}
