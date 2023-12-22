using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<PostProductDTO> _postProductValidator;
    private readonly IValidator<PutProductDTO> _putProductValidator;
    private readonly IMapper _mapper;


    public ProductService(
        IProductRepository repository,
        IValidator<PostProductDTO> postValidator,
        IValidator<PutProductDTO> putProductValidator,
        IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _postProductValidator = postValidator ?? throw new ArgumentNullException(nameof(_postProductValidator));
        _putProductValidator = putProductValidator ?? throw new ArgumentNullException(nameof(putProductValidator));
        _productRepository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public Product CreateNewProduct(ProductModel model)
    {
        PostProductDTO dto = model.postProductDTO ?? throw new NullReferenceException();
        int userId = model.userId;
        var validation = _postProductValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        Product product = _mapper.Map<Product>(dto);
        product.PricePerUnit = Math.Round(product.PricePerUnit, 2);
        return _productRepository.CreateNewProduct(product, userId);
    }

    public Product GetProductById(int id)
    {
        Product product = _productRepository.GetProductById(id);
        product.PricePerUnit = Math.Round(product.PricePerUnit, 2);
        return product;
    }

    public Product UpdateProduct(int id, ProductModel model)
    {
        PutProductDTO dto = model.putProductDTO ?? throw new NullReferenceException();
        int userId = model.userId;
        var validation = _putProductValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        Product product = _mapper.Map<Product>(dto);
        product.Id = id;
        product.PricePerUnit = Math.Round(product.PricePerUnit, 2);
        return _productRepository.UpdateProduct(product, userId);
    }

    public Product DeleteProduct(int id, int userId)
    {
        return _productRepository.DeleteProduct(id, userId);
    }
}