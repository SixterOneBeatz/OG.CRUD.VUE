using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OG.CRUD.VUE.Application.Common.UnitOfWork;
using System.Data;

namespace OG.CRUD.VUE.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(configuration.GetConnectionString("CustomSoft")));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
