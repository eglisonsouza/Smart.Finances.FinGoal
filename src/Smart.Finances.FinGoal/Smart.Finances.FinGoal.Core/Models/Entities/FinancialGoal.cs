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
        public decimal? IdealMonthySaving { get; set; }
        public FinancialGoalStatus Status { get; set; }
        public IList<FinancialGoalTransactions>? Transactions { get; set; }

        public FinancialGoal(string name, decimal goalAmount, DateTime? deadline, decimal? idealMonthySaving) : base()
        {
            Name = name;
            GoalAmount = goalAmount;
            Deadline = ValidateDeadLine(deadline);
            IdealMonthySaving = ValidateIdealMonthySaving(idealMonthySaving);
            Status = FinancialGoalStatus.InProgress;
        }

        public void Update(string name, decimal goalAmount, decimal? idealMonthySaving)
        {
            Update();
            Name = name;
            GoalAmount = goalAmount;
            IdealMonthySaving = idealMonthySaving;
        }

        private static decimal? ValidateIdealMonthySaving(decimal? idealMonthySaving)
        {
            return idealMonthySaving == 0 ? null : idealMonthySaving;
        }

        private static DateTime? ValidateDeadLine(DateTime? deadline)
        {
            return deadline!.Equals(DateTime.MinValue) ? null : deadline;
        }
    }
}
