using DocumentFormat.OpenXml.Office2010.Excel;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDManager
{//Jakob
    public class UpdateManagerModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private readonly IManagerService _service;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="managerService"></param>
        public UpdateManagerModel(IManagerService managerService)

        {
            _service = managerService;
        }
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public Manager manager { get; set; }
        [BindProperty]
         public Manager existingManager { get; set; }
        /// <summary>
        /// onpost metoden opdaterer en manager
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(int Id)
        {
            await _service.UpdateManager(Id, manager);
            return RedirectToPage("IndexManager"); 
        }
        /// <summary>
        /// on get metoden tjekker for cookies og henter en manager via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
           existingManager = _service.GetManagerById(id);

            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true )
            {

                return RedirectToPage("/Index");
            }

            return Page();

        }

    }
}
