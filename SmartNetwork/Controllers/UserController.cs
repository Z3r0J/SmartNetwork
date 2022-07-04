using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Users;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApp.SmartNetwork.Middlewares;

namespace WebApp.SmartNetwork.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ValidateUserSession _validateUserSession;
        public UserController(IUserServices userServices,ValidateUserSession validateUserSession)
        {
            _userServices = userServices;
            _validateUserSession = validateUserSession;
        }
        public IActionResult Index()
        {

            return _validateUserSession.HasUser()? RedirectToRoute(new { action="Index",controller="Home"  }) : View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm) {

            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "Home" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var session = await _userServices.Login(vm);
            if (session!=null)
            {
                HttpContext.Session.Set<UserViewModel>("userSmartNetwork", session);
                return RedirectToRoute(new { action = "Index", controller = "Home" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso incorrecto o tu cuenta no esta activa revisa tu correo");
            }
            return View(vm);
        
        }

        public IActionResult Logout() {

            HttpContext.Session.Remove("userSmartNetwork");

            return RedirectToRoute(new { action = "Index", controller = "User" });
        
        }

        public async Task<IActionResult> Activate(int Id) {

            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "Home" });
            }

            var response = await _userServices.GetByIdSaveViewModel(Id);

            if (response.Status != 1)
            {
                response.Status = 1;

                await _userServices.Update(response, Id);

                ViewBag.ActivationMessage = "You account was activated successfully!";
                return View("Index");
            }

            else {
                ViewBag.ErrorActivation = "The link follow has been expired.";
                return View("Index");
            }

        }

        public IActionResult Register() {

            return _validateUserSession.HasUser() ? RedirectToRoute(new { action = "Index", controller = "Home" }) : View(new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm) {

            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { action = "Index", controller = "Home" });
            }

            if (!ModelState.IsValid) { 
            
                return View(vm);
            
            }
            if (await _userServices.CheckUsername(vm.Username))
            {
                ModelState.AddModelError("Username", "The username has been taken.");

                return View(vm);
            }

           var response = await _userServices.Add(vm);

            response.PhotoUrl = UploadFile(vm.File, response.Id);

            await _userServices.Update(response,response.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string username) {

            if (!await _userServices.CheckUsername(username))
            {
                ModelState.AddModelError("Username", "The username has been taken.");
                return View("Index");
            }

            else {
                await _userServices.ChangePassword(username);
                ViewBag.ActivationMessage = "The email was send with the new Password";
                return View("Index");
            }
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
            string basePath = $"/Images/UserPhoto/{id}";
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
