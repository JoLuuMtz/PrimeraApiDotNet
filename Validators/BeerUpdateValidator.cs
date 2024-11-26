using FluentValidation;
using Mi_primera_api_dotnet.DTOs;

namespace Mi_primera_api_dotnet.Validators
{
    public class BeerUpdateValidator : AbstractValidator<UpdateBeerDTO>
    {

        public BeerUpdateValidator()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo")
                .NotEmpty()
                .WithMessage("El nombre no puede estar vacío")
                .MaximumLength(50)
                .WithMessage("El nombre no puede tener más de 50 caracteres");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("La descripción no puede ser nula")
                .NotEmpty()
                .WithMessage("La descripción no puede estar vacía")
                .MaximumLength(200)
                .WithMessage("La descripción no puede tener más de 200 caracteres");

        
        }

    }
}
