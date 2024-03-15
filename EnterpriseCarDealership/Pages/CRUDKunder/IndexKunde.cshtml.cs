using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDKunder
{  //Jakob
    public class IndexKundeModel : PageModel
    {
        /// <summary>
        /// /injekt services
        /// </summary>

        private IKundeService _kundeService;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="kundeService"></param>
        public IndexKundeModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }

        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public int NextId { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Adress { get; set; }

        [BindProperty]
        public string Tlf { get; set; }

        [BindProperty]
        public List<Kunde> kunder { get; set; }
        /// <summary>
        /// on get metoden tjekker for cookies og henter en liste
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            kunder = _kundeService.GetKundeList();

            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true)
            {
                return RedirectToPage("/Index");

            }
            return Page();

        }
        /// <summary>
        /// forskellige sortirings metoder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnPostDelete(int id)
        {
            await _kundeService.Deletekunde(id);
            kunder = _kundeService.GetKundeList();
        }

        public void OnPostId()
        {
            kunder = _kundeService.GetKundeList();
            kunder.OrderBy(k => k.NextId);
        }

        public void OnPostName()
        {
            kunder = _kundeService.GetKundeList();
            kunder.Sort((x, y) => x.Name.ToString().CompareTo(y.Name.ToString()));
        }

        public void OnPostAdress()
        {
            kunder = _kundeService.GetKundeList();
            kunder.Sort((x, y) => x.Adress.ToString().CompareTo(y.Adress.ToString()));
        }

        public void OnPostTlf()
        {
            kunder = _kundeService.GetKundeList();
            kunder.Sort((x, y) => x.Tlf.ToString().CompareTo(y.Tlf.ToString()));
        }

        public void OnPostSort()
        {
            kunder = _kundeService.GetKundeList();
            
        }
    }
}
