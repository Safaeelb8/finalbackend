using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TealHub.Application.Mappings;
using TealHub.Application.Services;

namespace TealHub.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new UserProfile());
            cfg.AddProfile(new DocumentProfile());
            cfg.AddProfile(new QuestionProfile());
            cfg.AddProfile(new LogProfile());
        });

        services.AddValidatorsFromAssembly(
            typeof(ApplicationServiceRegistration).Assembly);

        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
        services.AddScoped<DocumentService>();
        services.AddScoped<QuestionService>();
        services.AddScoped<LogService>();

        return services;
    }
}