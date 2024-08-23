using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickReserve.Domain.Entities;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class IndustryTypeConfiguration : IEntityTypeConfiguration<IndustryType>
    {
        public void Configure(EntityTypeBuilder<IndustryType> builder)
        {

            // Table name and primary key configuration
            builder.ToTable("IndustryTypes").HasKey(oc => oc.Id);

            // Property configurations
            builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
            builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);


        }

    }
}
