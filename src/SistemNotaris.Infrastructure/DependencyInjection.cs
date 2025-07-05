using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemNotaris.Application.Abstraction.Data;
using SistemNotaris.Domain.Abstraction;
using SistemNotaris.Domain.Akta;
using SistemNotaris.Domain.Client;
using SistemNotaris.Domain.Karyawan;
using SistemNotaris.Domain.TrackingsAkta;
using SistemNotaris.Domain.UpdateAkta;
using SistemNotaris.Infrastructure.Data;
using SistemNotaris.Infrastructure.Repositories;

namespace SistemNotaris.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ?? 
                               throw new ArgumentNullException(nameof(configuration));
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(connectionString));
        
        services.AddScoped<IClientRepository,ClientRepository>();
        services.AddScoped<ITrackingAktaRepository, TrackingAktaRepository>();
        services.AddScoped<IUpdateAktaRepository, UpdateTrackingAktaRepository>();
        services.AddScoped<IKaryawanRepository, KaryawanRepository>();
        services.AddScoped<IAktaRepository, AktaRepository>();
        services.AddScoped<IUnitOfWork>(
            sp => sp.GetRequiredService<ApplicationDbContext>()
        );
        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString)
        );
        return services;
    }
}