﻿using Domain.DTOs;
using FluentValidation;
using Domain;

namespace Application.Validators;

public  class PostWarehouseValidator : AbstractValidator<PostWarehouseDTO>
{
    public PostWarehouseValidator() 
    {
        RuleFor(w => w.Address).NotEmpty();
        RuleFor(w => w.EmailAddress).NotEmpty();
        RuleFor(w => w.Name).NotEmpty();
        RuleFor(w => w.CompanyId).GreaterThan(0);
    }
}

public class PutWarehouseValidator : AbstractValidator<PutWarehouseDTO>
{ 
    public PutWarehouseValidator() 
    { 
        RuleFor(w => w.Address).NotEmpty();
        RuleFor(w => w.EmailAddress).NotEmpty();
        RuleFor(w => w.CompanyId).GreaterThan(0);
        RuleFor(w => w.Name).NotEmpty();
    }
}


