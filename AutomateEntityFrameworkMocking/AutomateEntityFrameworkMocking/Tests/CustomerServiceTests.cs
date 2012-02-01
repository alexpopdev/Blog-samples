namespace AutomateEntityFrameworkMocking.Tests
{
    using System.Linq;

    using NUnit.Framework;
   
    using AutomateEntityFrameworkMocking.Data;
    using AutomateEntityFrameworkMocking.Domain;

    using Ploeh.AutoFixture;

    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void SqlCE_GetLast5CustomersWithOrders_HasCorrectCount()
        {
            int customersCount = 0;
            using (var dbContext = new NorthwindEntities())
            {
                var customerService = new CustomerService(dbContext);
                customersCount = customerService.GetLast5CustomersWithOrders().Count();
            }

            Assert.That(customersCount, Is.EqualTo(5));
        }


        [Test]
        public void InMemory_GetLast5CustomersWithOrders_HasCorrectCount()
        {
            var dbContextBuilder = new DbContextBuilder();
            var fixture = new Ploeh.AutoFixture.Fixture();
            
            dbContextBuilder.Customers = fixture.Build<Customer>()
                .Without(c => c.Orders)
                .CreateMany(2)
                .ToList();

            dbContextBuilder.Customers[0].Orders = fixture.Build<Order>()
                .Without(o => o.Order_Details)
                .CreateMany(1)
                .ToList();

            IDbContext dbContext = dbContextBuilder.BuildDbContext();

            var customerService = new CustomerService(dbContext);
           int customersCount = customerService.GetLast5CustomersWithOrders().Count();

            Assert.That(customersCount, Is.EqualTo(1));
        }
    }
}
