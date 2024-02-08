using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Get
{
    public class GetAllFinancialGoalCommand : IRequest<IList<FinancialGoalViewModel>>
    {
    }
}
