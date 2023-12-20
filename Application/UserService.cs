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

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IValidator<PostUserDTO> _postValidator;
    private readonly IValidator<PutUserDTO> _putValidator;
    private readonly IMapper _mapper;


    public UserService(
        IUserRepository repository,
        IValidator<PostUserDTO> postValidator,
        IValidator<PutUserDTO> putValidator,
        IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _postValidator = postValidator ?? throw new ArgumentNullException(nameof(_postValidator));
        _putValidator = putValidator ?? throw new ArgumentNullException(nameof(putValidator));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public List<User> GetAll()
    {
        return _repository.GetAll();
    }

    public User GetById(int id)
    {
        return _repository.GetById(id);
    }
    public User Create(PostUserDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        User user = _mapper.Map<User>(dto);
        return _repository.Create(user);
    }

    public User Update(int id, PutUserDTO dto)
    {
        var validation = _putValidator.Validate(dto);
        if(!validation.IsValid)
            throw new ValidationException(validation.ToString());
        User user = _mapper.Map<User>(dto);
        user.Id = id;
        return _repository.Update(user);
    }

    public User Delete(int id)
    {
        return _repository.Delete(id);
    }

    public bool VerifyUserPassword(string UserName, string password)
    {
        return _repository.VerifyUserPassword(UserName, password);
    }
}
