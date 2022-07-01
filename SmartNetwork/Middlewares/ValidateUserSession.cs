using Microsoft.AspNetCore.Http;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.ViewModel.Users;

namespace WebApp.SmartNetwork.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ValidateUserSession(IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccessor = httpContextAccesor;
        }

        public bool HasUser()
        {

            UserViewModel vm = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("userSmartNetwork");

            return vm == null ? false : true;
        }
    }
}
