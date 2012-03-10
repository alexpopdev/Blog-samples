namespace AutomateEntityFrameworkMocking.Tests
{
    using System;
    using System.Linq;

    using Moq;

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
            //Arrange
            var customers = new[]
                {
                    new Customer
                        {
                            Company_Name = "Company1",
                        },
                    new Customer
                        {
                            Company_Name = "Company2",
                        }
                };

            var orders = new[]
                {
                    new Order
                        {
                            Order_ID = 1,
                            Order_Date = new DateTime(2012, 02, 01),
                            Customer = customers[0]
                        }, 
                    new Order
                        {
                            Order_ID = 2,
                            Order_Date = new DateTime(2012, 02, 02),
                            Customer = customers[0]
                        }
                };

            customers[0].Orders = orders;

            var dbContext = Mock.Of<IDbContext>(
                context =>
                context.Customers == customers.AsQueryable()
                && context.Orders == orders.AsQueryable());
            var customerService = new CustomerService(dbContext);

            //Act
            int customersCount = customerService.GetLast5CustomersWithOrders().Count();
            
            Assert.That(customersCount, Is.EqualTo(1));
        }


        [Test]
        public void DbContextBuilder_GetLast5CustomersWithOrders_HasCorrectCount()
        {
            var dbContextBuilder = new DbContextBuilder();
            //Arrange
            dbContextBuilder.Customers.AddRange(
                new[]
                {
                    new Customer
                        {
                            Company_Name = "Company1",
                        },
                    new Customer
                        {
                            Company_Name = "Company2",
                        }
                });

            dbContextBuilder.Customers[0].Orders = 
                new[]
                {
                    new Order
                        {
                            Order_ID = 1,
                            Order_Date = new DateTime(2012, 02, 01),
                            Customer = dbContextBuilder.Customers[0]
                        }, 
                    new Order
                        {
                            Order_ID = 2,
                            Order_Date = new DateTime(2012, 02, 02),
                            Customer = dbContextBuilder.Customers[0]
                        }
                };

            //dbContextBuilder.Customers[0].Orders. = DbContextBuilder.Orders;

            IDbContext dbContext = dbContextBuilder.BuildDbContext();

            var customerService = new CustomerService(dbContext);

            //Act
            int customersCount = customerService.GetLast5CustomersWithOrders().Count();

            Assert.That(customersCount, Is.EqualTo(1));
        }

        [Test]
        public void DbContextBuilderWithAutoFixture_GetLast5CustomersWithOrders_HasCorrectCount()
        {
            var dbContextBuilder = new DbContextBuilder();
            var fixture = new Ploeh.AutoFixture.Fixture();

            //Arrange
            dbContextBuilder.Customers = fixture.Build<Customer>()
                .Without(c => c.Orders)
                .CreateMany(2)
                .ToList();

            dbContextBuilder.Customers[0].Orders = fixture.Build<Order>()
                .With(o => o.Customer, dbContextBuilder.Customers[0])
                .With(o => o.Order_Date, DateTime.Now.AddDays(-1))
                .Without(o => o.Order_Details)
                .Without(o => o.Employee)
                .Without(o => o.Shipper)
                .CreateMany(3)
                .ToList();

            IDbContext dbContext = dbContextBuilder.BuildDbContext();

            //Act
            var customerService = new CustomerService(dbContext);
            int customersCount = customerService.GetLast5CustomersWithOrders().Count();

            Assert.That(customersCount, Is.EqualTo(1));
        }
    }
}
