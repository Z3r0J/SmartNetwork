using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartNetwork.Core.Application.Interfaces.Services;
using SmartNetwork.Core.Domain.Settings;
using SmartNetwork.Infrastructure.Shared.Services;
using System;

namespace SmartNetwork.Infrastructure.Shared
{
    public static class ServicesRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection service, IConfiguration configuration) {

            service.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            service.AddTransient<IEmailServices, EmailServices>();
        }
    }
}
