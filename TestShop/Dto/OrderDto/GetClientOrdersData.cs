using IXORA.PlatonovNikita.TestShop.Validators.OrderValidators;
using System;
using FluentValidation.Results;

namespace IXORA.PlatonovNikita.TestShop.Dto.OrderDto
{
    public class GetClientOrdersData
    {
        private readonly GetClientOrdersDataValidator _validator 
            = new GetClientOrdersDataValidator();

        public Guid? ClientId { get; set; }
        
        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public Pagination Pagination { get; set; }

        public ValidationResult ValidateThis()
        {
            return _validator.Validate(this);
        }
    }
}
