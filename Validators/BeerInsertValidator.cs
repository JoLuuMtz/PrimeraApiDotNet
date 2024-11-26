using System;
using System.Text.RegularExpressions;
using FluentValidation;
using Mi_primera_api_dotnet.DTOs;

namespace Mi_primera_api_dotnet.Validators
{
    public class BeerInsertValidator : AbstractValidator<CreatedBeerDTO>
    {

        public BeerInsertValidator()

        {
            // calida que el nombre de la cerveza no sea nullo ni este vacio 
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("is Empty");

            //RuleFor(x => x.Name)
            //    .Must(LetraA)
            //    .WithMessage("El nombre de la cerveza debe contener la letra 'a' o 'A'");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("is Empty");

            RuleFor(x => x.Description)
                .Length(1,50)
                .WithMessage("La {PropertyName} debe tener al menos 10 caracteres");

            //RuleFor( x => x.Password)
            //    .Must(PasswordValid)
            //    .WithMessage("La contraseña debe tener al menos" +
            //    " 8 caracteres, una mayúscula, una minúscula, un número " +
            //    "y un caracter especial");

        }
        // metodo que valida de forma personalizada
        // que el nombre de la cerveza contenga la letra 'a' o 'A'
        public bool LetraA(string name)
        {
            return name.Contains("a") || name.Contains("A");
        }
        public bool PasswordValid(string password)
        {
            string validPassword = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$\r\n ";

          return Regex.IsMatch(password, validPassword);
        }
    }

}
