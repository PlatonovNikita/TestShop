using IXORA.PlatonovNikita.TestShop.Validators.ClientValidators;
using FluentValidation.Results;

namespace IXORA.PlatonovNikita.TestShop.Dto.ClientDto
{
    public class AddClientData
    {
        private readonly AddClientDataValidator _validator = new AddClientDataValidator();

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public ValidationResult ValidateThis()
        {
            return _validator.Validate(this);
        }
    }
}
