using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDBikeBooking;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using EnterpriseCarDealership.service_repository_s.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
//Jakob
namespace EnterpriseCarDealership.Pages.CRUDBike
{
    public class CreateBikeModel : PageModel
    {
        /// <summary>
        /// Her vi Injekt vores services
        /// </summary>
        private readonly IBikeService _addservice;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="bikeService"></param>
        public CreateBikeModel(IBikeService bikeService)

        {
            _addservice = bikeService;
        }
        /// <summary>
        /// Bind Properties for at de bliver fanget i frontend
        /// </summary>
        [BindProperty]
        public CreateBike createBike { get; set; }

        /// <summary>
        /// On post metode med add metode og redirect
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _addservice.Addbike(createBike);
           return RedirectToPage("IndexBike");
        }
        /// <summary>
        /// Onget metode som tjekker for cookies
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true)
            {
                return RedirectToPage("/Index");

            }

            return Page();
        }
    }

    /// <summary>
    /// Her skaber vi modellen med attributter
    /// </summary>
    public class CreateBike
    {

        [Required]
        public int NextId { get; set; } 

        [Required]
        public string Brand { get; set; }

        [Required]
        public MotorType Type { get; set; }

        [Required]
        public double PrisPrDag { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Km { get; set; }

        [Required]
        public Boolean Sidebike { get; set; }

        [Required]
        public Boolean LeatherSddle { get; set; }

        [Required]
        public Boolean ExtraStorage { get; set; }

    }
}
