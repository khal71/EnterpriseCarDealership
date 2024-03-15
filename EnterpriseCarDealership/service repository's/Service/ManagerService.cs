using DocumentFormat.OpenXml.Spreadsheet;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDManager;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;

namespace EnterpriseCarDealership.service_repository_s.sercive
{//Jakob
    public class ManagerService : IManagerService
    ///Injektioner og KOnstruktører
    {
        private IManagerRepo _managerRepo;

        public ManagerService(IManagerRepo managerRepo)
        {
            _managerRepo = managerRepo;
        }
        /// <summary>
        ///  Add Metoden som kalder metoden fra repo for at gemme informationer
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>

        public async Task AddManager(CreateManager manager)
        {
            Manager newManager = new Manager()
            {
              NextId=manager.NextId,
                Name=manager.Name,
                Password=manager.Password,
                IsMedarbejder=manager.IsMedarbejder,
                IsAdmin=manager.IsAdmin,
                Tlf=manager.Tlf


            };
            await _managerRepo.AddManager(newManager);
        }
        /// <summary>
        /// Delete metoden som kalder metoden fra repo til at fjerne noget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteManager(int id)
        {
            await _managerRepo.DeleteManager(id);
        }
        /// <summary>
        /// FindeviaId metoden som kalder metoden fra repo til at finde på noget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Manager GetManagerById(int id)
        {
            Manager manager = _managerRepo.GetManagerById(id);
            
            return manager;
        }
        /// <summary>
        /// hent listen metoden som kalder for Listen fra repos
        /// </summary>
        /// <returns></returns>
        public List<Manager> GetManagerList()
        {
            return _managerRepo.GetManagerList();
        }
        /// <summary>
        /// vi bruger denne metode for at kalde opdater metoden fra repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task UpdateManager(int id, Manager manager)
        {
            await _managerRepo.UpdateManager(id, manager);
            
        }
    }
}
