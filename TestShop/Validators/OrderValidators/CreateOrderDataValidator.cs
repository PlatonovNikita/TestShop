using FluentValidation;
using IXORA.PlatonovNikita.TestShop.Dto.OrderDto;
using System;

namespace IXORA.PlatonovNikita.TestShop.Validators.OrderValidators
{
    public class CreateOrderDataValidator : AbstractValidator<CreateOrderData>
    {
        public CreateOrderDataValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ClientId).NotEqual(Guid.Empty)
                                    .WithMessage("Client id can't be empty!");
            RuleFor(x => x.OrderLines).NotNull()
                                      .WithMessage("Order lines can't be null!");
            RuleForEach(x => x.OrderLines).ChildRules(validator =>
            {
                validator.RuleFor(x => x.ProductId).NotEqual(Guid.Empty)
                                             .WithMessage("Product id can't be empty!");
                validator.RuleFor(x => x.ProductQuantity).GreaterThan(0)
                                                       .WithMessage("Quantity of product must be grate than zero!");
            });
        }
    }
}
