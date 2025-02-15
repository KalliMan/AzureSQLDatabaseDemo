
using AzureSQLDatabaseDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureSQLDatabaseDemo.DAL.Configurations
{
    internal class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData([
                    new Order
                    {
                        Id = 1,
                        CustomerId = 1,
                        ProductId = 1,
                    },
                    new Order
                    {
                        Id = 2,
                        CustomerId = 1,
                        ProductId = 1,
                    },
                    new Order
                    {
                        Id = 3,
                        CustomerId = 2,
                        ProductId = 3,
                    },
                    new Order
                    {
                        Id = 4,
                        CustomerId = 2,
                        ProductId = 5,
                    },
                ]);
        }
    }
}
