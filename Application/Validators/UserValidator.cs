using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators;

public class PostUserValidator : AbstractValidator<PostUserDTO>
{
    public PostUserValidator()
    {
        RuleFor(u => u.Name).NotEmpty();
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.CompanyId).NotNull();
        RuleFor(u => u.Password).NotEmpty();
    }
}

public class PutUserValidator : AbstractValidator<PutUserDTO>
{
    public PutUserValidator()
    {

        RuleFor(u => u.Name).NotEmpty();
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.CompanyId).NotNull();
        RuleFor(u => u.Password).NotEmpty();
    }
}
