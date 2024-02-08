using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Core.Service
{
    public interface ITransactionService
    {
        Task<FinancialGoalTransactions> Process(IOperationTransactionService transactionService, FinancialGoalTransactions transaction);
    }
}
