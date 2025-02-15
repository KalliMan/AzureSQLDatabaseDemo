using AzureSQLDatabaseDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureSQLDatabaseDemo.DAL.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(q => q.Name).IsUnique();

            builder.HasMany(c => c.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData([
                    new Customer
                    {
                        Id = 1,
                        Name = "Kalin",
                        Email = "kalin@gmail.com"
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "Taras",
                        Email = "taras@gmail.com"
                    },
                    new Customer
                    {
                        Id = 3,
                        Name = "Oksana",
                        Email = "oksana@gmail.com"
                    },
                    new Customer
                    {
                        Id = 4,
                        Name = "Andrii",
                        Email = "andrii@gmail.com"
                    },
                ]);
        }
    }
}
