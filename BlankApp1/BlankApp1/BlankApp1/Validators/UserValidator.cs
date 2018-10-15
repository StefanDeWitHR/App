using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using FluentValidation;

namespace Core.Validators
{
    public class UserValidator :AbstractValidator<Users>
    {

        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().NotNull().WithMessage("Voornaam is een verplicht veld");
            RuleFor(user => user.LastName).NotEmpty().NotNull().WithMessage("Achternaam is een verplicht veld");
            RuleFor(user => user.Gender).NotEmpty().NotNull().WithMessage("Geslacht is een verplicht veld");
            RuleFor(user => user.Email).EmailAddress().NotEmpty().NotNull().WithMessage("Email is een verplicht veld");
            RuleFor(user => user.CompanyName).NotEmpty().NotNull().WithMessage("Bedrijfsnaam is een verplicht veld");
            RuleFor(user => user.PhoneNumber).NotEmpty().NotNull().WithMessage("Telefoonnummer is een verplicht veld");
        }
    }
}
