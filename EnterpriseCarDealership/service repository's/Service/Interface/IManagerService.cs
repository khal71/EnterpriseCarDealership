using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDManager;

namespace EnterpriseCarDealership.service_repository_s
{//Jakob
    public interface IManagerService
    {
        public List<Manager> GetManagerList();

        public Task AddManager(CreateManager manager);


        public Task UpdateManager(int id, Manager manager);


        public Manager GetManagerById(int id);

        public Task DeleteManager(int id);


    }
}
