using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TealHub.Domain.Entities;

namespace TealHub.Infrastructure.Persistence.Configurations;

public class ResponseConfiguration : IEntityTypeConfiguration<Response>
{
    public void Configure(EntityTypeBuilder<Response> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Content)
            .IsRequired();
    }
}