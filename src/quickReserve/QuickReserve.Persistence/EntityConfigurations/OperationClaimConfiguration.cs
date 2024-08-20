using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {

            // Table name and primary key configuration
            builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

            // Property configurations
            builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
            builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            


            builder.HasData(
               new OperationClaim { Id = 1, Name = "Admin" },
               new OperationClaim { Id = 2, Name = "User" }
           );


        }

    }
  
}
