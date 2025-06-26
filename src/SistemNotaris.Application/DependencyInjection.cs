using Microsoft.Extensions.DependencyInjection;
using SistemNotaris.Domain.Karyawan;
using FluentValidation;
using SistemNotaris.Application.Abstraction.Behaviors;

namespace SistemNotaris.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));        
        }); 
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient<OnlineStatusService>();
        return services;
    }
}