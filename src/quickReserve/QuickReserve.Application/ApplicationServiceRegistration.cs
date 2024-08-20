using Core.JWT;
using Microsoft.Extensions.DependencyInjection;
using QuickReserve.Application.Services.AuthService;
using QuickReserve.Application.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));



            services.AddScoped<ITokenHelper, JwtHelper>(); 

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
       




            return services;

        }
    }
}
