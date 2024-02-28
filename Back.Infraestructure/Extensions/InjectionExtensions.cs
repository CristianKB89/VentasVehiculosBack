using Back.Infraestructure.Persistences.Contexts;
using Back.Infraestructure.Persistences.Interfaces;
using Back.Infraestructure.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Back.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(VentasVehiculosContext).Assembly.FullName;

            services.AddDbContext<VentasVehiculosContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("BACKConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
