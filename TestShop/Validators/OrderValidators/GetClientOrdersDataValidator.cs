using FluentValidation;
using IXORA.PlatonovNikita.TestShop.Dto.OrderDto;
using System;

namespace IXORA.PlatonovNikita.TestShop.Validators.OrderValidators
{
    public class GetClientOrdersDataValidator : AbstractValidator<GetClientOrdersData>
    {
        public GetClientOrdersDataValidator()
        {
            RuleFor(x => x.ClientId).NotEqual(Guid.Empty)
                                    .WithMessage("Client id can't be empty!");
            RuleFor(x => x.DateTo).Must(dt => !dt.HasValue || dt.Value <= DateTime.Now)
                                  .WithMessage("'Date to' can't be in the future!");
            RuleFor(x => x.DateFrom).Must((x, dt) => !dt.HasValue || !x.DateTo.HasValue || dt.Value <= x.DateTo.Value)
                                    .WithMessage("'Date from' can't be last than 'date to'!")
                                    .Must(dt => !dt.HasValue || dt.Value <= DateTime.Now)
                                    .WithMessage("'Date from' can't be in the future!");
        }
    }
}
