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
           
        public ProductDetailController()
        {
            var businessLogic = new BusinessLogic.BusinessLogic();
            _product = businessLogic.GetProductBL();
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