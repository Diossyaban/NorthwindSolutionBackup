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
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Supplier suppliers)
        {
            Update(suppliers);
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplier(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.SupplierId).ToListAsync();
        }

        public async Task<Supplier> GetSupplierById(int suppliersId, bool trackChanges)
        {
            return await FindByCondition(c => c.SupplierId.Equals(suppliersId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Supplier suppliers)
        {
            Create(suppliers);
        }

        public void Remove(Supplier suppliers)
        {
            Delete(suppliers);
        }
    }
}
