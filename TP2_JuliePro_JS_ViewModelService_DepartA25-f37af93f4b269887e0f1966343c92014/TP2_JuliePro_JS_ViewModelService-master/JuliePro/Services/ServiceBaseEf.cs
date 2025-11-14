using JuliePro.Data;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Services
{
    public class ServiceBaseEF<T> : IServiceBaseAsync<T> where T : class
    {
        protected readonly JulieProDbContext _dbContext;

        public ServiceBaseEF(JulieProDbContext dbContext) => _dbContext = dbContext;

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<PaginatedList<T>> GetAllPaginatedAsync(int pageIndex, int pageSize)
        {

            return await _dbContext.Set<T>().ToPaginatedAsync(pageIndex, pageSize);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task EditAsync(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) _dbContext.Update(entity);
            else _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task<bool> ExistsAsync(int id)
        {
            return await GetByIdAsync(id) != null;
        }
    }
}
