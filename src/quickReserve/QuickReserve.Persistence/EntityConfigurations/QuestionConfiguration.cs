using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Text)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasOne(q => q.JobAdForm)
                   .WithMany(f => f.Questions)
                   .HasForeignKey(q => q.JobAdFormId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q => q.Answer)
                   .WithOne(a => a.Question)
                   .HasForeignKey<Answer>(a => a.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
