using Modul005_MVCViews.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            int zahlDesTages = (int)System.Web.HttpContext.Current.Session["ZahlDesTages"];
            Person mitarbeiterDesTages = (Person)System.Web.HttpContext.Current.Session["MitarbeiterDesMonats"];

            ViewBag.Message = "Your application description page.";

            return View();
        }



        [Route("Mvctest")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ReadSessionSample()
        {
            string json = System.Web.HttpContext.Current.Session["PersonObj"].ToString();
            Person person = JsonConvert.DeserializeObject<Person>(json);
            return View();
        }
    }
}