namespace Smart.Finances.FinGoal.Application.Queries.BalanceQueries.ViewModels
{
    public class BalanceViewModel
    {
        public decimal Balance { get; set; }

        public static BalanceViewModel FromEntity(decimal balance)
        {
            return new BalanceViewModel
            {
                Balance = balance
            };
        }
    }
}
