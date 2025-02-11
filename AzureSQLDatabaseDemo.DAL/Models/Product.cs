namespace AzureSQLDatabaseDemo.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }

        public ICollection<Order> orders { get; set; } = new List<Order>();
    }
}
