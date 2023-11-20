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

        return _productRepository.CreateNewProduct(_mapper.Map<Product>(dto));
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void RebuildDB()
    {
        _productRepository.RebuildDB();
    }

    public Product UpdateProduct(int id, PutProductDTO dto)
    {
       
        var validation = _putProductValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        Product product = _mapper.Map<Product>(dto);
        product.Id = id;
        return _productRepository.UpdateProduct(product);
    }

    public Product DeleteProduct(int id)
    {
        return _productRepository.DeleteProduct(id);
    }
}