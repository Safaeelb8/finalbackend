using Microsoft.EntityFrameworkCore;
using TealHub.Domain.Entities;
using TealHub.Infrastructure.Persistence.Configurations;

namespace TealHub.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Response> Responses => Set<Response>();
    public DbSet<Source> Sources => Set<Source>();
    public DbSet<Log> Logs => Set<Log>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new ResponseConfiguration());
        modelBuilder.ApplyConfiguration(new SourceConfiguration());
        modelBuilder.ApplyConfiguration(new LogConfiguration());
    }
}