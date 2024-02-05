using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Essentials.EFCore;
using Smart.Finances.FinGoal.Infra.Persistence.Configuration;

namespace Smart.Finances.FinGoal.Infra.Persistence.Extensions
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEfCore<SqlServerConfig>(configuration);
            return services;
        }
    }
}
