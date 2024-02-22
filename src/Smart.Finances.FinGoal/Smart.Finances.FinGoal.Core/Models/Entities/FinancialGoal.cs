using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class FinancialGoal : BaseEntity
    {
        public string Name { get; private set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GoalAmount { get; private set; }
        public DateTime? Deadline { get; private set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? IdealMonthySaving { get; private set; }
        public FinancialGoalStatus Status { get; private set; }
        public IList<FinancialGoalTransactions>? Transactions { get; private set; }

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
            ValidateStatus();

            Update();
            Name = name;
            GoalAmount = goalAmount;
            IdealMonthySaving = idealMonthySaving;
        }

        public void Cancell()
        {
            UpdateStatus();
            Status = FinancialGoalStatus.Cancelled;
        }

        public void Hold()
        {
            UpdateStatus();
            Status = FinancialGoalStatus.OnHold;
        }

        public void Completed()
        {
            UpdateStatus();
            Status = FinancialGoalStatus.Completed;
        }

        public void Back()
        {
            UpdateStatus();
            Status = FinancialGoalStatus.InProgress;
        }
        public void Deleted()
        {
            Update();
            IsDeleted = true;
        }

        public void ValidateStatus()
        {
            if (Status.Equals(FinancialGoalStatus.Cancelled))
                throw new StatusCannotBeCanceledException();
        }

        public bool StatusDifferentInProgress()
        {
            return !Status.Equals(FinancialGoalStatus.InProgress);
        }

        private static decimal? ValidateIdealMonthySaving(decimal? idealMonthySaving)
        {
            return idealMonthySaving == 0 ? null : idealMonthySaving;
        }

        private static DateTime? ValidateDeadLine(DateTime? deadline)
        {
            return deadline!.Equals(DateTime.MinValue) ? null : deadline;
        }

        private void UpdateStatus()
        {
            ValidateStatus();
            Update();
        }
    }
}
