using FluentValidation;
using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL.Helpers.ClientHelpers
{
    internal class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Client name is required.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email address.");
            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Country is required.");
            RuleFor(x => x.Region)
                .NotEmpty()
                .WithMessage("Region is required.");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required.");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required.");
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .WithMessage("Postal code is required.")
                .Matches(@"^\d{5}(?:[-\s]\d{4})?$")
                .WithMessage("Invalid postal code.");
        }
    }
}
