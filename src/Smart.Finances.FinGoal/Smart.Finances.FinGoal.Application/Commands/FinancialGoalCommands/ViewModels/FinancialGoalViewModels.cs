using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Base;
using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels
{
    public class FinancialGoalViewModels : FinancialGoalBase
    {
        public FinancialGoalViewModels(string name, decimal goalAmount, DateTime? deadline, decimal? idealMonthySaving)
        {
            Name = name;
            GoalAmount = goalAmount;
            Deadline = deadline;
            IdealMonthySaving = idealMonthySaving;
        }

        public static FinancialGoalViewModels FromEntity(FinancialGoal entity)
        {
            return new FinancialGoalViewModels
                (
                    name: entity.Name,
                    goalAmount: entity.GoalAmount,
                    deadline: entity.Deadline,
                    idealMonthySaving: entity.IdealMonthySaving
                );
        }
    }
}
