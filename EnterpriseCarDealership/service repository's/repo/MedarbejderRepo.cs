using DocumentFormat.OpenXml.Presentation;
using EnterpriseCarDealership.DBContextFolder;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDMedarbejder;

namespace EnterpriseCarDealership.service_repository_s.repo
{//Khaled
    public class MedarbejderRepo:IMedarbejderRepo
    {
        /// <summary>
        /// her injekter vi vores database context
        /// </summary>
        private DealershipContext _medarbejdercontext = new DealershipContext();

        /// <summary>
        /// vi sætter og gemmer en ny medarbejder ved hjælp af database context
        /// </summary>
        /// <param name="medarbejder"></param>
        /// <returns></returns>
        public async Task Addmedarbejder(Medarbejder medarbejder)
        {
            _medarbejdercontext.Add(medarbejder);
            await _medarbejdercontext.SaveChangesAsync();
        }
        /// <summary>
        ///  vi finder og fjerner en bestemt medarbejder og gemmer ændringer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Deletemedarbejder(int id)
        {
            Medarbejder medarbejder = GetmedarbejderById(id);
            _medarbejdercontext.Remove(medarbejder);
            await _medarbejdercontext.SaveChangesAsync();
        }
        /// <summary>
        /// vi bare returner en liste af medarbejder
        /// </summary>
        /// <returns></returns>
        public List<Medarbejder> GetmedarbejderList()
        {
            return new List<Medarbejder>(_medarbejdercontext.Medarbejder);
        }

        /// <summary>
        /// vi finder en bestemt medarbejder ved at tjekke listen og samligne den id med listen's id indtil vi finder den medarbejder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Medarbejder GetmedarbejderById(int id)
        {
            Medarbejder medarbejder = GetmedarbejderList().FirstOrDefault(x => x.NextId == id);
            return medarbejder; 
        }

        /// <summary>
        /// here vi update og gemme de ændringer i en bestemt medarbejder
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medarbejder"></param>
        /// <returns></returns>
        public async Task Updatemedarbejder(int id,  Medarbejder medarbejder)
        {
            Medarbejder existingmedarbejder = GetmedarbejderById(id);

            existingmedarbejder.Name = medarbejder.Name;
            existingmedarbejder.Tlf = medarbejder.Tlf;
            existingmedarbejder.Adress = medarbejder.Adress;
            existingmedarbejder.Password = medarbejder.Password;
            existingmedarbejder.ManagerId = medarbejder.ManagerId;
            existingmedarbejder.IsAdmin = medarbejder.IsAdmin;
            _medarbejdercontext.Medarbejder.Update(existingmedarbejder);

            await _medarbejdercontext.SaveChangesAsync(); 
        }

        
    }
    }

