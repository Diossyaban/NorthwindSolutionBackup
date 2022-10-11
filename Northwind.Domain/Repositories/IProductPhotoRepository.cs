using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IProductPhotoPhotoRepository
    {
        Task<IEnumerable<ProductPhoto>> GetAllProductPhoto(bool trackChanges);

        Task<ProductPhoto> GetProductPhotoById(int ProductPhotoId, bool trackChanges);

        Task<IEnumerable<ProductPhoto>> GetProductPhotoPaged(int pageIndex, int pageSize, bool trackChanges);

        void Insert(ProductPhoto ProductPhoto);

        void Edit(ProductPhoto ProductPhoto);

        void Remove(ProductPhoto ProductPhoto);
    }
}
