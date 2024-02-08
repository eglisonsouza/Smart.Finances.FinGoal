using Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Base;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Models.Enuns;

namespace Smart.Finances.FinGoal.Application.Commands.TransactionCommands.ViewModels
{
    public class TransactionViewModel : TransactionOperationBase
    {
        public Guid Id { get; set; }
        public TransactionType TransactionType { get; set; }

        public TransactionViewModel(Guid id, decimal amount, DateTime transactionDate, TransactionType transactionType, Guid financialGoalId)
        {
            Id = id;
            Amount = amount;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            FinancialGoalId = financialGoalId;
        }

        public static TransactionViewModel FromEntity(FinancialGoalTransactions entity)
        {
            return new TransactionViewModel
                (
                    entity.Id, entity.Amount, entity.TransactionDate, entity.TransactionType, entity.FinancialGoalId
                );
        }
    }
}
