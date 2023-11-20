using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application
{
    public class WarehouseService : IWarehouseService
    { 
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IValidator<PostWarehouseDTO> _postValidator;
        private readonly IValidator<Warehouse> _warehouseValidator;
        private readonly IMapper _mapper;

        public WarehouseService(
        IWarehouseRepository repository,
        IValidator<PostWarehouseDTO> postValidator,
        IValidator<Warehouse> warehouseValidator,
        IMapper mapper)
        {
            _mapper = mapper;
            _postValidator = postValidator;
            _warehouseValidator = warehouseValidator;
            _warehouseRepository = repository;
        }
        public List<Warehouse> GetAllWarehouse()
        {
            return _warehouseRepository.GetAllWarehouses();
        }

        public Warehouse GetWarehouseById(int id)
        {
            return _warehouseRepository.GetWarehouseById(id);
        }
        public Warehouse CreateNewWarehouse(PostWarehouseDTO dto)
        {
            var validation = _postValidator.Validate(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.ToString());

            return _warehouseRepository.CreateNewWarehouse(_mapper.Map<Warehouse>(dto));
        }
        public Warehouse UpdateWarehouse(int id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
                throw new ValidationException("ID in body and route are different");
            var validation = _warehouseValidator.Validate(warehouse);
            if (!validation.IsValid)
                throw new ValidationException(validation.ToString());
            return _warehouseRepository.UpdateWarehouse(warehouse);
        }
        public Warehouse DeleteWarehouse(int id)
        {
            return _warehouseRepository.DeleteWarehouse(id);
        }

       
    }
}
