using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Core.Service
{
    public interface IOperationTransactionService
    {
        void Process(FinancialGoalTransactions transaction, ref decimal balance);
    }
}
