using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSupplier(bool trackChanges);

        Task<Supplier> GetSupplierById(int suppliersId, bool trackChanges);

        void Insert(Supplier suppliers);

        void Edit(Supplier suppliers);

        void Remove(Supplier suppliers);
    }
}
