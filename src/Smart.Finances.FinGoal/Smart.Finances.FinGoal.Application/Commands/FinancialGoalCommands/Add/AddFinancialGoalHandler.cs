using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add
{
    public class AddFinancialGoalHandler(IFinancialGoalRepository repository) : IRequestHandler<AddFinancialGoalCommand, FinancialGoalViewModel>
    {
        private readonly IFinancialGoalRepository _repository = repository;

        public async Task<FinancialGoalViewModel> Handle(AddFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddAsync(request.ToEntity());
            return FinancialGoalViewModel.FromEntity(entity);
        }
    }
}
