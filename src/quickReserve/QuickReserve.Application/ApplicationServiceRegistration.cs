
using Core.Application.Authorization;
using Core.Application.Validation;
using Core.JWT;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuickReserve.Application.Features.Companies.Rules;
using QuickReserve.Application.Features.IndustryTypes.Rules;
using QuickReserve.Application.Features.JobAdForms.Rules;
using QuickReserve.Application.Features.JobAds.Rules;
using QuickReserve.Application.Features.OperationClaims.Rules;
using QuickReserve.Application.Features.Questions.Rules;
using QuickReserve.Application.Features.UserOperationClaims.Rules;
using QuickReserve.Application.Features.Users.Rules;
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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // business rules dependency injection entegresi 
            services.AddScoped<UserOperationClaimBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<IndustryTypeBusinessRules>();
            services.AddScoped<CompanyBusinessRules>();
            services.AddScoped<JobAdBusinessRules>();
            services.AddScoped<JobAdFormBusinessRules>();
            services.AddScoped<QuestionBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


            services.AddScoped<ITokenHelper, JwtHelper>(); 

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
       




            return services;

        }
    }
}
