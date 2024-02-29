namespace Smart.Finances.FinGoal.Core.Service
{
    public interface IBalanceService
    {
        Task<decimal> CalculatedBalance(Guid financialGoalId);
        void AddBalanceInCache(Guid financialGoalId, decimal balance);
        Task<decimal> CalculatedBalanceNoCache(Guid financialGoalId);
    }
}
