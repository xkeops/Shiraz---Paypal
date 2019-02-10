using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdPay.Models;

namespace ProdPay.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var models = new ProductOperations();

            return View(models.LoadProducts());
        }
        [HttpGet]
        public ActionResult Index1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Purchase p)
        {
            if (ModelState.IsValid)
            {
                if (Session["cart"] != null)
                {
                    var ls = Session["cart"] as List<Purchase>;
                    ls.Add(p);
                }
                else
                {
                    Session["cart"] = new List<Purchase>() { p };
                }
                ModelState.Clear();// clear data from Form
                RedirectToAction("Index", "Home"); // Anti F5 submit
            }
            return View(); // model validate is false
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