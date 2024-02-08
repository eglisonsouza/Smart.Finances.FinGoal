using Smart.Essentials.EFCore;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Infra.Persistence.Configuration;
using Smart.Finances.FinGoal.Infra.Persistence.Repositories.Base;

namespace Smart.Finances.FinGoal.Infra.Persistence.Repositories
{
    public class TransactionOperationRepository(SqlServerDbContext<SqlServerConfig> context) : ITransactionOperationRepository
    {
        private readonly GenericRepository<FinancialGoalTransactions> _genericRepository = new(context);

        public Task<FinancialGoalTransactions> AddAsync(FinancialGoalTransactions transaction)
        {
            return _genericRepository.AddAsync(transaction);
        }
    }
}
