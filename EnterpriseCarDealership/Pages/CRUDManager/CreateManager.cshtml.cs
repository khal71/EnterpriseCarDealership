using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseCarDealership.Pages.CRUDManager
{
    //Jakob
    public class CreateManagerModel : PageModel
    {/// <summary>
    /// injekt services
    /// </summary>
        private readonly IManagerService _addservice;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="managerService"></param>
        public CreateManagerModel(IManagerService managerService)

        {
            _addservice = managerService;
        }
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public CreateManager CreateManager { get; set; }

        /// <summary>
        /// on post metoden tilføjer en manager
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _addservice.AddManager(CreateManager);
            return RedirectToPage("IndexManager");
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
    public class CreateManager
    {

        [Required]
        public int NextId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsMedarbejder { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public string Tlf { get; set; }
    }
}

