using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Core.Repositories
{
    public interface ITransactionOperationRepository
    {
        Task<FinancialGoalTransactions> AddAsync(FinancialGoalTransactions transaction);
    }
}
