using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Comments;
using SmartNetwork.Core.Application.ViewModel.Users;
using System.Threading.Tasks;
using WebApp.SmartNetwork.Middlewares;

namespace WebApp.SmartNetwork.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentServices _commentServices;
        private readonly ValidateUserSession _validateUserSession;
        public CommentController(ICommentServices commentServices,ValidateUserSession validateUserSession)
        {
            _commentServices = commentServices;
            _validateUserSession = validateUserSession;
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveCommentViewModel model,string Act,string Cont)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action="Index",controller="User"});
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(Act,Cont);
            }

            model.UserId = HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id;

            await _commentServices.Add(model);

            return RedirectToRoute(new { action=Act,controller=Cont});
        }
    }
}
