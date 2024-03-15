using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDBike
{
    //Jakob
    public class UpdateBikeModel : PageModel
    {
        /// <summary>
        /// Injekt services
        /// </summary>
        private readonly IBikeService _service;
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="bikeService"></param>
        public UpdateBikeModel(IBikeService bikeService)

        {
            _service = bikeService;
        }
        /// <summary>
        /// BindProperties
        /// </summary>
        [BindProperty]
        public Bike bike { get; set; }

        //[BindProperty]
        //public Bike existingBike { get; set; }
        /// <summary>
        /// on post metode som kalder på opdateringsmetode og redirect
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPost(int id)
        {
            await _service.Updatebike(id, bike);
            return RedirectToPage("IndexBike");
        }
        /// <summary>
        /// On get metode tjekker for cookies og get by id metoden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            bike = _service.GetBikeById(id);
            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true)
            {
                return RedirectToPage("/Index");

            }

            return Page();

        }
       
    }
}
