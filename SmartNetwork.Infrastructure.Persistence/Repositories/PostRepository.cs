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
    public class PostRepository : GenericRepository<Posts>, IPostRepository
    {
        private readonly ApplicationContext _applicationContext;
        public PostRepository(ApplicationContext applicationContext):base(applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
