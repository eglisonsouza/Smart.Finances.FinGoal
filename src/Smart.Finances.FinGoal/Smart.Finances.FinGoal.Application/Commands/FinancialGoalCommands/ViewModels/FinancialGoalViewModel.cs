using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Base;
using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels
{
    public class FinancialGoalViewModel : FinancialGoalBase
    {
        public Guid Id { get; set; }

        public FinancialGoalViewModel(Guid id, string name, decimal goalAmount, DateTime? deadline, decimal? idealMonthySaving)
        {
            Id = id;
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthySaving = idealMonthySaving;
        }

        public static FinancialGoalViewModel FromEntity(FinancialGoal entity)
        {
            return new FinancialGoalViewModel
                (
                    id: entity.Id,
                    name: entity.Name,
                    goalAmount: entity.GoalAmount,
                    deadline: entity.Deadline,
                    idealMonthySaving: entity.IdealMonthySaving
                );
        }

        public static IList<FinancialGoalViewModel> FromEntity(IList<FinancialGoal> entities)
        {
            return entities.Select(FromEntity).ToList();
        }
    }
}
