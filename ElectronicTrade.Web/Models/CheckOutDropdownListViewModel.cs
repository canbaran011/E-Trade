using ElectronicTrade.Entities.EntityEnums.DropdownListTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicTrade.Web.Models
{
    public class CheckOutDropdownListViewModel
    {
        public CountryName SelectedCountry { get; set; }
        public StateName SelectedState { get; set; }

        //public SelectList SelectedCountry { get; set; }
        //public SelectList SelectedState { get; set; }
    }
}