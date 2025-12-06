using AzureSQLDatabaseDemo.DAL.Context;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.Repositories;

namespace AzureSQLDatabaseDemo.DAL.UnitOfWork
{
    public class AppDbUnitOfWork : IDisposable, IAppDbUnitOfWork
    {
        private bool _disposed = false;
        private readonly AppDbContext _context;

        public GenericRepository<Customer> CustomerRepository { get; init; }
        public GenericRepository<Order> OrderRepository { get; init; }
        public GenericRepository<Product> ProductRepository { get; init; }

        public AppDbUnitOfWork(AppDbContext context)
        {
            _context = context;

            CustomerRepository = new GenericRepository<Customer>(_context);
            OrderRepository = new GenericRepository<Order>(_context);
            ProductRepository = new GenericRepository<Product>(_context);
        }

        public async Task<int> SaveChangesAsync()
         => await _context.SaveChangesAsync();

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
