using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdPay.Models;

namespace ProdPay.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var models = new ProductOperations ();
            
            return View(models.LoadProducts());
        }

        // GET: /Home/Create

        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(ProductModel vm)
        {
            try
            {
                var actionModel = new ProductOperations();
                actionModel.Create(vm);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(new ProductModel());
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            ProductModel actionModel = new ProductOperations().Find(id);
            return View(actionModel);
        }


        [HttpPost]
        public ActionResult Edit(ProductModel editModel)
        {
            try
            {
                var actionModel = new ProductOperations();
                actionModel.Edit(editModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new ProductModel());
            }
        }

        public ActionResult Details(int id)
        {
            ProductModel actionModel = new ProductOperations().Find(id);
            return View(actionModel);
        }

    }
}