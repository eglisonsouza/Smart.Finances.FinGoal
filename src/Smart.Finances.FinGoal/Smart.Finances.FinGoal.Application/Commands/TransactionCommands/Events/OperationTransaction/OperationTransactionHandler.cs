using MediatR;
using Smart.Finances.FinGoal.Application.Commands.TransactionCommands.ViewModels;
using Smart.Finances.FinGoal.Application.Services.OperationTransaction;
using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Events.OperationTransaction
{
    public class OperationTransactionHandler(ITransactionService service) :
        IRequestHandler<DepositTransactionCommand, TransactionViewModel>,
        IRequestHandler<WithdrawTransactionCommand, TransactionViewModel>
    {
        private readonly ITransactionService _service = service;
        public async Task<TransactionViewModel> Handle(DepositTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _service.Process(new DepositTransactionService(), request.ToEntity().Deposit());

            return TransactionViewModel.FromEntity(transaction);
        }


        public async Task<TransactionViewModel> Handle(WithdrawTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _service.Process(new WithdrawTransactionService(), request.ToEntity().Withdraw());

            return TransactionViewModel.FromEntity(transaction);
        }
    }
}
