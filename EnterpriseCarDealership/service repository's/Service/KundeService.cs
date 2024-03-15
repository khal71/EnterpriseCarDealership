using DocumentFormat.OpenXml.Office2010.Excel;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDKunder;
using EnterpriseCarDealership.service_repository_s.repo;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;

namespace EnterpriseCarDealership.service_repository_s.sercive
{
    //Jakob
    public class KundeService : IKundeService


    {
        /// <summary>
        /// /Injektioner og KOnstruktører
        /// </summary>

        private IKundeRepo _Kunderepo;

        public KundeService()
        {
        }

        public KundeService(IKundeRepo kundeRepo)
        {
        _Kunderepo = kundeRepo;
        }
        /// <summary>
        ///  Add Metoden som kalder metoden fra repo for at gemme informationer
        /// </summary>
        /// <param name="createkunde"></param>
        /// <returns></returns>
        public async Task Addkunde(CreateKunde createkunde)
        {
            await _Kunderepo.Addkunde(createkunde);
        }
        /// <summary>
        /// Delete metoden som kalder metoden fra repo til at fjerne noget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Deletekunde(int id)
        {
            await _Kunderepo.Deletekunde(id);   
        }

        /// <summary>
        /// FindeviaId metoden som kalder metoden fra repo til at finde på noget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Kunde GetKundeById(int id)
        {
            Kunde kunde = _Kunderepo.GetKundeById(id);
           
            return kunde;   
        }
        /// <summary>
        /// hent listen metoden som kalder for Listen fra repos
        /// </summary>
        /// <returns></returns>
        public List<Kunde> GetKundeList()
        {
            return _Kunderepo.GetKundeList();   
        }
        /// <summary>
        /// vi bruger denne metode for at kalde opdater metoden fra repo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kunde"></param>
        /// <returns></returns>
        public async Task Updatekunde(int id, Kunde kunde)
        {
            await _Kunderepo.Updatekunde(id, kunde);    
        }

      
    }
}

