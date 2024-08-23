using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Domain.Entities;

namespace QuickReserve.Persistence.EntityConfigurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Response)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.HasOne(a => a.Question)
                   .WithOne(q => q.Answer)
                   .HasForeignKey<Answer>(a => a.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.User)
                   .WithMany()
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
