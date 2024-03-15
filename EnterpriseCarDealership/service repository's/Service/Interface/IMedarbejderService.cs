using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDMedarbejder;

namespace EnterpriseCarDealership.service_repository_s
{//Khaled
    public interface IMedarbejderService
    {
        public List<Medarbejder> GetmedarbejderList();

        public Task Addmedarbejder(CreateMedarbejder createmedarbejder);


        public Task Updatemedarbejder(int id, Medarbejder medarbejder);



        public Medarbejder GetmedarbejderById(int id);

        


        public Task Deletemedarbejder(int id );
      
    }
}
