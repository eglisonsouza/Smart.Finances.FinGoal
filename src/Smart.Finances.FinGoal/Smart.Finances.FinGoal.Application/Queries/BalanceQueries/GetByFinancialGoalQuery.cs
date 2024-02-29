using MediatR;
using Smart.Finances.FinGoal.Application.Queries.BalanceQueries.ViewModels;

namespace Smart.Finances.FinGoal.Application.Queries.BalanceQueries
{
    public class GetByFinancialGoalQuery : IRequest<BalanceViewModel>
    {
        public Guid FinancialGoalId { get; set; }
    }
}
