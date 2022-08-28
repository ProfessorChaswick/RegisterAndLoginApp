using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginProj.Models;
using RegisterAndLoginProj.Services;

namespace RegisterAndLoginProj.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();
            if(securityService.IsValid(userModel))
            {
                return View("LoginSuccess", userModel);
            }
            else 
            { 
                return View("LoginFailure", userModel); 
            }
            
        }
    }
}
