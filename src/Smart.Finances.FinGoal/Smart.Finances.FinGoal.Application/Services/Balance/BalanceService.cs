using Smart.Finances.FinGoal.Core.Models.Enuns;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Core.Service;
using System.Transactions;
using Smart.Finances.FinGoal.Application.Extensions;

namespace Smart.Finances.FinGoal.Application.Services.Balance
{
    public class BalanceService(
        ITransactionOperationRepository repositoryTransactionOperation,
        ICacheService cache) : IBalanceService
    {
        private readonly ITransactionOperationRepository _repositoryTransactionOperation = repositoryTransactionOperation;
        private readonly ICacheService _cacheService = cache;
        private const string PrefixKeyCache = "balance";

        public void AddBalanceInCache(Guid financialGoalId, decimal balance)
        {
            _cacheService.Set($"{PrefixKeyCache}{financialGoalId}", balance);
        }

        public async Task<decimal> CalculatedBalance(Guid financialGoalId)
        {
            var balance = await _cacheService.Get<decimal>($"{PrefixKeyCache}{financialGoalId}");
            if (balance != 0) return balance;

            var (deposits, withdraws) = await GetTransactions(financialGoalId);
            return deposits - withdraws;
        }

        public async Task<decimal> CalculatedBalanceNoCache(Guid financialGoalId)
        {
            var (deposits, withdraws) = await GetTransactions(financialGoalId);
            var balance = deposits - withdraws;

            AddBalanceInCache(financialGoalId, balance);

            return balance;
        }

        private async Task<(decimal Deposits, decimal Withdraws)> GetTransactions(Guid financialGoalId)
        {
            var transactions = await _repositoryTransactionOperation.GetAll(financialGoalId);
            
            return (
                transactions.SumDeposits(),
                transactions.SumWithdraws()
                );
        }
    }
}
