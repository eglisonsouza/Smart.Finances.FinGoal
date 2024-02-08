using MediatR;
using Smart.Finances.FinGoal.Application.Commands.TransactionCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Enuns;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Events.OperationTransaction
{
    public class OperationTransactionHandler(IFinancialGoalRepository repositoryFinancialGoal, ITransactionOperationRepository repositoryTransactionOperation) :
        IRequestHandler<DepositTransactionCommand, TransactionViewModel>,
        IRequestHandler<WithdrawTransactionCommand, TransactionViewModel>
    {
        private readonly IFinancialGoalRepository _repositoryFinancialGoal = repositoryFinancialGoal;
        private readonly ITransactionOperationRepository _repositoryTransactionOperation = repositoryTransactionOperation;

        public async Task<TransactionViewModel> Handle(DepositTransactionCommand request, CancellationToken cancellationToken)
        {
            var financialEntity = await _repositoryFinancialGoal.GetById(request.FinancialGoalId) ?? throw new EntityNotFoundException();

            if (!financialEntity.Status.Equals(FinancialGoalStatus.InProgress))
                throw new StatusNeedsToBeInProgressException();

            var transaction = await _repositoryTransactionOperation.AddAsync(request.ToEntity().Deposit());

            return TransactionViewModel.FromEntity(transaction);
        }

        public async Task<TransactionViewModel> Handle(WithdrawTransactionCommand request, CancellationToken cancellationToken)
        {
            var financialEntity = await _repositoryFinancialGoal.GetById(request.FinancialGoalId) ?? throw new EntityNotFoundException();

            if (!financialEntity.Status.Equals(FinancialGoalStatus.InProgress))
                throw new StatusNeedsToBeInProgressException();

            var transaction = await _repositoryTransactionOperation.AddAsync(request.ToEntity().Withdraw());

            return TransactionViewModel.FromEntity(transaction);
        }
    }
}
