using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickReserve.Application.Repositories;
using QuickReserve.Persistence.Contexts;
using QuickReserve.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("QuickReserveConnectionString")));

         
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IIndustryTypeRepository, IndustryTypeRepository>();
            services.AddScoped<IJobAdRepository, JobAdRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IJobAdFormRepository, JobAdFormRepository>();
            services.AddScoped<IJobAdApplicationRepository, JobAdApplicationRepository>();
        

            return services;
        }
    }
}
