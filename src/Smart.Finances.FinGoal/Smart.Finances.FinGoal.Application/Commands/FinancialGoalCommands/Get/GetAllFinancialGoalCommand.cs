using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Get
{
    public class GetAllFinancialGoalCommand : IRequest<IList<FinancialGoalViewModel>>
    {
    }
}
