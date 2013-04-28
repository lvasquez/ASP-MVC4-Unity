namespace Mvc4Demo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Mvc4Demo.Services;
    using Mvc4Demo.Models;

    public class CategoriesController : Controller
    {

        private ICategoriesServices service;

        public CategoriesController(ICategoriesServices service) {

            this.service = service;
        }

        public ActionResult Index()
        {
            return View(this.service.GetAll());
        }

        public ActionResult Create()
        { 
            return View(new CategoriesViewModel());
        }

        [HttpPost]
        public ActionResult Create(CategoriesViewModel categories)
        {
            this.service.Add(categories);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(this.service.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(CategoriesViewModel categories)
        {
            this.service.Update(categories);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(this.service.Get(id));
        }

        
        public ActionResult Delete(int id = 0)
        {
            return View(this.service.Get(id));
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
