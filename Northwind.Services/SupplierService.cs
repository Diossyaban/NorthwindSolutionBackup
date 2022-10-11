using AutoMapper;
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
    public class SupplierService : ISupplierService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SupplierService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(SupplierDto supplierDto)
        {
            var edit = _mapper.Map<Supplier>(supplierDto);
            _repositoryManager.SupplierRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<SupplierDto>> GetAllSupplier(bool trackChanges)
        {
            var supplierModel = await _repositoryManager.SupplierRepository.GetAllSupplier(trackChanges);
            var supplierDto = _mapper.Map<IEnumerable<SupplierDto>>(supplierModel);
            return supplierDto;
        }

        public async Task<SupplierDto> GetSupplierById(int supplierId, bool trackChanges)
        {
            var supplierModel = await _repositoryManager.SupplierRepository.GetSupplierById(supplierId, trackChanges);
            var supplierDto = _mapper.Map<SupplierDto>(supplierModel);
            return supplierDto;
        }

        public void Insert(SupplierForCreateDto supplierForCreateDto)
        {
            var edit = _mapper.Map<Supplier>(supplierForCreateDto);
            _repositoryManager.SupplierRepository.Insert(edit);
            _repositoryManager.Save();
        }

        public void Remove(SupplierDto supplierDto)
        {
            var edit = _mapper.Map<Supplier>(supplierDto);
            _repositoryManager.SupplierRepository.Remove(edit);
            _repositoryManager.Save();
        }
    }
}
