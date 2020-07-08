using Modul005_MVCViews.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {

            Person person = new Person();
            person.Vorname = "Max";
            person.Name = "Mustermann";



            #region Beispiel 1
            System.Web.HttpContext.Current.Session.Timeout = 1000000;

            if (System.Web.HttpContext.Current.Session["ZahlDesTages"] == null)
                System.Web.HttpContext.Current.Session.Add("ZahlDesTages", 7);
            else
                System.Web.HttpContext.Current.Session["ZahlDesTages"] = 9;

            System.Web.HttpContext.Current.Session.Add("MitarbeiterDesMonats", person);
            #endregion

            #region beispiel 2

            string json = JsonConvert.SerializeObject(person);
            System.Web.HttpContext.Current.Session.Add("PersonObj", json);

            #endregion
            return View();
        }

        
    }
}