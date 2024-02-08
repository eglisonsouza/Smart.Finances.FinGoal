using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Delete
{
    public class DeleteFinancialGoalCommand(Guid id) : IRequest<FinancialGoalViewModels>
    {
        public Guid Id { get; set; } = id;
    }
}
