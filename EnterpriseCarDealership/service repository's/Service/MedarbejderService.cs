using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDMedarbejder;
using EnterpriseCarDealership.service_repository_s.repo;

namespace EnterpriseCarDealership.service_repository_s.sercive
{//Khaled
    public class MedarbejderService: IMedarbejderService 

    {
        /// <summary>
        /// Injektioner og Konstruktører
        /// </summary>
        private IMedarbejderRepo _medarbejderRepo;
        public MedarbejderService(IMedarbejderRepo medarbejderRepo)
        {
            _medarbejderRepo = medarbejderRepo;
        }

        /// <summary>
        ///  Add Metoden som kalder metoden fra repo for at gemme informationer
        /// </summary>
        /// <param name="createMedarbejder"></param>
        /// <returns></returns>
        public async Task Addmedarbejder(CreateMedarbejder createMedarbejder)
        {
            Medarbejder newmedarbejder = new Medarbejder()
            {
                NextId = createMedarbejder.NextId,
                Name = createMedarbejder.name,
                Password = createMedarbejder.password,
                IsMedarbejder = createMedarbejder.isMedarbejder,
                IsAdmin = createMedarbejder.isAdmin,
                Tlf = createMedarbejder.tlf,
                Adress = createMedarbejder.adress,
                ManagerId = createMedarbejder.managerId

            };
           await _medarbejderRepo.Addmedarbejder(newmedarbejder);
            
        }
        /// <summary>
        /// Delete metoden som kalder metoden fra repo til at fjerne noget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Deletemedarbejder(int id)
        {

           await _medarbejderRepo.Deletemedarbejder(id); 
        }
        /// <summary>
        /// FindeviaId metoden som kalder metoden fra repo til at finde på noget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public Medarbejder GetmedarbejderById(int id)
        {
            Medarbejder medarbejder = _medarbejderRepo.GetmedarbejderById(id); 
            if (medarbejder ==null)
            {
                throw new Exception(); 
            }
            return medarbejder; 
        }
        /// <summary>
        /// hent listen metoden som kalder for Listen fra repos
        /// </summary>
        /// <returns></returns>

        public List<Medarbejder> GetmedarbejderList()
        {
            return _medarbejderRepo.GetmedarbejderList();
        }
        /// <summary>
        /// vi bruger denne metode for at kalde opdater metoden fra repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medarbejder"></param>
        /// <returns></returns>
        public async Task Updatemedarbejder(int id, Medarbejder medarbejder)
        {
            
            if (medarbejder != null)
            {
                await _medarbejderRepo.Updatemedarbejder(id,medarbejder); 

            }

        }

        
    }


      
        }



      

  


        
    


