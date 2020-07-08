using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class DynamicViewSampleController : Controller
    {
        // GET: DynamicViewSample
        public ActionResult Index()
        {
            dynamic expando = new ExpandoObject();

            expando.abc = "ABC Unterricht";
            expando.def = "DEF Nachmittagsunterricht";


            return View(expando);
        }
    }
}