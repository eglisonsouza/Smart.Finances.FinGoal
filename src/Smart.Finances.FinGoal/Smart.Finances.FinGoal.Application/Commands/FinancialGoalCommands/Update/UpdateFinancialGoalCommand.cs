using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Base;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Update
{
    public class UpdateFinancialGoalCommand : FinancialGoalBase, IRequest<FinancialGoalViewModel>
    {
        public Guid Id { get; set; }
    }
}
