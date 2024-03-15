using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using EnterpriseCarDealership.service_repository_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDCar
{//Khaled
    public class ViewCarModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private ICarService _carService;
        /// <summary>
        /// konstruktører
        /// </summary>
        /// <param name="carService"></param>
        public ViewCarModel(ICarService carService)
        {
            _carService = carService;
        }
        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public List<Car> cars { get; set; }
        [BindProperty]
        public double MaxPris { get; set; }
        [BindProperty]
        public double MinPris { get; set; }
        [BindProperty]
        public Boolean AC { get; set; }
        [BindProperty]
        public Boolean Sunroof { get; set; }
        [BindProperty]
        public Boolean Screen { get; set; }
        [BindProperty]
        public Boolean DVD { get; set; }
        [BindProperty]
        public Boolean Camera { get; set; }
        [BindProperty]
        public Boolean Sensor { get; set; }



        /// <summary>
        /// on get metoden henter en liste
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            cars = _carService.GetCarList();

        

            return Page();

        }
        /// <summary>
        /// forskellige sorterings metoder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnPostDelete(int id)
        {
            await _carService.Deletecar(id);
            cars = _carService.GetCarList();
        }


        public void OnPostId()
        {
            cars = _carService.GetCarList();
            cars.OrderBy(I => I.NextId);
        }

        public void OnPostBrand()
        {
            cars = _carService.GetCarList();
            cars.Sort((x, y) => x.Brand.ToString().CompareTo(y.Brand.ToString()));

        }
        public void OnPostType()
        {
            cars = _carService.GetCarList();
            cars.Sort((x, y) => x.Type.ToString().CompareTo(y.Type.ToString()));
        }
        public void OnPostPrisPrDag()
        {
            cars = _carService.GetCarList();
            cars.Sort((x, y) => x.PrisPrDag.CompareTo(y.PrisPrDag));
        }
        public void OnPostYear()
        {
            cars = _carService.GetCarList();
            cars.Sort((x, y) => x.Year.CompareTo(y.Year));
        }
        public void OnPostKm()
        {
            cars = _carService.GetCarList();
            cars.Sort((x, y) => x.Km.CompareTo(y.Km));
        }
        public void OnPostAC()
        {
            cars = _carService.GetCarList();
            var Ac = cars.Select(A => A).Where(A => A.AC == true).ToList();
            cars = Ac;
        }
        public void OnPostSunroof()
        {
            cars = _carService.GetCarList();
            var Sunroof = cars.Select(R => R).Where(R => R.Sunroof == true).ToList();
            cars = Sunroof;
        }
        public void OnPostScreen()
        {
            cars = _carService.GetCarList();
            var Screen = cars.Select(S => S).Where(S => S.Screen == true).ToList();
            cars = Screen;
        }
        public void OnPostDVD()
        {
            cars = _carService.GetCarList();
            var DVD = cars.Select(D => D).Where(D => D.DVD == true).ToList();
            cars = DVD;
        }
        public void OnPostCamera()
        {
            cars = _carService.GetCarList();
            var Camera = cars.Select(C => C).Where(C => C.Camera == true).ToList();
            cars = Camera;
        }
        public void OnPostSensor()
        {
            cars = _carService.GetCarList();
            var Sensor = cars.Select(s => s).Where(s => s.Sensor == true).ToList();
            cars = Sensor;
        }
        public void OnPostAll()
        {
            cars = _carService.GetCarList();
        }
        /// <summary>
        /// forskellige filterings metoder
        /// </summary>
        public void OnPostFilterMax() 
        {


            cars = _carService.GetCarList().Where((C) => C.PrisPrDag <= MaxPris).ToList();
        

            if (AC == true)
            {
                cars = cars.Where((C) => (C.PrisPrDag <= MaxPris) && C.AC).ToList();
            }
            if (Sunroof == true)
            {
                cars = cars.Where((C) => (C.PrisPrDag <= MaxPris) && C.Sunroof).ToList();
            }
            if (Screen == true)
            {
                cars = cars.Where((C) => (C.PrisPrDag <= MaxPris) && C.Screen).ToList();
            }
            if (DVD == true)
            {
                cars = cars.Where((C) => (C.PrisPrDag <= MaxPris) && C.DVD).ToList();
            }
            if (Camera == true)
            {
                cars = cars.Where((C) => (C.PrisPrDag <= MaxPris) && C.Camera).ToList();
            }
            if (Sensor == true)
            {
                cars = cars.Where((C) => (C.PrisPrDag <= MaxPris) && C.Sensor).ToList();
            }
        }
        public void OnPostFilterMin()
        {
            cars = _carService.GetCarList().Where((M) => M.PrisPrDag >= MinPris).ToList();

            if (AC == true)
            {
                cars = cars.Where((M) => (M.PrisPrDag >= MinPris) && M.AC).ToList();
            }
            if (Sunroof == true)
            {
                cars = cars.Where((M) => (M.PrisPrDag >= MinPris) && M.Sunroof).ToList();
            }
            if (Screen == true)
            {
                cars = cars.Where((M) => (M.PrisPrDag >= MinPris) && M.Screen).ToList();
            }
            if (DVD == true)
            {
                cars = cars.Where((M) => (M.PrisPrDag >= MinPris) && M.DVD).ToList();
            }
            if (Camera == true)
            {
                cars = cars.Where((M) => (M.PrisPrDag >= MinPris) && M.Camera).ToList();
            }
            if (Sensor == true)
            {
                cars = cars.Where((M) => (M.PrisPrDag >= MinPris) && M.Sensor).ToList();
            }

        }
    }
}
  
