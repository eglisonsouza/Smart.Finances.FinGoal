using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class DepositTransactionService : IOperationTransactionService
    {
        public void Process(FinancialGoalTransactions transaction, ref decimal balance)
        {
            balance +=transaction.Amount;
        }
    }
}
