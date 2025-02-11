using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.Repositories;

namespace AzureSQLDatabaseDemo.DAL.UnitOfWork
{
    public interface IAppDbUnitOfWork
    {
        public GenericRepository<Customer> CustomerRepository { get; init; }
        public GenericRepository<Order> OrderRepository { get; init; }
        public GenericRepository<Product> ProductRepository { get; init; }

        Task<int> SaveChangesAsync();
        void Dispose();
    }
}