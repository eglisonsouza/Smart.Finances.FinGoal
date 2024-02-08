using Smart.Essentials.EFCore;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Infra.Persistence.Configuration;
using Smart.Finances.FinGoal.Infra.Persistence.Repositories.Base;

namespace Smart.Finances.FinGoal.Infra.Persistence.Repositories
{
    public class FinancialGoalRepository(SqlServerDbContext<SqlServerConfig> context) : IFinancialGoalRepository
    {
        private readonly GenericRepository<FinancialGoal> _genericRepository = new(context);

        public Task<FinancialGoal> AddAsync(FinancialGoal entity)
        {
            return _genericRepository.AddAsync(entity);
        }
    }
}
