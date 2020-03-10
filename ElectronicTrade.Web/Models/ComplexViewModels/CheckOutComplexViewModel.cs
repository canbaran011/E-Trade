using ElectronicTrade.Entities.ViewModels.ComplexViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicTrade.Web.Models.ComplexViewModels
{
    public class CheckOutComplexViewModel
    {
        public CheckoutViewModel checkout { get; set; }
        public CheckOutDropdownListViewModel dropdownlist { get; set; }
    }
}