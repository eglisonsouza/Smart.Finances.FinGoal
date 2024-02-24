using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Models.Enuns;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class TransactionService(
            IFinancialGoalRepository repositoryFinancialGoal,
            ITransactionOperationRepository repositoryTransactionOperation,
            ICacheService cache
        ) : ITransactionService
    {
        private readonly IFinancialGoalRepository _repositoryFinancialGoal = repositoryFinancialGoal;
        private readonly ITransactionOperationRepository _repositoryTransactionOperation = repositoryTransactionOperation;
        private readonly ICacheService _cacheService = cache;

        public async Task<FinancialGoalTransactions> Process(IOperationTransactionService transactionService, FinancialGoalTransactions transaction)
        {
            await ValidateStatusFinancialGoal(transaction);

            var balance = await CalculatedBalance(transaction.FinancialGoalId);

            transactionService.Process(transaction, ref balance);

            await _cacheService.Set($"balance{transaction.FinancialGoalId}", balance);

            return await _repositoryTransactionOperation.AddAsync(transaction);
        }

        private async Task ValidateStatusFinancialGoal(FinancialGoalTransactions transaction)
        {
            var financialEntity = await _repositoryFinancialGoal.GetById(transaction.FinancialGoalId) ?? throw new EntityNotFoundException();

            if (financialEntity.StatusDifferentInProgress())
                throw new StatusNeedsToBeInProgressException();
        }

        private async Task<(decimal Deposits, decimal Withdraws)> GetTransactions(Guid financialGoalId)
        {
            var transactions = await _repositoryTransactionOperation.GetAll(financialGoalId);

            var sumDeposit = transactions.Where(t => t.TransactionType.Equals(TransactionType.Deposit)).Sum(t => t.Amount);
            var sumWithdraw = transactions.Where(t => t.TransactionType.Equals(TransactionType.Withdraw)).Sum(t => t.Amount);

            return (sumDeposit, sumWithdraw);
        }

        private async Task<decimal> CalculatedBalance(Guid financialGoalId)
        {
            var balance = await _cacheService.Get<decimal>($"balance{financialGoalId}");
            
            if (balance != 0) return balance;
            
            var (deposits, withdraws) = await GetTransactions(financialGoalId);

            return deposits - withdraws;

        }
    }
}
