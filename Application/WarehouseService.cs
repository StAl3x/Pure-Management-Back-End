using Domain.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
using Domain.Models;


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
        private readonly IValidator<PostUserInWarehouseDTO> _postUIWValidator;
        private readonly IValidator<PutUserInWarehouseDTO> _putUIWValidator;
        private readonly IValidator<PostProductDTOWithQuantity> _postProductWithQuantityValidator;
        private readonly IValidator<PutProductDTOWithQuantity> _putProductWithQuantityValidator;
        private readonly IMapper _mapper;

        public WarehouseService(
        IWarehouseRepository repository,
        IValidator<PostWarehouseDTO> postValidator,
        IValidator<PutWarehouseDTO> putWarehouseValidator,
        IValidator<PostProductDTO> postProductValidator,
        IValidator<PutProductDTO> putProductValidator,
        IValidator<PostProductInWarehouseDTO> postPINValidator,
        IValidator<PutProductInWarehouseDTO> putPINValidator,
        IValidator<PostUserInWarehouseDTO> postUIWValidator,
        IValidator<PutUserInWarehouseDTO> putUIWValidator,
        IValidator<PostProductDTOWithQuantity> postProductWithQuantityValidator,
        IValidator<PutProductDTOWithQuantity> putProductWithQuantityValidator,
        IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postWarehouseValidator = postValidator ?? throw new ArgumentNullException(nameof(_postWarehouseValidator));
            _putWarehouseValidator = putWarehouseValidator ?? throw new ArgumentNullException(nameof(_putWarehouseValidator));
            _postProductValidator = postProductValidator ?? throw new ArgumentNullException(nameof(_postProductValidator));
            _putProductValidator = putProductValidator ?? throw new ArgumentNullException(nameof(_putProductValidator));
            _postPINValidator = postPINValidator ?? throw new ArgumentNullException(nameof(_postPINValidator));
            _putPINValidator = putPINValidator ?? throw new ArgumentNullException(nameof(_putPINValidator));
            _postUIWValidator = postUIWValidator ?? throw new ArgumentNullException(nameof(_postUIWValidator));
            _putUIWValidator = putUIWValidator ?? throw new ArgumentNullException(nameof(_putUIWValidator));
            _postProductWithQuantityValidator = postProductWithQuantityValidator ?? throw new ArgumentNullException(nameof(_postProductWithQuantityValidator));
            _putProductWithQuantityValidator = putProductWithQuantityValidator ?? throw new ArgumentNullException(nameof(_putProductWithQuantityValidator));


            _warehouseRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Warehouse Create(WarehouseModel model)
        {
            PostWarehouseDTO dto = model.postWarehouseDTO ?? throw new NullReferenceException();
            int userId = model.userId;
            var validation = _postWarehouseValidator.Validate(dto);
            if (!validation.IsValid)
                throw new ValidationException(validation.ToString());
            return _warehouseRepository.Create(_mapper.Map<Warehouse>(dto), userId);
        }

        public Warehouse Delete(int id, int userId)
        {
            return _warehouseRepository.Delete(id, userId);
        }

        public List<Warehouse> GetAll(int userId)
        {
            return _warehouseRepository.GetAll(userId);
        }

        public Warehouse GetById(int id)
        {
            return _warehouseRepository.GetById(id);
        }
        public Warehouse Update(int id, WarehouseModel model)
        {
            PutWarehouseDTO dto = model.putWarehouseDTO ?? throw new NullReferenceException();
            int userId = model.userId;
            var validation = _putWarehouseValidator.Validate(dto);
            if(!validation.IsValid)
                throw new ValidationException(validation.ToString());
            Warehouse warehouse = _mapper.Map<Warehouse>(dto);
            warehouse.Id = id;
            return _warehouseRepository.Update(warehouse, userId);
        }

        public List<Product> GetProducts(int warehouseId)
        {
            return _warehouseRepository.GetProducts(warehouseId);
        }

        public Product CreateProduct(int warehouseId, ProductModel model)
        {
            PostProductDTOWithQuantity dto = model.postProductDTOWithQuantity ?? throw new NullReferenceException();
            int userId = model.userId;
            var productValidation = _postProductWithQuantityValidator.Validate(dto);
            if (!productValidation.IsValid)
                throw new ValidationException(productValidation.ToString());
            return _warehouseRepository.CreateProduct(warehouseId, _mapper.Map<Product>(dto), userId);
        }

        public Product UpdateProduct(int warehouseId, ProductModel model)
        {
            PutProductDTOWithQuantity dto = model.putProductDTOWithQuantity ?? throw new NullReferenceException();
            int userId = model.userId;
            
            var productValidation = _putProductWithQuantityValidator.Validate(dto);
            if (!productValidation.IsValid)
                throw new ValidationException(productValidation.ToString());
            return _warehouseRepository.UpdateProduct(warehouseId, _mapper.Map<Product>(dto), userId);
        }

        public Product DeleteProduct(int warehouseId, DeleteProductFromWarehouseModel model)
        {
            int productId = model.productId;
            int userId = model.userId;
            bool deleteFromProductTable = model.deleteFromProductTable;
            return _warehouseRepository.DeleteProduct(warehouseId, productId, deleteFromProductTable,userId);
        }

        public Product AddProduct(PostProductInWarehouseDTO pinDTO, int userId)
        {
            var validation = _postPINValidator.Validate(pinDTO);
            if(!validation.IsValid)
                throw new ValidationException(validation.ToString());
            return _warehouseRepository.AddProduct(_mapper.Map<ProductInWarehouse>(pinDTO), userId);
        }

        public List<User> GetUsers(int warehouseId)
        {
            return _warehouseRepository.GetUsers(warehouseId);
        }

        public User AddUser(PostUserInWarehouseDTO uiwDTO, int requestedUserId)
        {
            var validation = _postUIWValidator.Validate(uiwDTO);
            if(!validation.IsValid)
                    throw new ValidationException(validation.ToString());
            return _warehouseRepository.AddUser(_mapper.Map<UserInWarehouse>(uiwDTO), requestedUserId);
        }

        public User RemoveUser(int warehouseId, int userId)
        {
            return _warehouseRepository.RemoveUser(warehouseId, userId);
        }

        public User UpdateUserAccessLevel(PutUserInWarehouseDTO uiwDTO, int userId)
        {
            var validation = _putUIWValidator.Validate(uiwDTO);
            if(!validation.IsValid)
                throw new ValidationException(validation.ToString());
            return _warehouseRepository.UpdateUserAccesLevel(_mapper.Map<UserInWarehouse>(uiwDTO), userId);
        }
    }
}
