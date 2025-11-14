namespace JuliePro.Services
{
    public interface IServiceBaseAsync<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<PaginatedList<T>> GetAllPaginatedAsync(int pageIndex, int pageSize);
        Task<T> GetByIdAsync(int id);
        Task EditAsync(T entity);
        Task<bool> ExistsAsync(int id);
    }
}
