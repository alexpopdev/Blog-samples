using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AutomateEntityFrameworkMocking
{
    using Ploeh.AutoFixture;

    [TestFixture]
    public class TestFixture
    {
        [Test]
        public void SqlCE_Customers_Count_GreaterThanZero()
        {
            int customersCount = 0;
            using (var dataContext = new NorthwindEntities())
            {
                customersCount = dataContext.Customers.Count();
            }
            Assert.That(customersCount, Is.GreaterThan(0));
        }


        [Test]
        public void InMemory_Customers_Count_GreaterThanZero()
        {
            var dbContextBuilder = new DbContextBuilder();
            var fixture = new Ploeh.AutoFixture.Fixture();
            
            dbContextBuilder.Customers = fixture.Build<Customer>()
                .Without(c => c.Orders)
                .CreateMany(2)
                .ToList();

            IDbContext dbContext = dbContextBuilder.BuildDbContext();

            int customersCount = dbContext.Customers.Count();

            Assert.That(customersCount, Is.GreaterThan(0));
        }
    }
}
