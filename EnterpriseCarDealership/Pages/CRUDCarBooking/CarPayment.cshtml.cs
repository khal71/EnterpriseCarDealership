using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//Jakob
namespace EnterpriseCarDealership.Pages.CRUDCarBooking
{
    public class CarPaymentModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
       private ICarBookingService _service { get; set; }
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="service"></param>
        public CarPaymentModel(ICarBookingService service)
        {
            _service = service;
        }
        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public double TotalPrice { get; set; }
        [BindProperty]
        public CarBooking? carbooking { get; set; }
        /// <summary>
        /// on get metode kalkulerer prisen
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(int id)
        {
          carbooking = _service.GetCarbookingById(id);
            
            
                TotalPrice = _service.CalculatePayment(carbooking.Id, carbooking.CarId);
            
        }
        /// <summary>
        /// Back metoden redirect to index
        /// </summary>
        public IActionResult OnPostBack()
        {
           return RedirectToPage("/CRUDCarBooking/IndexCarBooking");
        }
    }
}
