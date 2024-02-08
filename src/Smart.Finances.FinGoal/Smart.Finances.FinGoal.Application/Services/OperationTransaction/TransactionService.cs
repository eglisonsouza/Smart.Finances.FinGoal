using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Models.Enuns;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class TransactionService(
            IFinancialGoalRepository repositoryFinancialGoal,
            ITransactionOperationRepository repositoryTransactionOperation
        ) : ITransactionService
    {
        private readonly IFinancialGoalRepository _repositoryFinancialGoal = repositoryFinancialGoal;
        private readonly ITransactionOperationRepository _repositoryTransactionOperation = repositoryTransactionOperation;

        public async Task<FinancialGoalTransactions> Process(IOperationTransactionService transactionService, FinancialGoalTransactions transaction)
        {
            var financialEntity = await _repositoryFinancialGoal.GetById(transaction.FinancialGoalId) ?? throw new EntityNotFoundException();

            if (!financialEntity.Status.Equals(FinancialGoalStatus.InProgress))
                throw new StatusNeedsToBeInProgressException();

            await transactionService.Process();

            var transactionEntity = await _repositoryTransactionOperation.AddAsync(transaction);

            return transactionEntity;
        }
    }
}
