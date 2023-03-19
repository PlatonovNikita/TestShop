using IXORA.PlatonovNikita.TestShop.Validators.OrderValidators;
using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace IXORA.PlatonovNikita.TestShop.Dto.OrderDto
{
    public class CreateOrderData
    {
        private readonly CreateOrderDataValidator _validator = new CreateOrderDataValidator();

        public Guid ClientId { get; set; }

        public List<CreateOrderLineData> OrderLines { get; set; }

        public ValidationResult ValidateThis()
        {
            return _validator.Validate(this);
        }
    }

    public class CreateOrderLineData
    {
        public Guid ProductId { get; set; }

        public int ProductQuantity { get; set; }
    }
}
