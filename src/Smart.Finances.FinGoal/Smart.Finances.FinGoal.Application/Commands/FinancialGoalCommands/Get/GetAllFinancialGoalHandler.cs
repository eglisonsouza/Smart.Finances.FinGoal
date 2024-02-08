using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Get
{
    public class GetAllFinancialGoalHandler(IFinancialGoalRepository repository) : IRequestHandler<GetAllFinancialGoalCommand, IList<FinancialGoalViewModel>>
    {
        private readonly IFinancialGoalRepository _repository = repository;
        public async Task<IList<FinancialGoalViewModel>> Handle(GetAllFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return FinancialGoalViewModel.FromEntity(entities);
        }
    }
}
