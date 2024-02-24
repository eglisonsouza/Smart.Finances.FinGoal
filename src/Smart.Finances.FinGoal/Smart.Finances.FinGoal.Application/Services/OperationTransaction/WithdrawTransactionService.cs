using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class WithdrawTransactionService() : IOperationTransactionService
    {
        public void Process(FinancialGoalTransactions transaction, ref decimal balance)
        {
            if (transaction.Amount > balance)
            {
                throw new Exception("Amount is invalid");
            }

            balance -= transaction.Amount;
        }
    }
}
