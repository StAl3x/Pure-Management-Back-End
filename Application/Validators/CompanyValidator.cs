using Domain.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class PostCompanyValidator : AbstractValidator<PostCompanyDTO>
{
    public PostCompanyValidator()
    {
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}

public class PutCompanyValidator : AbstractValidator<PutCompanyDTO>
{
    public PutCompanyValidator()
    {

        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}