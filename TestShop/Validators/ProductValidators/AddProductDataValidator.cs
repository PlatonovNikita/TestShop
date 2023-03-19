using FluentValidation;
using IXORA.PlatonovNikita.TestShop.Dto.ProductDto;
using System;

namespace IXORA.PlatonovNikita.TestShop.Validators.ProductValidators
{
    public class AddProductDataValidator : AbstractValidator<AddProductData>
    {
        public AddProductDataValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotNull().NotEmpty()
                                .WithMessage("Name can't be empty!");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(decimal.Zero)
                                 .WithMessage("Price must be positive!")
                                 .LessThanOrEqualTo(decimal.MaxValue)
                                 .WithMessage($"Price must be less then {decimal.MaxValue}!");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0)
                                    .WithMessage("Quantity must be non negative")
                                    .LessThanOrEqualTo(int.MaxValue)
                                    .WithMessage($"Quantity must be less than {int.MaxValue}");
            RuleFor(x => x.ProductTypeId).NotNull()
                                         .NotEqual(Guid.Empty)
                                         .WithMessage("Product type id can't be empty!");

        }
    }
}
