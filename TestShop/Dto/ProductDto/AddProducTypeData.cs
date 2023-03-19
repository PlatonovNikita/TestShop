using IXORA.PlatonovNikita.TestShop.Validators.ProductValidators;
using FluentValidation.Results;

namespace IXORA.PlatonovNikita.TestShop.Dto.ProductDto
{
    public class AddProductTypeData
    {
        private readonly AddProductTypeValidator _validator = new AddProductTypeValidator();

        public string NameOfType { get; set; }

        public ValidationResult ValidatrThis()
        {
            return _validator.Validate(this);
        }
    }
}
