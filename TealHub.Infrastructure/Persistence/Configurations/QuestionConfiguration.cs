using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TealHub.Domain.Entities;

namespace TealHub.Infrastructure.Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Content)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasOne(q => q.User)
            .WithMany(u => u.Questions)
            .HasForeignKey(q => q.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(q => q.Response)
            .WithOne(r => r.Question)
            .HasForeignKey<Response>(r => r.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}