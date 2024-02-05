using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Infra.Persistence.Configuration.EntitiesMap
{
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.CreatedAt)
                .IsRequired();
            builder
                .Property(p => p.UpdatedAt);

            builder
                .Property(p => p.IsDeleted);
        }
    }
}
