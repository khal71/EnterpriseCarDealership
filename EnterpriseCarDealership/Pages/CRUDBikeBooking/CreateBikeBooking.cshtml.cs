using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseCarDealership.Pages.CRUDBikeBooking
{//Jakob
    public class CreateBikeBookingModel : PageModel
    {
        /// <summary>
        /// Injekt services
        /// </summary>
        private readonly IBikeBookingService _addservice;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="bikebookingService"></param>
        public CreateBikeBookingModel(IBikeBookingService bikebookingService)

        {
            _addservice = bikebookingService;
        }
        /// <summary>
        /// BindProperties
        /// </summary>
        [BindProperty]
        public CreateBikeBooking CreateBike {get; set; }

        /// <summary>
        /// On post metoden tilføjer en bike booking og redirect to index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _addservice.AddBikebooking(CreateBike);
            return RedirectToPage("IndexBikeBooking");
        }
    }
    }

/// <summary>
/// Skabelsen af modellen
/// </summary>
    public class CreateBikeBooking
    {


        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int KundeId { get; set; }

        [Required]
        public int BikeId { get; set; }

    }


