using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TealHub.Domain.Entities;

namespace TealHub.Infrastructure.Persistence.Configurations;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Action)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(l => l.IpAddress)
            .HasMaxLength(50);

        builder.HasOne(l => l.User)
            .WithMany(u => u.Logs)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}