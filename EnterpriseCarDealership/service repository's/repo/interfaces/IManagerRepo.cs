using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDManager;
using Microsoft.Data.SqlClient;

namespace EnterpriseCarDealership.service_repository_s.repo.interfaces
{//Jakob
    public interface IManagerRepo
    {
        public List<Manager> GetManagerList();
        public Manager ReadManager(SqlDataReader reader);

        public Task AddManager(Manager manager);


        public Task UpdateManager(int id, Manager manager);


        public Manager GetManagerById(int id);

        public Task DeleteManager(int id);
       
    }
}
