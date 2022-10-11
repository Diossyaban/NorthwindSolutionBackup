using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Customer customer)
        {
            Update(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCategory(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CustomerId).ToListAsync();
        }

        public async Task<Customer> GetCategoryById(string customerId, bool trackChanges)
        {
            return await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Customer customer)
        {
            Create(customer);
        }

        public void Remove(Customer customer)
        {
            Delete(customer);
        }
    }
}
