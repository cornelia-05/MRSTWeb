using BusinessLogic;
using MRSTWeb.BusinessLogic;
using MRSTWeb.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSTWeb.Controllers
{
     public class ProductDetailController : Controller
     {
          private readonly IProduct _product;
          private readonly ISession _session;

          public ProductDetailController()
          {
            var _bl = new MRSTWeb.BusinessLogic.Interfaces.BusinessLogic();
            _product = _bl.GetProductApi();
               _session = _bl.GetSessionApi();
          }

          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          public ActionResult GetProduct(int id)
          {
               var product = _product.GetById(id);
               if (product == null)
                    return HttpNotFound("product not found");

               return View(product);
          }
     }

}