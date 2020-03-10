using ElectronicTrade.BusinessLayer.OperationManagers;
using ElectronicTrade.BusinessLayer.TestingManagers;
using ElectronicTrade.Entities;
using ElectronicTrade.Entities.ViewModels.EntityViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicTrade.Web.Controllers
{
    public class HomeController : Controller
    {
        ProductManager mngr_product = new ProductManager();
        CategoryManager mngr_category = new CategoryManager();

        [HttpGet]
        public ActionResult Index()
        {
            Testing ts = new Testing();
            ts.DatabaseTestMethod();


            return View();
        }

        [HttpGet]
        public PartialViewResult HomeProduct()
        {
            var products = mngr_product.ListQueryable().Include("category").Include("productImages").OrderByDescending(x => x.AddedDate).ToList();

            ProductViewModel vm_product = new ProductViewModel();
            vm_product.products = products;
           
            return PartialView("_PartialHomePageProduct", vm_product);
        }

        [HttpGet]
        public PartialViewResult HomeCategory()
        {
            var category = mngr_category.List();

            CategoryViewModel vm_category = new CategoryViewModel();
            vm_category.categories = category;

            return PartialView("_PartialInfiniteCategory",vm_category);
        }      


    }
}