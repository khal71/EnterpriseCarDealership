using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDBikeBooking
{
    //Jakob
    public class BikePaymentModel : PageModel
    {
        /// <summary>
        /// Injekt service
        /// </summary>
        private IBikeBookingService _service { get; set; }
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="service"></param>
        public BikePaymentModel(IBikeBookingService service)
        {
            _service = service;
        }
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public double TotalPrice { get; set; }
        [BindProperty]
        public BikeBooking bikebooking { get; set; }

        /// <summary>
        /// On get metoden henter booking og kalkulerer prisen
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(int id)
        {
            bikebooking = _service.GetBikebookingById(id);


            TotalPrice = _service.CalculatePayment(bikebooking.Id, bikebooking.BikeId);

        }
        /// <summary>
        /// Back metoden gå til index
        /// </summary>
        public IActionResult OnPostBack()
        {
           return  RedirectToPage("/CRUDBikeBooking/IndexBikeBooking");
        }
    }
}
