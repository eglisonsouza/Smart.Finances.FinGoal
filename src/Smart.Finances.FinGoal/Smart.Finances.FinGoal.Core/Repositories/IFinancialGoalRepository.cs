using Smart.Finances.FinGoal.Core.Models.Entities;

namespace Smart.Finances.FinGoal.Core.Repositories
{
    public interface IFinancialGoalRepository
    {
        Task<FinancialGoal> AddAsync(FinancialGoal entity);
        FinancialGoal Update(FinancialGoal entity);
        Task<FinancialGoal?> GetById(Guid id);
        Task<IList<FinancialGoal>> GetAllAsync();
    }
}
