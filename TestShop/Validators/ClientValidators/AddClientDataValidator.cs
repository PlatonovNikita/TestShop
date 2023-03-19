using FluentValidation;
using IXORA.PlatonovNikita.TestShop.Dto.ClientDto;

namespace IXORA.PlatonovNikita.TestShop.Validators.ClientValidators
{
    public class AddClientDataValidator : AbstractValidator<AddClientData>
    {
        public AddClientDataValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FullName).NotNull().NotEmpty()
                                    .WithMessage("Full name of client can't be empty!");
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty()
                                       .WithMessage("Phone number of client can't be empty!")
                                       .Matches("^[+]{0,1}[1-9]{0,1}[0-9]{7,10}$")
                                       .WithMessage("It isn't a phone number!");
        }
    }
}
