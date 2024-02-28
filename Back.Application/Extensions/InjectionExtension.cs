using Back.Application.Interfaces;
using Back.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Back.Application.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            }
            );

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IClienteApplication, ClienteApplication>();

            return services;
        }
    }
}
