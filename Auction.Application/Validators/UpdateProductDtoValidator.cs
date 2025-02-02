using Auction.Application.Dtos;
using Auction.Domain.Entities;
using FluentValidation;

namespace Auction.Application.Validators;

public class UpdateProductDtoValidator : AbstractValidator<Product>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 20)
            .When(dto => !string.IsNullOrEmpty(dto.Name))
            .WithMessage("Name should be between 3 to 20 characters.");

        RuleFor(dto => dto.Description)
            .Length(3, 200)
            .When(dto => !string.IsNullOrEmpty(dto.Description))
            .WithMessage("Description should be between 3 to 200 characters.");
    }
}