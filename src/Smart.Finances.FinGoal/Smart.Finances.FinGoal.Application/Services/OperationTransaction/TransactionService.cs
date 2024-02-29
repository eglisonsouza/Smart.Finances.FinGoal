using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class TransactionService(
            IFinancialGoalRepository repositoryFinancialGoal,
            ITransactionOperationRepository repositoryTransactionOperation,
            IBalanceService balanceService) : ITransactionService
    {
        private readonly IFinancialGoalRepository _repositoryFinancialGoal = repositoryFinancialGoal;
        private readonly ITransactionOperationRepository _repositoryTransactionOperation = repositoryTransactionOperation;
        private readonly IBalanceService _balanceService = balanceService;

        public async Task<FinancialGoalTransactions> Process(IOperationTransactionService transactionService, FinancialGoalTransactions transaction)
        {
            await ValidateStatusFinancialGoal(transaction);

            var balance = await _balanceService.CalculatedBalance(transaction.FinancialGoalId);

            transactionService.Process(transaction, ref balance);

            _balanceService.AddBalanceInCache(transaction.FinancialGoalId, balance);

            return await _repositoryTransactionOperation.AddAsync(transaction);
        }

        private async Task ValidateStatusFinancialGoal(FinancialGoalTransactions transaction)
        {
            var financialEntity = await _repositoryFinancialGoal.GetById(transaction.FinancialGoalId) ?? throw new EntityNotFoundException();

            if (financialEntity.StatusDifferentInProgress())
                throw new StatusNeedsToBeInProgressException();
        }
    }
}
