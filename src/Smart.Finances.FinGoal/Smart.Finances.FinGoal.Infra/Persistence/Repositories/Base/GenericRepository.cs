using Microsoft.EntityFrameworkCore;

namespace Smart.Finances.FinGoal.Infra.Persistence.Repositories.Base
{
    public class GenericRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<int> AddAllAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return _context.SaveChanges();
        }

        public TEntity Update(TEntity categoria)
        {
            var entity = _dbSet.Update(categoria);
            _context.SaveChanges();
            return entity.Entity;
        }

        public async Task<TEntity?> GetByIdAsync(Guid? id)
        {
            return await _dbSet.FindAsync(id!);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
