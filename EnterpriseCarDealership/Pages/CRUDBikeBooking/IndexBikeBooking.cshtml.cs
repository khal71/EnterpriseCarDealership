using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using EnterpriseCarDealership.service_repository_s.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDBikeBooking
{//Jakob
    public class IndexBikeBookingModel : PageModel
    {
        /// <summary>
        /// Injekt services
        /// </summary>
        private IBikeBookingService _service;
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="bikeBookingService"></param>

        public IndexBikeBookingModel(IBikeBookingService bikeBookingService)

        {
            _service = bikeBookingService;
        }
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public List<BikeBooking> bikeBookings { get; set; }
        /// <summary>
        /// On get metoden tjekker for cookies og henter en liste
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            bikeBookings = _service.GetBikebookingList();
            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true && us.IsMedarbejder != true)
            {

                return RedirectToPage("/Index");
            }

            return Page();
        }
        /// <summary>
        /// forskellige Sortering metoder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnPostDelete(int id)
        {
            await _service.DeleteBikebooking(id);
            bikeBookings = _service.GetBikebookingList();

        }
        public void OnPostSort()
        {
            bikeBookings = _service.GetBikebookingList();
           
        }
        public void OnPostId()
        {
            bikeBookings = _service.GetBikebookingList();
            bikeBookings.Sort((x, y) => x.Id.CompareTo(y.Id));


        }
        public void OnPostStartTime()
        {
            bikeBookings = _service.GetBikebookingList();
            bikeBookings.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
        }
        public void OnPostEndTime()
        {
            bikeBookings = _service.GetBikebookingList();
            bikeBookings.Sort((x, y) => x.EndTime.CompareTo(y.EndTime));
        }
        public void OnPostKundeId()
        {
            bikeBookings = _service.GetBikebookingList();
            bikeBookings.Sort((x, y) => x.KundeId.ToString().CompareTo(y.KundeId.ToString()));
        }
        public void OnPostBikeId()
        {
            bikeBookings = _service.GetBikebookingList();
            bikeBookings.Sort((x, y) => x.BikeId.ToString().CompareTo(y.BikeId.ToString()));
        }
    }
}
