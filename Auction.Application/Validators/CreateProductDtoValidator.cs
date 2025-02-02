using Auction.Domain.Entities;
using FluentValidation;

namespace Auction.Application.Validators;

public class CreateProductDtoValidator : AbstractValidator<Product>
{
    public CreateProductDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 20)
            .WithMessage("Name should be between 3 to 20 characters");

        RuleFor(dto => dto.Description)
            .Length(3, 200)
            .WithMessage("Description should be between 3 to 200 characters");
    }
}
