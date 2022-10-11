using AutoMapper;
using Northwind.Contracts.Dto.Product;
using Northwind.Contracts.Dto.Supplier;
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
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductPhotoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(ProductPhotoDto ProductPhotoDto)
        {
            var edit = _mapper.Map<ProductPhoto>(ProductPhotoDto);
            _repositoryManager.ProductPhotoRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges)
        {
            var ProductPhotoModel = await _repositoryManager.ProductPhotoRepository.GetAllProductPhoto(trackChanges);
            var ProductPhotoDto = _mapper.Map<IEnumerable<ProductPhotoDto>>(ProductPhotoModel);
            return ProductPhotoDto;
        }

        public async Task<ProductPhotoDto> GetProductPhotoById(int ProductPhotoId, bool trackChanges)
        {
            var ProductPhotoModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoById(ProductPhotoId, trackChanges);
            var ProductPhotoDto = _mapper.Map<ProductPhotoDto>(ProductPhotoModel);
            return ProductPhotoDto;
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetProductPhotoPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var ProductPhotoModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoPaged(pageIndex, pageSize, trackChanges);
            var ProductPhotoDto = _mapper.Map<IEnumerable<ProductPhotoDto>>(ProductPhotoModel);
            return ProductPhotoDto;
        }

        public void Insert(ProductPhotoCreateDto ProductPhotoForCreateDto)
        {
            var insert = _mapper.Map<ProductPhoto>(ProductPhotoForCreateDto);
            _repositoryManager.ProductPhotoRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(ProductPhotoDto ProductPhotoDto)
        {
            var remove = _mapper.Map<ProductPhoto>(ProductPhotoDto);
            _repositoryManager.ProductPhotoRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
