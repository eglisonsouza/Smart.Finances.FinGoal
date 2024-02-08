using MediatR;
using Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Base;
using Smart.Finances.FinGoal.Application.Commands.TransactionCommands.ViewModels;

namespace Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Events.OperationTransaction
{
    public class DepositTransactionCommand : TransactionOperationBase, IRequest<TransactionViewModel>
    {        
    }
}
