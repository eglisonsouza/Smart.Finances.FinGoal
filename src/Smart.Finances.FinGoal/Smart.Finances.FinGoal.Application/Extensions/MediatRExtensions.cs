using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add;
using System.Reflection;

namespace Smart.Finances.FinGoal.Application.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddFinancialGoalHandler).GetTypeInfo().Assembly));

            return services;
        }
    }
}
