using MediatR;
using Smart.Finances.FinGoal.Application.Queries.BalanceQueries.ViewModels;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Queries.BalanceQueries
{
    public class GetByFinancialGoalHandler(IBalanceService balanceService)
        : IRequestHandler<GetByFinancialGoalQuery, BalanceViewModel>
    {
        private readonly IBalanceService _balanceService = balanceService;

        public async Task<BalanceViewModel> Handle(GetByFinancialGoalQuery request, CancellationToken cancellationToken)
        {
            var balance = await _balanceService.CalculatedBalanceNoCache(request.FinancialGoalId);
            return BalanceViewModel.FromEntity(balance);
        }
    }
}
