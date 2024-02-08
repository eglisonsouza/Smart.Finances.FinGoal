using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class WithdrawTransactionService : IOperationTransactionService
    {
        public async Task Process()
        {
            Console.WriteLine("Withdraw");
        }
    }
}
