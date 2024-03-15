
using EnterpriseCarDealership.service_repository_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using EnterpriseCarDealership.Models;
//Jakob

namespace EnterpriseCarDealership.Pages.CRUDKunder
{
    public class CreateKundeModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private readonly IKundeService _addservice;
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="kundeService"></param>
        public CreateKundeModel(IKundeService kundeService)

        {
            _addservice = kundeService;
        }
        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public CreateKunde createKunde { get; set; }

        /// <summary>
        /// onpost metoden tilføjer en kunde
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            await _addservice.Addkunde(createKunde);
            return RedirectToPage("/Index");
        }
    }

    /// <summary>
    /// skabelsen af modellen
    /// </summary>
    public class CreateKunde
    {

        [Required]
        public int NextId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public Boolean IsMedarbejder { get; set; }

        [Required]
        public Boolean isAdmin { get; set; }

        [Required]
        public string? tlf { get; set; }

        [Required]
        public string? adress { get; set; }

    }
}
