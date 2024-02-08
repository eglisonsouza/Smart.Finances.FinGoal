using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add
{
    public class AddFinancialGoalHandler(IFinancialGoalRepository repository) : IRequestHandler<AddFinancialGoalCommand, FinancialGoalViewModels>
    {
        private readonly IFinancialGoalRepository _repository = repository;

        public async Task<FinancialGoalViewModels> Handle(AddFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddAsync(request.ToEntity());
            return FinancialGoalViewModels.FromEntity(entity);
        }
    }
}
