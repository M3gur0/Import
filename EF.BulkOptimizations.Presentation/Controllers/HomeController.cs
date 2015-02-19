using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.BulkOptimizations.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Dashboard()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}