using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class PostProductValidator : AbstractValidator<PostProductDTO>
{
    public PostProductValidator()
    {
        RuleFor(p => p.PricePerUnit).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Unit).NotEmpty();
    }
}

public class PutProductValidator : AbstractValidator<PutProductDTO>
{ 
   public PutProductValidator()
    {
        
        RuleFor(p => p.PricePerUnit).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Unit).NotEmpty();
    }
}

public class PostProductValidatorWithQuantity : AbstractValidator<PostProductDTOWithQuantity>
{
    public PostProductValidatorWithQuantity()
    {
        RuleFor(p => p.PricePerUnit).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Unit).NotEmpty();
        RuleFor(p => p.Quantity).NotEmpty().GreaterThan(0);
    }
}


public class PutProductValidatorWithQuantity : AbstractValidator<PutProductDTOWithQuantity>
{
    public PutProductValidatorWithQuantity()
    {
        RuleFor(p => p.Id);
        RuleFor(p => p.PricePerUnit).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Unit).NotEmpty();
        RuleFor(p => p.Quantity).NotEmpty().GreaterThan(0);
    }
}