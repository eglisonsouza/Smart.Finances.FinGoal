using Smart.Finances.FinGoal.Core.Models.Enuns;

namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class FinancialGoal : BaseEntity
    {
        public string Name { get; set; }
        public decimal GoalAmount { get; set; }
        public DateTime? Deadline { get; set; }
        public Decimal? IdealMonthySaving { get; set; }
        public FinancialGoalStatus Status { get; set; }
        public IList<FinancialGoalTransactions>? Transactions { get; set; }
    }
}
