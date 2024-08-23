using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class JobAdApplicationConfiguration : IEntityTypeConfiguration<JobAdApplication>
    {
        public void Configure(EntityTypeBuilder<JobAdApplication> builder)
        {
            builder.ToTable("JobAdApplications");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.JobAd)
                   .WithMany(j => j.JobAdApplications)
                   .HasForeignKey(a => a.JobAdId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.User)
                   .WithMany(u => u.JobAdApplications)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
