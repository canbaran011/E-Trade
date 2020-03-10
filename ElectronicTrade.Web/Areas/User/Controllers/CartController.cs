using ElectronicTrade.BusinessLayer.OperationManagers;
using ElectronicTrade.Web.Models.ComplexViewModels;
using ElectronicTrade.Web.UIOperations.CartOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ElectronicTrade.Web.Areas.User.Controllers
{
    public class CartController : Controller
    {
        ProductManager mngr_product = new ProductManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialCart()
        {

            return PartialView("_PartialCart", GetCart());
        }

        public PartialViewResult Summary()
        {
            return PartialView("_PartialCartSummary", GetCart());
        }

        public PartialViewResult CheckOutCart()
        {
            return PartialView("_PartialCheckoutCart", GetCart());
        }

        public ActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = mngr_product.Find(x => x.Id == id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("PartialCart");
        }

        public ActionResult RemoveFromCart(int? id, int quantity, int status)
        {
            var product = mngr_product.Find(x => x.Id == id);

            if (product != null)
            {
                GetCart().DeleteProduct(product, quantity, status);
            }

            return RedirectToAction("PartialCart");
        }

        public ActionResult ClearAllCard()
        {
            GetCart().Clear();

            return RedirectToAction("PartialCart");
        }

        [HttpGet]
        public ActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(CheckOutComplexViewModel model)
        {
            var cart = GetCart();
            if (cart.CartLines.Count==0)
            {
                ModelState.AddModelError("CartIsEmpty", "Your chart is empty!");
            }
            else
            {
                
            }

            return View();
        }
        public Cart GetCart()
        {
            var cart = Session["Cart"] as Cart;

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }     

    }
}