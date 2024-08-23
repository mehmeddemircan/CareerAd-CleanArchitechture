using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class JobAdConfiguration : IEntityTypeConfiguration<JobAd>
    {
        public void Configure(EntityTypeBuilder<JobAd> builder)
        {
            builder.ToTable("JobAds");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(j => j.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(j => j.Requirements)
                   .HasMaxLength(1000);

            builder.Property(j => j.SalaryRange)
                   .HasMaxLength(50);

            builder.Property(j => j.PostedDate)
                   .IsRequired();

            builder.Property(j => j.Deadline)
                   .IsRequired();

            builder.HasOne(j => j.Company)
                   .WithMany(c => c.JobAds)
                   .HasForeignKey(j => j.CompanyId);
        }
    }
}
