using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class CachingController : Controller
    {
        // GET: Caching


        [OutputCache(Duration = 20, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }
    }
}