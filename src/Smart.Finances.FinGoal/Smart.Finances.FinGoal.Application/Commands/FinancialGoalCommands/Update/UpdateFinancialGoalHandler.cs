using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Update
{
    public class UpdateFinancialGoalHandler(IFinancialGoalRepository repository) : IRequestHandler<UpdateFinancialGoalCommand, FinancialGoalViewModel>
    {
        private readonly IFinancialGoalRepository _repository = repository;

        public async Task<FinancialGoalViewModel> Handle(UpdateFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id) ?? throw new EntityNotFoundException();

            entity.Update(request.Name, request.GoalAmount, request.IdealMonthySaving);
            _repository.Update(entity);

            return FinancialGoalViewModel.FromEntity(entity);
        }
    }
}
