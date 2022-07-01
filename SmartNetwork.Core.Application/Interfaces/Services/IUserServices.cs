using SmartNetwork.Core.Application.ViewModel.Users;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Interfaces.Services
{
    public interface IUserServices : IGenericServices<SaveUserViewModel,UserViewModel,User>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<bool> CheckUsername(string username);
        Task ChangePassword(string username);
    }
}
