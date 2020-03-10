using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicTrade.Entities.ViewModels.VirtualViewModel
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public bool TermsAndCondition { get; set; }
    }
}