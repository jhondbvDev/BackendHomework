using BackendHomework.Core.DTOs;
using FluentValidation;

namespace BackendHomework.Infrastructure.Validators
{
    public class EditPlateValidator : AbstractValidator<PlateDTO>
    {
        public EditPlateValidator()
        {
            RuleFor(p => p.Id)
               .NotNull();
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
