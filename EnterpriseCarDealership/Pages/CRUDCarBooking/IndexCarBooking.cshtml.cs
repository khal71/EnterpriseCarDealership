using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Math;
using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.repo.interfaces;
using EnterpriseCarDealership.service_repository_s.sercive;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDCarBooking
{//Jakob
    public class IndexCarBookingModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private ICarBookingService _service;
        private ICarService _carservice;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="carBookingService"></param>
        /// <param name="carservice"></param>
        public IndexCarBookingModel(ICarBookingService carBookingService, ICarService carservice)

        {
            _service = carBookingService;
            _carservice = carservice;
        }
        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public List<CarBooking> carBookings { get; set; }
        [BindProperty]
        public double TotalPayment { get; set; }
        /// <summary>
        /// on get metoden tjekker for cookies og henter en liste
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            carBookings = _service.GetCarbookingList();
          

            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true && us.IsMedarbejder != true)
            {

                return RedirectToPage("/Index");
            }
           
                return Page();
        }
        /// <summary>
        /// forskellige sorterings metoder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnPostDelete(int id)
        {
            await _service.DeleteCarbooking(id);
            carBookings = _service.GetCarbookingList();

        }

        public void OnPostSort()
        {
            carBookings = _service.GetCarbookingList();
          
        }
        public void OnPostId()
        {
            carBookings = _service.GetCarbookingList();
            carBookings.OrderBy(h => h.Id);


        }
        public void OnPostStartTime()
        {
            carBookings = _service.GetCarbookingList();
            carBookings.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
        }
        public void OnPostEndTime()
        {
            carBookings = _service.GetCarbookingList();
            carBookings.Sort((x, y) => x.EndTime.CompareTo(y.EndTime));
        }
        public void OnPostKundeId()
        {
            carBookings = _service.GetCarbookingList();
            carBookings.Sort((x, y) => x.KundeId.CompareTo(y.KundeId));
        }
        public void OnPostCarId()
        {
            carBookings = _service.GetCarbookingList();
            carBookings.Sort((x, y) => x.CarId.CompareTo(y.CarId));
        }

    }
}
