using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.LogoImage)
                .IsRequired(false);
            
            builder.Property(c => c.Website)
                   .HasMaxLength(200);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            builder.HasOne(c => c.IndustryType)
                   .WithMany(i => i.Companies)
                   .HasForeignKey(c => c.IndustryTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.JobAds)
                   .WithOne(j => j.Company)
                   .HasForeignKey(j => j.CompanyId);
        }
    }

}
