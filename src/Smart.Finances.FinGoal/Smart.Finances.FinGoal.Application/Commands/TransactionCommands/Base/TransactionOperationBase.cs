using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Base
{
    public class TransactionOperationBase
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid FinancialGoalId { get; set; }

        public FinancialGoalTransactions ToEntity()
        {
            return new FinancialGoalTransactions(Amount, TransactionDate, FinancialGoalId);
        }
    }
}
