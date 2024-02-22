using Smart.Finances.FinGoal.Core.Service;

namespace Smart.Finances.FinGoal.Application.Services.OperationTransaction
{
    public class WithdrawTransactionService : IOperationTransactionService
    {
        public async Task Process()
        {
            //verificar se tem valor no saldo
            //se sim, atualizar saldo
            //senão lança exception
            Console.WriteLine("Withdraw");
        }
    }
}
