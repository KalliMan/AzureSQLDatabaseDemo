using AzureSQLDatabaseDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureSQLDatabaseDemo.DAL.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(q => q.Name).IsUnique();

            builder.HasMany(p => p.Orders)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData([
                    new Product
                    {
                        Id = 1,
                        Name = "beer",
                        Price = 2.45
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "whisky",
                        Price = 45.45
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "rakia",
                        Price = 15.50
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "samagon",
                        Price = 18.35
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "gorilka",
                        Price = 28.35
                    },
                ]);
        }
    }
}
