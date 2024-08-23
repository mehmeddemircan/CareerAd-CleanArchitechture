using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuickReserve.Domain.Entities;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }
        public BaseDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<IndustryType> IndustryTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<JobAdForm> JobAdForms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<JobAdApplication> JobAdApplications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

     


    }
}
