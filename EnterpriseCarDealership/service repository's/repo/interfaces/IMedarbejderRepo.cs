using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDMedarbejder;

namespace EnterpriseCarDealership.service_repository_s.repo
{
    public interface IMedarbejderRepo
    {
        //Khaled

        public List<Medarbejder> GetmedarbejderList();

            public Task Addmedarbejder(Medarbejder medarbejder);


            public Task Updatemedarbejder(int id, Medarbejder medarbejder);

            public Medarbejder GetmedarbejderById(int id);

            public Task Deletemedarbejder(int id);
      
    }
}
