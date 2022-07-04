using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Infrastructure.Persistence.Contexts;
using SmartNetwork.Infrastructure.Persistence.Repositories;
using System;

namespace SmartNetwork.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistanceInfrastructure(this IServiceCollection service, IConfiguration configuration) {

            #region Contexts

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("SmartNetworkMemory"));
            }
            else {

                service.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("SmartNetworkConnection"), 
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IUserRepository,UserRepository>();
            service.AddTransient<ICommentRepository,CommentRepository>();
            service.AddTransient<IPostRepository,PostRepository>();
            #endregion

        }
    }
}
