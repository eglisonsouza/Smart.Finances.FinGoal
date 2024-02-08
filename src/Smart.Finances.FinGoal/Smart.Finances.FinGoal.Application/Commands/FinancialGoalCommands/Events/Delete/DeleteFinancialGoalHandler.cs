using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.Delete
{
    public class DeleteFinancialGoalHandler(IFinancialGoalRepository repository) : IRequestHandler<DeleteFinancialGoalCommand, FinancialGoalViewModel>
    {
        private readonly IFinancialGoalRepository _repository = repository;

        public async Task<FinancialGoalViewModel> Handle(DeleteFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id) ?? throw new EntityNotFoundException();
            entity.Deleted();
            _repository.Update(entity);
            return FinancialGoalViewModel.FromEntity(entity);
        }
    }
}
