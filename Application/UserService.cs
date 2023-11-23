using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
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
}
