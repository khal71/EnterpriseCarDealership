using EnterpriseCarDealership.service_repository_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EnterpriseCarDealership.Models;
using System.ComponentModel.DataAnnotations;
using EnterpriseCarDealership.service_repository_s.Service.Interface;

namespace EnterpriseCarDealership.Pages.CRUDBooking
{//Jakob
    public class CreateCarBookingModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private readonly ICarBookingService _addservice;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="carbookingService"></param>
        public CreateCarBookingModel(ICarBookingService carbookingService)
            
        {
            _addservice = carbookingService;
        }
        /// <summary>
        /// bind properties
        /// </summary>
        [BindProperty]
        public CreateCarBooking CreateCar { get; set; }
        /// <summary>
        /// on post metoden tilføje en ny car booking
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _addservice.AddCarbooking(CreateCar);
            
            return RedirectToPage("/CRUDCarBooking/CarPayment");
        }

    }
     /// <summary>
     /// skabelsen af modellen
     /// </summary>
    
    public class CreateCarBooking
    {
        

        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int KundeId { get; set; }

        [Required]
        public int CarId { get; set; }

       

     

    }
}


