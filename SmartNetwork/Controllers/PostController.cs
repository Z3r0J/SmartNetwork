using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Posts;
using SmartNetwork.Core.Application.ViewModel.Users;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApp.SmartNetwork.Middlewares;

namespace WebApp.SmartNetwork.Controllers
{
    public class PostController : Controller
    {
        private readonly ValidateUserSession _validateUserSession;
        private readonly IPostServices _postServices;
        public PostController(IPostServices postServices,ValidateUserSession validateUserSession)
        {
            _validateUserSession = validateUserSession;
            _postServices = postServices;
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "User" });
            }

            var response = await _postServices.GetByIdSaveViewModel(Id);
                     

            return response.UserId != HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id ? RedirectToRoute(new { action="Index",controller="Home"}):View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePostViewModel model) {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "User" });
            }

            if (model.PictureUrl == null && string.IsNullOrEmpty(model.Body)) {

                ModelState.AddModelError("Body", "The text is required.");

                return View(model);

            }

            if (model.PictureUrl != null && model.Image != null && string.IsNullOrWhiteSpace(model.Body))
            {
                model.Body = "";
                if (!string.IsNullOrEmpty(model.PictureUrl))
                {
                    model.PictureUrl = UploadFile(model.Image, model.Id, true, model.PictureUrl);
                }
                else
                {
                    model.PictureUrl = UploadFile(model.Image, model.Id);
                }

                await _postServices.Update(model, model.Id);

                return RedirectToRoute(new { action = "Index", controller = "Home" });

            }

            if (model.PictureUrl == null && model.Image == null && !string.IsNullOrWhiteSpace(model.Body))
            {
               await _postServices.Update(model, model.Id);

                return RedirectToRoute(new { action = "Index", controller = "Home" });

            }

            if (model.PictureUrl!=null && string.IsNullOrWhiteSpace(model.Body))
            {
                model.Body = "";

                await _postServices.Update(model, model.Id);
                return RedirectToRoute(new { action = "Index", controller = "Home" });

            }

            if (model.Image!=null)
            {
                if (!string.IsNullOrEmpty(model.PictureUrl))
                {
                    model.PictureUrl = UploadFile(model.Image, model.Id, true, model.PictureUrl);
                }
                else {
                    model.PictureUrl = UploadFile(model.Image, model.Id);
                }
            }

            await _postServices.Update(model, model.Id);

            return RedirectToRoute(new { action = "Index",controller = "Home" });

        }

        public async Task<IActionResult> Delete(int Id) {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "User" });
            }

            var response = await _postServices.GetByIdSaveViewModel(Id);

            return response.UserId != HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id ? RedirectToRoute(new { action = "Index", controller = "Home" }) : View(response);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(SavePostViewModel model) {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _postServices.Delete(model.Id);


            string basePath = $"/Images/Posts/{model.Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directory.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }


            return RedirectToAction("Index","Home");


        }

        [HttpPost]
        public async Task<IActionResult> Add(SavePostViewModel model) {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action="Index",controller="User" });
            }

            if (model.Image==null&&string.IsNullOrWhiteSpace(model.Body))
            {
                ViewBag.Error = "The field was empty";
                return RedirectToAction("Index", "Home");
            }
            model.UserId = HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id;

            if (model.Image != null && string.IsNullOrWhiteSpace(model.Body)) {

                model.Body = "";
                var post = await _postServices.Add(model);

                post.PictureUrl = UploadFile(model.Image, post.Id);
                await _postServices.Update(post, post
                    .Id);

                return RedirectToAction("Index", "Home");

            }

            var response = await _postServices.Add(model);

            if (model.Image!=null)
            {
                response.PictureUrl = UploadFile(model.Image, response.Id);
                await _postServices.Update(response, response.Id);
            }

            ViewBag.Error = "";

        return RedirectToAction("Index","Home");
        }

        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string ImagePath = "")
        {
            if (isEditMode)
            {
                if (file == null)
                {
                    return ImagePath;
                }
            }
            string basePath = $"/Images/Posts/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = ImagePath.Split("/");
                string oldImagePath = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImagePath);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }
            return $"{basePath}/{fileName}";

        }
    }
}
