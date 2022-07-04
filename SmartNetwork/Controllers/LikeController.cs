using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Likes;
using SmartNetwork.Core.Application.ViewModel.Users;
using System.Threading.Tasks;
using WebApp.SmartNetwork.Middlewares;

namespace WebApp.SmartNetwork.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeServices _likeServices;
        private readonly ValidateUserSession _validateUserSession;
        public LikeController(ILikeServices likeServices,ValidateUserSession validateUserSession)
        {
            _likeServices = likeServices;
            _validateUserSession = validateUserSession;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveLikeViewModel model,string Act,string Cont)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action="Index",controller="User"});
            }
            model.UserId = HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id;
            var response = await _likeServices.GetLikeExists(model);

            if (response != null)
            {
                await _likeServices.Delete(response.Id);
                return RedirectToAction(Act, Cont);
            }
            else {
                await _likeServices.Add(model);
            }

            return RedirectToRoute(new { action=Act,controller=Cont});
        }
    }
}
