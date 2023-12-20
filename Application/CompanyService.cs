using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly IValidator<PostCompanyDTO> _postValidator;
    private readonly IValidator<PutCompanyDTO> _putValidator;
    private readonly IMapper _mapper;


    public CompanyService(
        ICompanyRepository repository,
        IValidator<PostCompanyDTO> postValidator,
        IValidator<PutCompanyDTO> putValidator,
        IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _postValidator = postValidator ?? throw new ArgumentNullException(nameof(_postValidator));
        _putValidator = putValidator ?? throw new ArgumentNullException(nameof(putValidator));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public Company Create(PostCompanyDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        Company company = _mapper.Map<Company>(dto);
        return _repository.Create(company);
    }

    public Company Delete(int id)
    {
        return _repository.Delete(id);
    }

    public List<Company> GetAll()
    {
        return _repository.GetAll();
    }

    public Company GetById(int id)
    {
        return _repository.GetById(id);
    }

    public List<Product> GetProducts(int companyId)
    {
        return _repository.GetProducts(companyId);
    }

    public List<User> GetUsers(int companyId)
    {
        return _repository.GetUsers(companyId);
    }

    public List<Warehouse> GetWarehouses(int companyId)
    {
        return _repository.GetWarehouses(companyId);
    }

    public Company Update(int id, PutCompanyDTO dto)
    {
        var validation = _putValidator.Validate(dto);
        if(!validation.IsValid)
            throw new ValidationException(validation.ToString());
        Company company = _mapper.Map<Company>(dto);
        company.Id = id;
        return _repository.Update(company);

    }
}
