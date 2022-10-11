using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IProductPhotoService
    {
        Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges);

        Task<ProductPhotoDto> GetProductPhotoById(int productPhotoId, bool trackChanges);

        Task<IEnumerable<ProductPhotoDto>> GetProductPhotoPaged(int pageIndex, int pageSize, bool trackChanges);

        void Insert(ProductPhotoCreateDto productPhotoCreateDto);

        void Edit(ProductPhotoDto productPhotoDto);

        void Remove(ProductPhotoDto productPhotoDto);
    }
}
