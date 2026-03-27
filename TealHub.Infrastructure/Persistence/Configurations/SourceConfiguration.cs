using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TealHub.Domain.Entities;

namespace TealHub.Infrastructure.Persistence.Configurations;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Excerpt)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(s => s.Document)
            .WithMany(d => d.Sources)
            .HasForeignKey(s => s.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Response)
            .WithMany(r => r.Sources)
            .HasForeignKey(s => s.ResponseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}