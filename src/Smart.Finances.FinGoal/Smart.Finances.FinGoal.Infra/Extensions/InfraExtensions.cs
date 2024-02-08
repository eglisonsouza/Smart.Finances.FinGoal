using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Essentials.EFCore;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Infra.Persistence.Configuration;
using Smart.Finances.FinGoal.Infra.Persistence.Repositories;
namespace Smart.Finances.FinGoal.Infra.Extensions
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEfCore<SqlServerConfig>(configuration);
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
            services.AddScoped<ITransactionOperationRepository, TransactionOperationRepository>();

            return services;
        }
    }
}
