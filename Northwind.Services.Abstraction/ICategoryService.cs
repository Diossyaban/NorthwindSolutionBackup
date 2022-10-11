using Northwind.Contracts.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategory(bool trackChanges);

        Task<CategoryDto> GetCategoryById(int categoryId, bool trackChanges);

        void Insert(CategoryForCreateDto categoryForCreateDto);

        void Edit(CategoryDto categoryDto);

        void Remove(CategoryDto categoryDto);
    }
}
