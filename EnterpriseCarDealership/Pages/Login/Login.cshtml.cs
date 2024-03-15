using EnterpriseCarDealership.Models;
using EnterpriseCarDealership.service_repository_s;
using EnterpriseCarDealership.service_repository_s.Service.cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnterpriseCarDealership.Pages.Login
{  //Jakob
    public class LoginModel : PageModel
    {

        private IManagerService _services;
        private IValidateUser _validateService;

        public LoginModel(IManagerService services, IValidateUser valuser)
        {
            _services = services;
            _validateService = valuser;
        }


        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Password { get; set; }
        //public void OnGet()
        //{

        //    User us = SessionHelper.GetUser(HttpContext);

        //}

        public IActionResult OnPost()
        {
            ///vi bruger session helper og validerer user til at se´hvis der findes en manager, medarbejder eller kunde og redirect to speciffikee sider
            User us = SessionHelper.GetUser(HttpContext);
            //User us = new User();

            if (us == null)
            {
                us = new Kunde();
            }

            us = _validateService.Validate(Name, Password);
            if (us != null)
            {

                SessionHelper.SetUser(us, HttpContext);
                if (us.IsAdmin == true || us.IsMedarbejder == true)
                {
                    return RedirectToPage("/Management/Management");
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }

        
            return Page();
    }
    }
    
}

