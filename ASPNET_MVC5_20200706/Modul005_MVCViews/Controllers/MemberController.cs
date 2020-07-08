using Modul005_MVCViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult PartialSample1()
        {
            return View();
        }

        public ActionResult PartialSample2()
        {
            ErdeVM vm = new ErdeVM();

            return View(vm);
        }

        public ActionResult PartialSample3()
        {
            ViewData["ErdeVM"] = new ErdeVM();
            return View();
        }

        public ActionResult OnGetMyPartial() => 
             new PartialViewResult
             {
                 ViewName = "_ShowTiere",
                 ViewData = ViewData
             };
    }
}