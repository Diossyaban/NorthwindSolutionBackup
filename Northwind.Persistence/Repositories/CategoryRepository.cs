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
    internal class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Category category)
        {
            Update(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategory(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CategoryName).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int categoryId, bool trackChanges)
        {
            return await FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Category category)
        {
            Create(category);
        }

        public void Remove(Category category)
        {
            Delete(category);
        }
    }
}
