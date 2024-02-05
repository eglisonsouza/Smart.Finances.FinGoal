using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Infra.Persistence.Configuration.EntitiesMap
{
    public class FinancialGoalTransactionsConfiguration : BaseConfiguration<FinancialGoalTransactions>
    {
        public void Configure(EntityTypeBuilder<FinancialGoalTransactions> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.TransactionDate).IsRequired();
            builder.Property(p => p.TransactionType).IsRequired();
        }
    }
}
