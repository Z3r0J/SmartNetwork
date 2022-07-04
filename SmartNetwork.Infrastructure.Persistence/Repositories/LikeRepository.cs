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
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        private readonly ApplicationContext _applicationContext;
        public LikeRepository(ApplicationContext applicationContext):base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Like> GetLikeExist(Like entity) { 
        
           var response = await base.GetAllAsync();

            return response.FirstOrDefault(like => like.UserId == entity.UserId && like.PostId == entity.PostId);
        
        }
    }
}
