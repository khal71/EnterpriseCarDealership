using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDKunder
{

    //Jakob
    public class UpdateKundeModel : PageModel
    {/// <summary>
    /// injekt services
    /// </summary>

        private readonly IKundeService _kundeService;
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="kundeService"></param>
        public UpdateKundeModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }
        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public Kunde kunde { get; set; }
        [BindProperty]
        public Kunde existingkunde { get; set; }
        /// <summary>
        /// onpost metoden opdaterer en kunde
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(int id)
        {
            await _kundeService.Updatekunde(id, kunde);
            return RedirectToPage("IndexKunde");
        }
        /// <summary>
        /// on post metoden tjekker for cookies og henter en kunde via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            existingkunde = _kundeService.GetKundeById(id);
            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true)
            {
                return RedirectToPage("/Index");

            }

            return Page();
        }

    }
}
