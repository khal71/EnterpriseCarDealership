using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDMedarbejder
{//Khaled
    public class UpdateMedarbejderModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private readonly IMedarbejderService _medarbejderService;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="medarbejderService"></param>
        public UpdateMedarbejderModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }
        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public Medarbejder medarbejder { get; set; }
        [BindProperty]
        public Medarbejder existingmedarbejder { get; set; } 
        /// <summary>
        /// on post metoden opdaterer en medarbejder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult>OnPost(int id)
        {
            await _medarbejderService.Updatemedarbejder(id, medarbejder);
            return RedirectToPage("IndexMedarbejder");
        }
        /// <summary>
        /// on get metoden tjekker for cookies og henter en medarbejder via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            existingmedarbejder = _medarbejderService.GetmedarbejderById(id);
            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true )
            {
                return RedirectToPage("/Index");

            }

            return Page();
        }
    }
}
