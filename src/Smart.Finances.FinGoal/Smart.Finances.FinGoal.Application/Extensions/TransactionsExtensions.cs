using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Models.Enuns;

namespace Smart.Finances.FinGoal.Application.Extensions
{
    public static class TransactionsExtensions
    {
        private static decimal SumTransactions(this List<FinancialGoalTransactions> source, TransactionType transactionType)
        {
            return source.Where(t => t.TransactionType.Equals(transactionType)).Sum(t => t.Amount);
        }

        public static decimal SumDeposits(this List<FinancialGoalTransactions> source)
        {
            return source.SumTransactions(TransactionType.Deposit);
        }

        public static decimal SumWithdraws(this List<FinancialGoalTransactions> source)
        {
            return source.SumTransactions(TransactionType.Withdraw);
        }
    }
}
