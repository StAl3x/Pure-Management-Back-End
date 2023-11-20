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