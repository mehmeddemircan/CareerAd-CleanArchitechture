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
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
          
            builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

     
            builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
            builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

       
            builder.HasOne(uoc => uoc.User)
                   .WithMany()
                   .HasForeignKey(uoc => uoc.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(uoc => uoc.OperationClaim)
                   .WithMany()
                   .HasForeignKey(uoc => uoc.OperationClaimId)
                   .OnDelete(DeleteBehavior.Restrict);

            /*
             *  Restrict, ilişkili kayıtların var olduğu durumlarda ana kayıtların silinmesini engeller.
             * 
             *  Cascade, ana kayıt silindiğinde ilişkili tüm kayıtları da otomatik olarak siler.
             * 
             * */
        }
    }

}
