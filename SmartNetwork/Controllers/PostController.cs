using Microsoft.AspNetCore.Mvc;
using SmartNetwork.Core.Application.ViewModel.Posts;

namespace WebApp.SmartNetwork.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Edit(int Id)
        {
            return View();
        }

        public IActionResult Add(SavePostViewModel model) { 
        

        return View(model);
        }
    }
}
