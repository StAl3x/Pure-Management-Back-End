using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;


namespace Application
{
    public class WarehouseService : IWarehouseService
    { 
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IValidator<PostWarehouseDTO> _postWarehouseValidator;
        private readonly IValidator<PutWarehouseDTO> _putWarehouseValidator;
        private readonly IMapper _mapper;

        public WarehouseService(
        IWarehouseRepository repository,
        IValidator<PostWarehouseDTO> postValidator,
        IValidator<PutWarehouseDTO> putWarehouseValidator,
        IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postWarehouseValidator = postValidator ?? throw new ArgumentNullException(nameof(_postWarehouseValidator));
            _putWarehouseValidator = putWarehouseValidator ?? throw new ArgumentNullException(nameof(_putWarehouseValidator));
            _warehouseRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Warehouse CreateNewWarehouse(PostWarehouseDTO dto)
        {
            var validation = _postWarehouseValidator.Validate(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.ToString());
            return _warehouseRepository.CreateNewWarehouse(_mapper.Map<Warehouse>(dto));
        }

        public Warehouse DeleteWarehouse(int id)
        {
            return _warehouseRepository.DeleteWarehouse(id);
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return _warehouseRepository.GetAllWarehouses();
        }

        public Warehouse GetWarehouseById(int id)
        {
            return _warehouseRepository.GetWarehouseById(id);
        }

        public Warehouse UpdateWarehouse(int id, PutWarehouseDTO dto)
        {
            var validation = _putWarehouseValidator.Validate(dto);
            if(!validation.IsValid)
                throw new ValidationException(validation.ToString());
            Warehouse warehouse = _mapper.Map<Warehouse>(dto);
            warehouse.Id = id;
            return _warehouseRepository.UpdateWarehouse(warehouse);
        }
    }
}
