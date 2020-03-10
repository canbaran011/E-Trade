﻿using ElectronicTrade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicTrade.Entities.ViewModels.EntityViewModel
{
    public class ProductViewModel
    {
        public List<Product> products { get; set; }
        public Product product { get; set; }
    }
}