namespace AzureSQLDatabaseDemo.DAL.Models
{
    public class Product: BaseDomainModel
    {
        public required string Name { get; set; }
        public double Price { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
