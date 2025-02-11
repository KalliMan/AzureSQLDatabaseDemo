using System.Linq.Expressions;

namespace AzureSQLDatabaseDemo.DAL.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IList<T>> ToListAsync();
        Task<T?> FindAsync(int id);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        bool Exists(Expression<Func<T, bool>> predicate);

        Task AddAsync(T item);
        void Remove(T item);
        Task UpdateAsync(T item);

        Task SaveChangesAsync();
    }
}
