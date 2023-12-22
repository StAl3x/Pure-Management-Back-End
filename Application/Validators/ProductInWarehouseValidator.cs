using Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators;

public class PostProductInWarehouseValidator : AbstractValidator<PostProductInWarehouseDTO>
{
    public PostProductInWarehouseValidator()
    {
        RuleFor(pin => pin.WarehouseId).NotEmpty();
        RuleFor(pin => pin.ProductId).NotEmpty();
        RuleFor(pin => pin.Quantity).GreaterThan(0);
    }
}

public class PutProductInWarehouseValidator : AbstractValidator<PutProductInWarehouseDTO>
{
    public PutProductInWarehouseValidator()
    {
        RuleFor(pin => pin.Quantity).GreaterThan(0);
    }
}
