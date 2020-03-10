using ElectronicTrade.BusinessLayer.OperationManagers;
using ElectronicTrade.Entities.ViewModels.EntityViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ElectronicTrade.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductManager mngr_product = new ProductManager();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = mngr_product.Find(x => x.Id ==id);
            
            if (product==null)
            {
                return HttpNotFound();
            }

            ProductViewModel vm_product = new ProductViewModel();
            vm_product.product = product;

            return View(vm_product);
        }
    }
}