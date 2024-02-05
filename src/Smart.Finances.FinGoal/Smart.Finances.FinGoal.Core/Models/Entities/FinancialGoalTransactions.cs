using Smart.Finances.FinGoal.Core.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class FinancialGoalTransactions : BaseEntity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public FinancialGoal FinancialGoal { get; set; }
        public Guid FinancialGoalId { get; set; }
    }
}
