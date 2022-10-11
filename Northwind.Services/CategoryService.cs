using AutoMapper;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        //dependency injection
        public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(CategoryDto categoryDto)
        {
            var edit = _mapper.Map<Category>(categoryDto);
            _repositoryManager.CategoryRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory(bool trackChanges)
        {
            var categoryModel = await _repositoryManager.CategoryRepository.GetAllCategory(trackChanges);
            // source = categoryModel, target = CategoryDto
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categoryModel);
            return categoryDto;
        }

        public async Task<CategoryDto> GetCategoryById(int categoryId, bool trackChanges)
        {
            var model = await _repositoryManager.CategoryRepository.GetCategoryById(categoryId, trackChanges);
            var dto = _mapper.Map<CategoryDto>(model);
            return dto;
        }

        public void Insert(CategoryForCreateDto categoryForCreateDto)
        {
            var newData = _mapper.Map<Category>(categoryForCreateDto);
            _repositoryManager.CategoryRepository.Insert(newData);
            _repositoryManager.Save();
        }

        public void Remove(CategoryDto categoryDto)
        {
            var delete = _mapper.Map<Category>(categoryDto);
            _repositoryManager.CategoryRepository.Remove(delete);
            _repositoryManager.Save();
        }
    }
}
