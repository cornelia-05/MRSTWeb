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
        private  IProduct _product;
           
        public ProductDetailController()
        {
               var logic = new LogicProvider();
            _product = logic.GetProductBL();
            var session = logic.GetsessionBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetProduct(int id)
        {
            var product = _product.GetDetailProduct(id);
            if (product == null)
            {
                return HttpNotFound("product not found");
            }
        
            return View(product);
        }
    }
}