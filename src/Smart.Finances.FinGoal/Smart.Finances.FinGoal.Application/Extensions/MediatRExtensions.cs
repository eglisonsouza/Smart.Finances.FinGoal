using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Add;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Delete;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Update;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.UpdateStatus;
using System.Reflection;

namespace Smart.Finances.FinGoal.Application.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddFinancialGoalHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateFinancialGoalHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateStatusFinancialGoalHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteFinancialGoalHandler).GetTypeInfo().Assembly));

            return services;
        }
    }
}
