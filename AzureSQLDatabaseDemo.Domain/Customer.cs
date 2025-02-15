namespace AzureSQLDatabaseDemo.DAL.Models
{
    public class Customer: BaseDomainModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

        public IList<Order> Orders { get; set; } = [];
    }
}
