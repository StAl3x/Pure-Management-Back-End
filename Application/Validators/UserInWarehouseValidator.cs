using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators;

public class PostUserInWarehouseValidator : AbstractValidator<PostUserInWarehouseDTO>
{
    public PostUserInWarehouseValidator()
    {
        RuleFor(uiw => uiw.WarehouseId).NotEmpty();
        RuleFor(uiw => uiw.UserId).NotEmpty();
        RuleFor(uiw => uiw.AccessLevel).GreaterThan(0).NotNull();
    }
}

public class PutUserInWarehouseValidator : AbstractValidator<PutUserInWarehouseDTO>
{
    public PutUserInWarehouseValidator()
    {
        RuleFor(uiw => uiw.AccessLevel).GreaterThan(0).NotNull();
    }
}

