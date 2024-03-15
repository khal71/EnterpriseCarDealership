using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDKunder;
using Microsoft.Data.SqlClient;

namespace EnterpriseCarDealership.service_repository_s
{
    public interface IKundeService
    {
        //Jakob
        public List<Kunde> GetKundeList();

        public Task Addkunde(CreateKunde createkunde);



        public Task Updatekunde(int id, Kunde kunde);


        public Kunde GetKundeById(int id);

        public Task Deletekunde(int id);
        
    }
}
