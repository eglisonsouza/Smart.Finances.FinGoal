using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Base;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add
{
    public class AddFinancialGoalCommand : FinancialGoalBase, IRequest<FinancialGoalViewModels>
    {
        public FinancialGoal ToEntity()
        {
            return new FinancialGoal(Name, GoalAmount, Deadline, IdealMonthySaving);
        }
    }
}
