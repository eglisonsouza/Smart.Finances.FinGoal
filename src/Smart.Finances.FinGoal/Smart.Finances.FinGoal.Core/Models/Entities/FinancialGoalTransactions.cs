using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace Smart.Finances.FinGoal.Core.Models.Entities
{
    public class FinancialGoalTransactions : BaseEntity
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public FinancialGoal? FinancialGoal { get; private set; }
        public Guid FinancialGoalId { get; private set; }

        public FinancialGoalTransactions(decimal amount, DateTime transactionDate, Guid financialGoalId) : base()
        {
            Amount = amount;
            TransactionDate = transactionDate;
            FinancialGoalId = financialGoalId;

            ValidAmount();
        }

        public FinancialGoalTransactions Deposit()
        {
            TransactionType = TransactionType.Deposit;
            return this;
        }

        public FinancialGoalTransactions Withdraw()
        {
            TransactionType = TransactionType.Withdraw;
            return this;
        }

        private void ValidAmount()
        {
            if (Amount <= 0)
                throw new AmountIsInvalidException();
        }
    }
}
