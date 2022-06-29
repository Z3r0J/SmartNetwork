using Microsoft.AspNetCore.Mvc;
using SmartNetwork.Core.Application.ViewModel.Users;

namespace WebApp.SmartNetwork.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() {

            return View(new SaveUserViewModel());
        }
    }
}
