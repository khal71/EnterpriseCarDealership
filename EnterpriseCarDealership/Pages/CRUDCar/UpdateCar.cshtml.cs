using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DocumentFormat.OpenXml.Office2010.Excel;
using EnterpriseCarDealership.service_repository_s.Service.cookies;

namespace EnterpriseCarDealership.Pages.CRUDCar
{//Khaled
    public class UpdateCarModel : PageModel

    {
        /// <summary>
        /// Injekt services
        /// </summary>
        private readonly ICarService _carService;
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="carService"></param>
        public UpdateCarModel(ICarService carService)
        {
            _carService = carService;   
        }
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public Car car { get; set; }

        [BindProperty]
        public Car  existingCar { get; set; }
        /// <summary>
        /// onpost metoden opdaterer car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult>OnPost(int id)
        {
            await _carService.Updatecar( id, car);
            return RedirectToPage("IndexCar");
        }
        /// <summary>
        /// onget metoden tjekker for cookies og henter en car via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            
            existingCar=_carService.GetCarById(id);
        
            
                User us = SessionHelper.GetUser(HttpContext);
                if (us.IsAdmin != true && us.IsMedarbejder != true)
                {
                    return RedirectToPage("/Index");

                }

                return Page();
            
        }
    }
}
