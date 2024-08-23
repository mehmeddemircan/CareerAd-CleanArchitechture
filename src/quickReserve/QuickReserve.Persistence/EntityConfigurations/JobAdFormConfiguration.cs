using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class JobAdFormConfiguration : IEntityTypeConfiguration<JobAdForm>
    {
        public void Configure(EntityTypeBuilder<JobAdForm> builder)
        {
            builder.ToTable("JobAdForms");

            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.JobAd)
                   .WithOne(j => j.JobAdForm)
                   .HasForeignKey<JobAdForm>(f => f.JobAdId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Questions)
                   .WithOne(q => q.JobAdForm)
                   .HasForeignKey(q => q.JobAdFormId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
