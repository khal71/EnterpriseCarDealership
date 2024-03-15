using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDCarBooking
{//Jakob
    public class UpdateCarBookingModel : PageModel
    {/// <summary>
    /// injekt services
    /// </summary>
        private readonly ICarBookingService _service;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="carBookingService"></param>
        public UpdateCarBookingModel(ICarBookingService carBookingService)

        {
            _service = carBookingService;
        }
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public CarBooking carBooking { get; set; }
      /// <summary>
      /// on get metoden tjekker for cookies og henter en car booking via id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            carBooking = _service.GetCarbookingById(id);
            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true && us.IsMedarbejder != true)
            {

                return RedirectToPage("/Index");
            }

            return Page();



        }
        /// <summary>
        /// on post metoden opdaterer car booking 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _service.UpdateCarbooking(carBooking);
            return RedirectToPage("IndexCarBooking");
        }
    }
}
