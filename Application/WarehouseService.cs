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
        private readonly IValidator<PostProductDTO> _postProductValidator;
        private readonly IValidator<PutProductDTO> _putProductValidator;
        private readonly IValidator<PostProductInWarehouseDTO> _postPINValidator;
        private readonly IValidator<PutProductInWarehouseDTO> _putPINValidator;
        private readonly IMapper _mapper;

        public WarehouseService(
        IWarehouseRepository repository,
        IValidator<PostWarehouseDTO> postValidator,
        IValidator<PutWarehouseDTO> putWarehouseValidator,
        IValidator<PostProductDTO> postProductValidator,
        IValidator<PutProductDTO> putProductValidator,
        IValidator<PostProductInWarehouseDTO> postPINValidator,
        IValidator<PutProductInWarehouseDTO> putPINValidator,
        IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postWarehouseValidator = postValidator ?? throw new ArgumentNullException(nameof(_postWarehouseValidator));
            _putWarehouseValidator = putWarehouseValidator ?? throw new ArgumentNullException(nameof(_putWarehouseValidator));
            _postProductValidator = postProductValidator ?? throw new ArgumentNullException(nameof(_postProductValidator));
            _putProductValidator = putProductValidator ?? throw new ArgumentNullException(nameof(_putProductValidator));
            _postPINValidator = postPINValidator ?? throw new ArgumentNullException(nameof(_postPINValidator));
            _putPINValidator = putPINValidator ?? throw new ArgumentNullException(nameof(_putPINValidator));
            _warehouseRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Warehouse Create(PostWarehouseDTO dto)
        {
            var validation = _postWarehouseValidator.Validate(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.ToString());
            return _warehouseRepository.Create(_mapper.Map<Warehouse>(dto));
        }

        public Warehouse Delete(int id)
        {
            return _warehouseRepository.Delete(id);
        }

        public List<Warehouse> GetAll()
        {
            return _warehouseRepository.GetAll();
        }

        public Warehouse GetById(int id)
        {
            return _warehouseRepository.GetById(id);
        }
        public Warehouse Update(int id, PutWarehouseDTO dto)
        {
            var validation = _putWarehouseValidator.Validate(dto);
            if(!validation.IsValid)
                throw new ValidationException(validation.ToString());
            Warehouse warehouse = _mapper.Map<Warehouse>(dto);
            warehouse.Id = id;
            return _warehouseRepository.Update(warehouse);
        }

        public List<Product> GetProducts(int warehouseId)
        {
            return _warehouseRepository.GetProducts(warehouseId);
        }

        public Product CreateProduct(PostProductInWarehouseDTO pinDTO, PostProductDTO productDTO)
        {
            var pinValidation = _postPINValidator.Validate(pinDTO);
            var productValidation = _postProductValidator.Validate(productDTO);
            if(!pinValidation.IsValid)
                throw new ValidationException(pinValidation.ToString());
            if (!productValidation.IsValid)
                throw new ValidationException(productValidation.ToString());
            return _warehouseRepository.CreateProduct(_mapper.Map<ProductInWarehouse>(pinDTO), _mapper.Map<Product>(productDTO));
        }

        public Product UpdateProduct(PutProductInWarehouseDTO pinDTO, PutProductDTO productDTO)
        {
            var pinValidation = _putPINValidator.Validate(pinDTO);
            var productValidation = _putProductValidator.Validate(productDTO);
            if (!pinValidation.IsValid)
                throw new ValidationException(pinValidation.ToString());
            if (!productValidation.IsValid)
                throw new ValidationException(productValidation.ToString());
            return _warehouseRepository.UpdateProduct(_mapper.Map<ProductInWarehouse>(pinDTO), _mapper.Map<Product>(productDTO));
        }

        public Product DeleteProduct(int id, bool deleteFromProductTable)
        {
            return _warehouseRepository.DeleteProduct(id, deleteFromProductTable);
        }

        public Product AddProduct(PostProductInWarehouseDTO pinDTO)
        {
            var validation = _postPINValidator.Validate(pinDTO);
            if(!validation.IsValid)
                throw new ValidationException(validation.ToString());
            return _warehouseRepository.AddProduct(_mapper.Map<ProductInWarehouse>(pinDTO));
        }
    }
}
