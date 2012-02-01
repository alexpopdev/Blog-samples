namespace AutomateEntityFrameworkMocking.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
 
    public class CustomerService
    {
        private readonly IDbContext _dbContext;

        public CustomerService(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IDbContext DbContext
        {
            get
            {
                return this._dbContext;
            }
        }

        public IList<CustomerDTO> GetLast5CustomersWithOrders()
        {
            var referenceDate = DateTime.Now.AddDays(1).Date;
            var customers = (from c in DbContext.Customers.Include(customer => customer.Orders)
                             where c.Orders.Any(order => order.Order_Date < referenceDate)
                             orderby c.Orders.Max(order => order.Order_Date) descending
                             select c)
                             .Take(5)
                             .Select(customer => 
                                     new CustomerDTO
                                         {
                                             Name = customer.Company_Name, 
                                             OrderCount = customer.Orders.Count
                                         })
                             .ToList();
            return customers;
        }
    }
}
