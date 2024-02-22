using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class DepositTransactionService : IOperationTransactionService
    {
        public async Task Process()
        {
            
            //Atualizar saldo

            Console.WriteLine("Deposit");
        }
    }
}
