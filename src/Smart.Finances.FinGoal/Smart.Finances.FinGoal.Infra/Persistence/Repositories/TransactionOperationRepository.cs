using Microsoft.EntityFrameworkCore;
using Smart.Essentials.EFCore;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Repositories;
using Smart.Finances.FinGoal.Infra.Persistence.Configuration;
using Smart.Finances.FinGoal.Infra.Persistence.Repositories.Base;

namespace Smart.Finances.FinGoal.Infra.Persistence.Repositories
{
    public class TransactionOperationRepository(SqlServerDbContext context) : ITransactionOperationRepository
    {
        private readonly GenericRepository<FinancialGoalTransactions> _genericRepository = new(context);
        private readonly SqlServerDbContext _context = context;


        public Task<FinancialGoalTransactions> AddAsync(FinancialGoalTransactions transaction)
        {
            return _genericRepository.AddAsync(transaction);
        }

        public Task<List<FinancialGoalTransactions>> GetAll(Guid financialGoalId)
        {
            return _context.FinancialGoalTransactions.Where(e => e.FinancialGoalId.Equals(financialGoalId)).ToListAsync();
        }
    }
}
