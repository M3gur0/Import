using Import.Business;
using Import.Business.Entities;
using Import.Presentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Import.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About() 
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(ImportModel import)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        var location = Server.MapPath("~/App_Data/") + import.File.FileName;
        //        import.File.SaveAs(location);

        //        ImportTaskServices.Add(new ImportTask() { Id = Guid.NewGuid(), Name = import.Name, Type = import.Type, FileUrl = location });
        //        ImportTaskServices.Process();
        //    }

        //    return View();
        //}
    }
}