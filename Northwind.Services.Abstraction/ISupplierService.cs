using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllSupplier(bool trackChanges);

        Task<SupplierDto> GetSupplierById(int supplierId, bool trackChanges);

        void Insert(SupplierForCreateDto supplierForCreateDto);

        void Edit(SupplierDto supplierDto);

        void Remove(SupplierDto supplierDto);
    }
}
