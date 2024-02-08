using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.UpdateStatus.Commands.Base;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.UpdateStatus.Commands
{
    public class CompletedFinancialGoalCommand(Guid id) : UpdateStatusBaseCommand(id)
    {
    }
}
