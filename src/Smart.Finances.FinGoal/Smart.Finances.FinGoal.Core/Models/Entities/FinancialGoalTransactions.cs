using Smart.Finances.FinGoal.Core.Models.Enuns;

namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class FinancialGoalTransactions : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
