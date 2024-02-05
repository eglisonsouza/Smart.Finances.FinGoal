using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Infra.Persistence.Configuration.EntitiesMap
{
    public class FinancialGoalConfiguration : BaseConfiguration<FinancialGoal>
    {
        public void Configure(EntityTypeBuilder<FinancialGoal> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.GoalAmount).IsRequired();
            builder.Property(p => p.Deadline);
            builder.Property(p => p.IdealMonthySaving);
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Transactions);

            builder.HasMany(p => p.Transactions).WithOne(p => p.FinancialGoal).HasForeignKey(p => p.FinancialGoalId);
        }
    }
}
