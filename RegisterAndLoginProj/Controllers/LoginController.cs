using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginProj.Models;

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
            if(userModel.UserName == "BillGates" && userModel.Password == "bigbucks")
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
