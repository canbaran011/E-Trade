using ElectronicTrade.Entities.ViewModels.VirtualViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.BusinessLayer.ValidationRules.FluentValidation.VirtualViewModel
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(3, 12);

            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Surname).Length(3, 12);

            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).Length(3, 15);

            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).Length(5, 25);

            RuleFor(x => x.Password).NotEmpty();
            //RuleFor(x => x.Password).Equal(x => x.PasswordConfirmation);
            RuleFor(x => x.Password).Length(8, 12);
            RuleFor(x => x.Password).Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\\da-zA-Z])(.{8,12})$").WithMessage("Minimum 8 Max 12 characters atleast 1 Alphabet, 1 Number and 1 Special Character and avoid space");

            RuleFor(x => x.PasswordConfirmation).NotEmpty();
            RuleFor(x => x.PasswordConfirmation).Equal(x => x.Password);
            RuleFor(x => x.PasswordConfirmation).Length(8, 12);
            RuleFor(x => x.PasswordConfirmation).Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\\da-zA-Z])(.{8,12})$").WithMessage("Minimum 8 Max 12 characters atleast 1 Alphabet, 1 Number and 1 Special Character and avoid space");

            RuleFor(x => x.TermsAndCondition).Must(x => x.Equals(true)).WithMessage("Please accept Terms of Condition.");
        }
    }
}
