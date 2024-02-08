using Microsoft.EntityFrameworkCore;
using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Infra.Persistence.Configuration
{
    public class SqlServerConfig
    {
        public required DbSet<FinancialGoal> FinancialGoals { get; set; }
        public required DbSet<FinancialGoalTransactions> FinancialGoalTransactions { get; set; }
    }
}
