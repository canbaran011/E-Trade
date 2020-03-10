﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicTrade.Entities.ViewModels.ComplexViewModel
{
    public class CheckoutViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool ShippingAddressAsBillAddress { get; set; }
        public bool SaveInformation { get; set; }
        public string PaymenType { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public string PromotionCode { get; set; }
    }
}
