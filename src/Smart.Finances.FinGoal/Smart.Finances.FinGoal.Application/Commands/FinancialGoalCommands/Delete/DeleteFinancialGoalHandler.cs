using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Delete
{
    public class DeleteFinancialGoalHandler(IFinancialGoalRepository repository) : IRequestHandler<DeleteFinancialGoalCommand, FinancialGoalViewModels>
    {
        private readonly IFinancialGoalRepository _repository = repository;

        public async Task<FinancialGoalViewModels> Handle(DeleteFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id) ?? throw new EntityNotFoundException();
            entity.Deleted();
            _repository.Update(entity);
            return FinancialGoalViewModels.FromEntity(entity);
        }
    }
}
