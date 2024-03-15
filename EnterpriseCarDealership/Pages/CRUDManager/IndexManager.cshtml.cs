using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.sercive;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.CRUDManager
{//Jakob
    public class IndexManagerModel : PageModel
    {
        /// <summary>
        /// injekt services
        /// </summary>
        private IManagerService _service;
        /// <summary>
        /// konstriktører
        /// </summary>
        /// <param name="managerService"></param>
        public IndexManagerModel(IManagerService managerService)

        {
            _service = managerService;
        }
        /// <summary>
        /// Bind properties
        /// </summary>
        [BindProperty]
        public List<Manager> managers { get; set; }
        /// <summary>
        /// on get metoden tjekker for cookies og henter en liste af managers
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
           managers = _service.GetManagerList();

            User us = SessionHelper.GetUser(HttpContext);
            if (us.IsAdmin != true || us == null)
            {

                return RedirectToPage("/Index");
            }

            return Page();

        }
        /// <summary>
        /// delete metoden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnPostDelete(int id)
        {
           await _service.DeleteManager(id);
            managers = _service.GetManagerList();

        }
        /// <summary>
        /// forskellige sorterings metoder
        /// </summary>
        public void OnPostSort()
        {
            managers = _service.GetManagerList();
            
        }
        public void OnPostId()
        {
            managers = _service.GetManagerList();
            managers.OrderBy(h => h.NextId);


        }
        public void OnPostName()
        {
            managers = _service.GetManagerList();
            managers.Sort((x, y) => x.Name.CompareTo(y.Name));
        }
        public void OnPosttlf()
        {
            managers = _service.GetManagerList();
            managers.Sort((x, y) => x.Tlf.CompareTo(y.Tlf));
        }
    }
}
