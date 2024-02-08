using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Base;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add
{
    public class AddFinancialGoalCommand : FinancialGoalBase, IRequest<FinancialGoalViewModels>
    {
    }
}
