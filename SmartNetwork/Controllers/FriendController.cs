using Microsoft.AspNetCore.Mvc;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Friends;
using SmartNetwork.Core.Application.ViewModel.Users;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SmartNetwork.Middlewares;

namespace WebApp.SmartNetwork.Controllers
{
    public class FriendController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IFriendServices _friendServices;
        private readonly ValidateUserSession _validateUserSession;
        public FriendController(IFriendServices friendServices, IUserServices userServices, ValidateUserSession validateUserSession)
        {
            _userServices = userServices;
            _friendServices = friendServices;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "User" });
            }

            var response = await _userServices.GetAllViewModelWithInclude();

            var user = response.FirstOrDefault(x => x.Id == HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string username) {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "User" });
            }

            SaveFriendViewModel model = new();

            var response = await _userServices.GetAllViewModelWithInclude();
            var user = response.FirstOrDefault(x => x.Id == HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id);

            if (!await _userServices.CheckUsername(username))
            {
                ModelState.AddModelError("Username", "The username doesn't exist");


                return View("Index", user);
            }

            var us = await _userServices.GetUserbyUsername(username);
            model.UserFirst = HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id;
            model.UserSecond = us.Id;

            if (us.Id == model.UserFirst) {

                ModelState.AddModelError("Username", "You can't add you.");


                return View("Index", user);

            }

            if (await _friendServices.CheckAreFriend(model) != null) {

                ModelState.AddModelError("Username", "You and this user are friend.");


                return View("Index", user);

            }
            await _friendServices.Add(model);
            return RedirectToRoute(new { action = "Index", controller = "Friend" });
        }
        public async Task<IActionResult> Delete(int Id)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "User" });
            }

            var friend = await _friendServices.GetByIdSaveViewModel(Id);

            return View(friend);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(SaveFriendViewModel vm) {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "User" });
            }

            await _friendServices.Delete(vm.Id);

            return RedirectToRoute(new { action="Index",controller="Friend"});
        }
    }
}
