using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Core.Service;
using Smart.Finances.FinGoal.Infra.Persistence.Configuration;
using Smart.Finances.FinGoal.Infra.Persistence.Repositories;
using Smart.Finances.FinGoal.Infra.Service;
namespace Smart.Finances.FinGoal.Infra.Extensions
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(configuration.GetSection("Settings").GetConnectionString("SqlServerConnection"),
                    b => b.MigrationsAssembly(typeof(SqlServerDbContext).Assembly.FullName)));
            
            services.AddService();
            services.AddRepositories();
            services.AddDistributedCache();
            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
            services.AddScoped<ITransactionOperationRepository, TransactionOperationRepository>();
        }

        private static void AddService(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();
        }

        private static void AddDistributedCache(this IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost,port:6379,password=Redis2024!";
                options.InstanceName = "fin-goal";
            });
        }
    }
}
