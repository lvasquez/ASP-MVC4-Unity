
namespace Mvc4Demo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using Mvc4Demo.Services;
    using Mvc4Demo.Models;
    using DataModel;


    public class KendoCategoriesController : Controller
    {
        private ICategoriesServices service;

        public KendoCategoriesController(ICategoriesServices service) {

            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {         
            return Json(this.service.GetAll().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add([DataSourceRequest] DataSourceRequest request, CategoriesViewModel categories)
        {
            var newcategory = this.service.Add(categories);
            return Json(new[] { newcategory }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoriesViewModel categories)
        {

            this.service.Update(categories);
            return Json(ModelState.ToDataSourceResult());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoriesViewModel categories)
        {
            var id = categories.CategoryID;
            this.service.Delete(id);
            return Json(ModelState.ToDataSourceResult());
        }

    }
}
