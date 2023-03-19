using FluentValidation.Results;
using IXORA.PlatonovNikita.TestShop.Validators.ProductValidators;
using System;

namespace IXORA.PlatonovNikita.TestShop.Dto.ProductDto
{
    public class AddProductData
    {
        private readonly AddProductDataValidator _validator = new AddProductDataValidator();

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Guid ProductTypeId { get; set; }

        public ValidationResult ValidateThis()
        {
            return _validator.Validate(this);
        }
    }
}
