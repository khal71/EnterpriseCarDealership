using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseCarDealership.Pages.CRUDMedarbejder
{//Khaled
    public class CreateMedarbejderModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private readonly IMedarbejderService _service;
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="service"></param>
        public CreateMedarbejderModel(IMedarbejderService service)
        {
            _service = service;
        }
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public CreateMedarbejder createMedarbejder { get; set;}
        /// <summary>
        /// onpost metoden tilføjer en medarbejder
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _service.Addmedarbejder(createMedarbejder);
            return RedirectToPage("IndexMedarbejder");
        }
        /// <summary>
        /// on get metoden tjekker for cookies
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {


            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true)
            {
                return RedirectToPage("/Index");
               
            }

            return Page();
        }

    }
    /// <summary>
    /// skabelse af modellen
    /// </summary>
    public class CreateMedarbejder
    {
        [Required]
        public int NextId { get; set; }

        [Required]
        public  string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool isMedarbejder { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        [Required]
        public string tlf { get; set; }
        [Required]
        public string adress { get; set; }
        [Required]
        public int managerId { get; set; }

    }
}
