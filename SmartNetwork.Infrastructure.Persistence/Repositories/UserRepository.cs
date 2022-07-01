using Microsoft.EntityFrameworkCore;
using SmartNetwork.Core.Application.Helpers;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Application.ViewModel.Users;
using SmartNetwork.Core.Domain.Entities;
using SmartNetwork.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserRepository(ApplicationContext applicationContext):base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<User> LoginAsync(LoginViewModel vm) {
            vm.Password = PasswordEncryption.ComputeSHA256Hash(vm.Password);

            return await _applicationContext
                .Set<User>()
                .FirstOrDefaultAsync(user=>user.Username == vm.Username && user.Password ==vm.Password && user.Status==1);

        }

        public override Task<User> AddAsync(User entity)
        {
            entity.Password = PasswordEncryption.ComputeSHA256Hash(entity.Password);
            entity.Status = 0;
            return base.AddAsync(entity);
        }

        public async Task<User> CheckUsername(string username) {

            return await _applicationContext.Set<User>().FirstOrDefaultAsync(user => user.Username == username);
        
        }
    }
}
