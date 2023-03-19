using FluentValidation;
using IXORA.PlatonovNikita.TestShop.Dto.ProductDto;

namespace IXORA.PlatonovNikita.TestShop.Validators.ProductValidators
{
    public class AddProductTypeValidator :AbstractValidator<AddProductTypeData>
    {
        public AddProductTypeValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.NameOfType).Null().NotEmpty()
                                             .WithMessage("Name of produc type can't be empty!");
        }
    }
}
