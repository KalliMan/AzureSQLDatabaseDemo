using AzureSQLDatabaseDemo.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AzureSQLDatabaseDemo.DAL.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T>
        where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Entity => _context.Set<T>();

        public async Task<IList<T>> ToListAsync()
            => await Entity.ToListAsync();

        public async Task<T?> FindAsync(int id)    
            => await _context.FindAsync<T>(id);

        public async virtual Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => await Entity.FirstOrDefaultAsync(predicate);

        public async Task AddAsync(T item)
            => await _context.AddAsync<T>(item);

        public void Remove(T item)        
            => _context.Remove(item);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public void Update(T item)
        {
            _context.Attach(item).State = EntityState.Modified;
        }
    
        public Task UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<T, bool>> predicate)        
            => Entity.Any(predicate);        

    }
}
