using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var products = new List<Product>
            //{
            //    new Product { ProductId = 1, Name = "Product 1", Price = 10 },
            //    new Product { ProductId = 2, Name = "Product 2", Price = 20 },
            //    new Product { ProductId = 3, Name = "Product 3", Price = 30 }
            //};

            return View( );
     
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}