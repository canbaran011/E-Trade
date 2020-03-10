using ElectronicTrade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicTrade.Web.UIOperations.CartOperations
{
    public class Cart
    {
        private List<CartLine> _cartlines = new List<CartLine>();

        public List<CartLine> CartLines
        {
            get { return _cartlines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            //Does the incoming product object exist in the _cardlines List?
            var line = _cartlines.FirstOrDefault(x => x.Product.Id == product.Id);

            //If this product object is not in the cardlines List, it is added to the list
            if (line == null)
            {
                _cartlines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else //If there is this product object in the _cardlines list, only the Quantity value is increased.
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product, int quantity, int status) //Deletes the desired product object from _cardlines the list
        {
            var line = _cartlines.FirstOrDefault(x => x.Product.Id == product.Id);

            if (status == 0)
            {

                _cartlines.RemoveAll(x => x.Product.Id == product.Id);


            }
            else if (status == 1)
            {
                if (quantity > 1)
                {
                    line.Quantity -= 1;

                }
                else
                {
                    _cartlines.RemoveAll(x => x.Product.Id == product.Id);
                }
            }
        }

        public double Total() //Calculates and returns the total value of products.
        {
            return (double)_cartlines.Sum(x => x.Product.Price * x.Quantity);
        }


        public void Clear() //Deletes all products from the _cardlines list
        {
            _cartlines.Clear();
        }
    }
}