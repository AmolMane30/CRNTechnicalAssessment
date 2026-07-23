using CRNTechnicalAssessment.Application.DTOs.Product;
using FluentValidation;

namespace CRNTechnicalAssessment.Application.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100);
    }
}