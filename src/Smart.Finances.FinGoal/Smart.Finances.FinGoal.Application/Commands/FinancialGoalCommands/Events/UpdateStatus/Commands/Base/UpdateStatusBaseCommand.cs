using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.UpdateStatus.Commands.Base
{
    public class UpdateStatusBaseCommand(Guid id) : IRequest<FinancialGoalViewModel>
    {
        [Required]
        public Guid Id { get; set; } = id;
    }
}
