using Smart.Finances.FinGoal.Core.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class FinancialGoal : BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GoalAmount { get; set; }
        public DateTime? Deadline { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Decimal? IdealMonthySaving { get; set; }
        public FinancialGoalStatus Status { get; set; }
        public IList<FinancialGoalTransactions>? Transactions { get; set; }
    }
}
