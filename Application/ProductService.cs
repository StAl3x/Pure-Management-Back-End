using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<PostProductDTO> _postValidator;
    private readonly IValidator<PutProductDTO> _putProductValidator;
    private readonly IMapper _mapper;


    public ProductService(
        IProductRepository repository,
        IValidator<PostProductDTO> postValidator,
        IValidator<PutProductDTO> putProductValidator,
        IMapper mapper)
    {
        _mapper = mapper;
        _postValidator = postValidator;
        _putProductValidator = putProductValidator;
        _productRepository = repository;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public Product CreateNewProduct(PostProductDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        Product product = _mapper.Map<Product>(dto);
        product.PricePerUnit = Math.Round(product.PricePerUnit, 2);
        return _productRepository.CreateNewProduct(product);
    }

    public Product GetProductById(int id)
    {
        Product product = _productRepository.GetProductById(id);
        product.PricePerUnit = Math.Round(product.PricePerUnit, 2);
        return product;
    }

    public Product UpdateProduct(int id, PutProductDTO dto)
    {
       
        var validation = _putProductValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        Product product = _mapper.Map<Product>(dto);
        product.Id = id;
        product.PricePerUnit = Math.Round(product.PricePerUnit, 2);
        return _productRepository.UpdateProduct(product);
    }

    public Product DeleteProduct(int id)
    {
        return _productRepository.DeleteProduct(id);
    }
}