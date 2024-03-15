using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using EnterpriseCarDealership.service_repository_s.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDBikeBooking
{//Jakob
    public class UpdateBikeBookingModel : PageModel
    {
        /// <summary>
        /// Injekt services
        /// </summary>
        private readonly IBikeBookingService _service;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="carBookingService"></param>
        public UpdateBikeBookingModel(IBikeBookingService carBookingService)

        {
            _service = carBookingService;
        }
        /// <summary>
        /// Bind properties
        /// </summary>

        [BindProperty]
        public BikeBooking bikeBooking { get; set; }
        /// <summary>
        /// on get metode tjekker for cookies og henter en bike booking via id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            bikeBooking = _service.GetBikebookingById(id);
            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true && us.IsMedarbejder != true)
            {

                return RedirectToPage("/Index");
            }

            return Page();

        }
        /// <summary>
        /// on post metoden opdaterer bike booking
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _service.UpdateBikebooking(bikeBooking);
            return RedirectToPage("IndexBikeBooking");
        }

    }
}
