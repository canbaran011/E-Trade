using ElectronicTrade.Entities.ViewModels.VirtualViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.BusinessLayer.ValidationRules.FluentValidation.VirtualViewModel
{
    public class LoginViewModelValidator:AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(8,12);
            RuleFor(x => x.Password).Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\\da-zA-Z])(.{8,12})$").WithMessage("Minimum 8 Max 12 characters atleast 1 Alphabet, 1 Number and 1 Special Character and avoid space");

            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).Length(5,25);
         
        }
    }
}
