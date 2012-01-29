using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AutomateEntityFrameworkMocking
{
    [TestFixture]
    public class TestFixture1
    {
        [Test]
        public void Customers_Count_GreaterThanZero()
        {
            int customersCount = 0;
            using (var dataContext = new NorthwindEntities())
            {
                customersCount = dataContext.Customers.Count();
            }
            Assert.That(customersCount, Is.GreaterThan(0));
        }

        // This test fail for example, replace result or delete this test to see all tests pass
        [Test]
        public void TestFault()
        {
            Assert.IsTrue(false);
        }
    }
}
