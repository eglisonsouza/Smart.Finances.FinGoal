using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.UpdateStatus.Commands.Base;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.UpdateStatus.Commands
{
    public class CompletedFinancialGoalCommand(Guid id) : UpdateStatusBaseCommand(id)
    {
    }
}
