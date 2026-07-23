using CRNTechnicalAssessment.Application.DTOs.Product;
using FluentValidation;

namespace CRNTechnicalAssessment.Application.Validators;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .MaximumLength(100);
    }
}