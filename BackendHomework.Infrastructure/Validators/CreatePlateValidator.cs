using BackendHomework.Core.DTOs;
using FluentValidation;

namespace BackendHomework.Infrastructure.Validators
{
    public class CreatePlateValidator :AbstractValidator<CreatePlateDTO>
    {
        public CreatePlateValidator()
        {
            RuleFor(p => p.Price)
               .NotNull()
               .GreaterThan(0)
               .LessThan(100000);
            RuleFor(p => p.Name)
              .Length(1, 50)
              .NotNull();
            RuleFor(p => p.Description)
           .Length(0, 200);
        }
    }
}
