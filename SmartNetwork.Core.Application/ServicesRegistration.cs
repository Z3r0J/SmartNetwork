using Microsoft.Extensions.DependencyInjection;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service) {

            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IGenericServices<,,>),typeof(GenericServices<,,>));
            service.AddTransient<IUserServices, UserServices>();
            service.AddTransient<ICommentServices, CommentServices>();
            service.AddTransient<IPostServices, PostServices>();
        }
    }
}
