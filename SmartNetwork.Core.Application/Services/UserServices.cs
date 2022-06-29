using AutoMapper;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.ViewModel.Users;
using SmartNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application.Services
{
    public class UserServices : GenericServices<SaveUserViewModel,UserViewModel,User>, IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailServices _emailServices;
        public UserServices(IUserRepository repository,IMapper mapper,IEmailServices emailServices):base(repository,mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _emailServices = emailServices;
        }

        public async Task<UserViewModel> Login(LoginViewModel vm) {

            var response = await _repository.LoginAsync(vm);

            return _mapper.Map<UserViewModel>(response);
        
        }

        public async override Task<SaveUserViewModel> Add(SaveUserViewModel vm) {

            SaveUserViewModel Savevm = await base.Add(vm);

            if (Savevm ==null)
            {
                return null;
            }

            await _emailServices.SendAsync(new() { 
            To = Savevm.Email,
            Subject = "Welcome to SmartNetwork",
            Body=$"The best network to activate you account click: <a href='https://localhost:44334/User/Activate/{Savevm.Id}'>Here</a>"
            
            });;

            return Savevm;
        }

    }
}
