using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Core.Domain.Entities;
using SmartNetwork.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Infrastructure.Persistence.Repositories
{
    public class FriendRepository : GenericRepository<Friend>, IFriendRepository
    {
        private readonly ApplicationContext _applicationContext;
        public FriendRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Friend> CheckAreFriend(Friend entity) {

            var response = await base.GetAllAsync();

            return response.FirstOrDefault(friend => (friend.UserFirst == entity.UserFirst || friend.UserFirst == entity.UserSecond) && (friend.UserSecond == entity.UserFirst || friend.UserSecond == entity.UserSecond));
            
        }
    }
}
