using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.Pages.CRUDBike.Filters;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using EnterpriseCarDealership.service_repository_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDBike
{
    //Jakob
    public class ViewBikeModel : PageModel
    {
        /// <summary>
        /// Bind Properties
        /// </summary>
        [BindProperty]
        public int MinPris { get; set; }

        [BindProperty]
        public int MaxPris { get; set; }

        [BindProperty]
        public bool Sidebike { get; set; }

        [BindProperty]
        public bool LeatherSddle { get; set; }

        [BindProperty]
        public bool ExtraStorage { get; set; }

        /// <summary>
        /// Injekt services
        /// </summary>
        private readonly IbikeFilters _bikeFilters;
        private IBikeService _service;
        /// <summary>
        /// Konstruktører
        /// </summary>
        /// <param name="bikeService"></param>
        public ViewBikeModel(IBikeService bikeService)

        {
            _service = bikeService;
        }

        [BindProperty]
        public List<Bike> bikes { get; set; }

        /// <summary>
        /// On get metode for en liste
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            bikes = _service.GetBikeList();

          
            return Page();
        }
        /// <summary>
        /// Forskellige sortiringsmetoder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnPostDelete(int id)
        {
            await _service.Deletebike(id);
            bikes = _service.GetBikeList();

        }
        public void OnPostId()
        {
            bikes = _service.GetBikeList();
            bikes.OrderBy(b => b.NextId);
        }

        public void OnPostSort()
        {
            bikes = _service.GetBikeList();
        }

        public void OnPostBrand()
        {
            bikes = _service.GetBikeList();
            bikes.Sort((x, y) => x.Brand.ToString().CompareTo(y.Brand.ToString()));

        }
        public void OnPostType()
        {
            bikes = _service.GetBikeList();
            bikes.Sort((x, y) => x.Type.ToString().CompareTo(y.Type.ToString()));
        }
        public void OnPostPrisPrDag()
        {
            bikes = _service.GetBikeList();
            bikes.Sort((x, y) => x.PrisPrDag.CompareTo(y.PrisPrDag));
        }
        public void OnPostYear()
        {
            bikes = _service.GetBikeList();
            bikes.Sort((x, y) => x.Year.CompareTo(y.Year));
        }
        public void OnPostKm()
        {
            bikes = _service.GetBikeList();
            bikes.Sort((x, y) => x.Km.CompareTo(y.Km));
        }
        public void OnPostSidebike()
        {
            bikes = _service.GetBikeList();
            var Sidebike = bikes.Select(S => S).Where(S => S.Sidebike == true).ToList();
            bikes = Sidebike;
        }
        public void OnPostLeatherSddle()
        {
            bikes = _service.GetBikeList();
            var LeatherSddle = bikes.Select(L => L).Where(L => L.LeatherSddle == true).ToList();
            bikes = LeatherSddle;
        }
        public void OnPostExtraStorage()
        {
            bikes = _service.GetBikeList();
            var ExtraStorage = bikes.Select(E => E).Where(E => E.ExtraStorage == true).ToList();
            bikes = ExtraStorage;
        }
        /// <summary>
        /// Forskellige filterings metoder
        /// </summary>
        public void OnPostFilterMax()
        {
            bikes = _service.GetBikeList().Where((b) => b.PrisPrDag <= MaxPris).ToList();



            if (Sidebike == true)
            {
                bikes = bikes.Where((b) => (b.PrisPrDag <= MaxPris) && b.Sidebike).ToList();
            }
            if (LeatherSddle == true)
            {
                bikes = bikes.Where((b) => (b.PrisPrDag <= MaxPris) && b.LeatherSddle).ToList();

            }
            if (ExtraStorage == true)
            {
                bikes = bikes.Where((b) => (b.PrisPrDag <= MaxPris) && b.ExtraStorage).ToList();

            }

        }
        public void OnPostFilterMin()
        {
            bikes = _service.GetBikeList().Where(s => s.PrisPrDag >= MinPris).ToList();

            if (Sidebike == true)
            {
                bikes = bikes.Where((b) => (b.PrisPrDag >= MinPris) && b.Sidebike).ToList();

            }
            if (LeatherSddle == true)
            {
                bikes = bikes.Where((b) => (b.PrisPrDag >= MinPris) && b.LeatherSddle).ToList();

            }
            if (ExtraStorage == true)
            {
                bikes = bikes.Where((b) => (b.PrisPrDag >= MinPris) && b.ExtraStorage).ToList();

            }
        }
    }
}
  
