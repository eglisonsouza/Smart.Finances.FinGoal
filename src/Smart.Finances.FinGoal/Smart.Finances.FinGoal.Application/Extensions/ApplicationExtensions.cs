using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Add;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Delete;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Update;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.UpdateStatus;
using Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Events.OperationTransaction;
using Smart.Finances.FinGoal.Application.Queries.BalanceQueries;
using Smart.Finances.FinGoal.Application.Services.Balance;
using Smart.Finances.FinGoal.Application.Services.OperationTransaction;
using Smart.Finances.FinGoal.Core.Service;
using System.Reflection;

namespace Smart.Finances.FinGoal.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddServicesDependencies();
            services.AddMediatRDependencies();
            return services;
        }

        public static void AddMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddFinancialGoalHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateFinancialGoalHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateStatusFinancialGoalHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteFinancialGoalHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(OperationTransactionHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetByFinancialGoalHandler).GetTypeInfo().Assembly));
        }

        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IBalanceService, BalanceService>();
        }
    }
}
