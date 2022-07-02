using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Users;
using SmartNetwork.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SmartNetwork.Middlewares;

namespace SmartNetwork.Controllers
{
    public class HomeController : Controller
    {

        private readonly ValidateUserSession _validateUserSession;
        public readonly IUserServices _userServices;
        public HomeController(ValidateUserSession validateUserSession, IUserServices userServices)
        {
            _userServices = userServices;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _userServices.GetAllViewModelWithInclude();

            var user = response.FirstOrDefault(x=>x.Id == HttpContext.Session.Get<UserViewModel>("userSmartNetwork").Id);

            return View(user);
        }
    }
}
