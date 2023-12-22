using Domain.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

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

    public List<User> GetAll(int userId)
    {
        return _repository.GetAll(userId);
    }

    public User GetById(int id)
    {
        return _repository.GetById(id);
    }
    public User Create(UserModel model)
    {
        PostUserDTO dto = model.postUserDTO ?? throw new NullReferenceException();
        int userId = model.userId;
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        User user = _mapper.Map<User>(dto);
        return _repository.Create(user,userId);
    }

    public User Update(int id, UserModel model)
    {
        PutUserDTO dto = model.putUserDTO ?? throw new NullReferenceException();
        int userId = model.userId;
        var validation = _putValidator.Validate(dto);
        if(!validation.IsValid)
            throw new ValidationException(validation.ToString());
        User user = _mapper.Map<User>(dto);
        user.Id = id;
        return _repository.Update(user, userId);
    }

    public User Delete(int id, int userId)
    {
        return _repository.Delete(id, userId);
    }

    public bool VerifyUserPassword(string UserName, string password)
    {
        return _repository.VerifyUserPassword(UserName, password);
    }
}
