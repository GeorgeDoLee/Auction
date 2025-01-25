using Auction.Application.Dtos;
using FluentValidation;

namespace Auction.Application.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(dto => dto.UserId)
            .NotEmpty()
            .WithMessage("User id is required.");

        RuleFor(dto => dto.Name)
            .Length(3, 20);

        RuleFor(dto => dto.Description)
            .Length(3, 200);
    }
}
