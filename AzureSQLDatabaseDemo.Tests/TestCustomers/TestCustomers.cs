using AzureSQLDatabaseDemo.DAL.Context;
using AzureSQLDatabaseDemo.DAL.Models;
using AzureSQLDatabaseDemo.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using AzureSQLDatabaseDemo.Tests.Helpers;

namespace AzureSQLDatabaseDemo.Tests.TestCustomers
{
    [TestClass]
    public sealed class TestCustomers
    {
        [TestMethod]
        public async Task TestCreate()
        {
            var unitOfWorkAndContext = CreateTestUnitOfWorkAndContext();

            var createModel = new Pages_Customers.CreateModel(unitOfWorkAndContext.unitOfWork.Object);

            createModel.Customer = new Customer
            {
                Id = 1,
                Name = "Test",
                Email = "test@gmail.com"
            };

            await createModel.OnPostAsync();

            unitOfWorkAndContext.context.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }    

        [TestMethod]
        public async Task TestDelete()
        {
            var unitOfWorkAndContext = CreateTestUnitOfWorkAndContext();
           
            var deleteModel = new Pages_Customers.DeleteModel(unitOfWorkAndContext.unitOfWork.Object);
         
            var idForDelete = 1;
            await deleteModel.OnPostAsync(id: idForDelete);

            unitOfWorkAndContext.context.Verify(x => x.Remove(It.IsAny<Customer>()));
            unitOfWorkAndContext.context.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }      

        private static (Mock<AppDbUnitOfWork> unitOfWork, Mock<AppDbContext> context) CreateTestUnitOfWorkAndContext()
        {
            var data = new List<Customer>
            {
                new Customer { Id = 1, Name = "Sample Name", Email= "SampleName@gmail.com"},
                new Customer { Id = 2, Name = "Sample Name 2", Email= "SampleName2@gmail.com"},
                new Customer { Id = 3, Name = "Sample Name 3", Email= "SampleName3@gmail.com"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();

            CancellationToken cancellationToken = default;
            mockSet.As<IAsyncEnumerable<Customer>>()
                .Setup(m => m.GetAsyncEnumerator(cancellationToken))
                .Returns(new TestAsyncEnumerator<Customer>(data.GetEnumerator()));

            mockSet.As<IQueryable<Customer>>()
                    .Setup(m => m.Provider)
                    .Returns(new TestAsyncQueryProvider<Customer>(data.Provider));

            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;
            var mockContext = new Mock<AppDbContext>(options);            
            
            mockContext.Setup(c => c.Set<Customer>()).Returns(mockSet.Object);
            Mock<AppDbUnitOfWork> unitOfWork = new Mock<AppDbUnitOfWork>(mockContext.Object);

            return (unitOfWork, mockContext);
        }
    }
}
