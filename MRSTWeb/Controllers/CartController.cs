using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MRSTWeb.BusinessLogic.Interfaces; 
using MRSTWeb.Models;

namespace MRSTWeb.Controllers
{
     public class CartController : Controller
     {
          private const string CartSessionKey = "Cart";
          private readonly IProduct _productService;

          public CartController(IProduct productService)
          {
               _productService = productService;
          }

          private List<CartItem> GetCart()
          {
               if (Session[CartSessionKey] == null)
                    Session[CartSessionKey] = new List<CartItem>();

               return (List<CartItem>)Session[CartSessionKey];
          }

          public ActionResult Index()
          {
               var cart = GetCart();
               return View(cart);
          }

          public ActionResult AddToCart(int id)
          {
               var product = _productService.GetById(id);
               if (product == null)
                    return HttpNotFound();

               var cart = GetCart();
               var existing = cart.FirstOrDefault(c => c.Product.Id == id);

               if (existing != null)
                    existing.Quantity++;
               else
                    cart.Add(new CartItem { Product = product, Quantity = 1 });

               return RedirectToAction("Products", "Home", new { added = product.Name });
          }

          public ActionResult Remove(int id)
          {
               var cart = GetCart();
               var item = cart.FirstOrDefault(c => c.Product.Id == id);
               if (item != null) cart.Remove(item);
               return RedirectToAction("Index");
          }

          public ActionResult Clear()
          {
               Session[CartSessionKey] = new List<CartItem>();
               return RedirectToAction("Index");
          }

          public ActionResult Checkout()
          {
               var cart = GetCart();
               return View(cart);
          }

          [HttpPost]
          public ActionResult ConfirmOrder()
          {
               Session[CartSessionKey] = null;
               return RedirectToAction("ThankYou");
          }

          public ActionResult ThankYou()
          {
               return View();
          }
     }
}
