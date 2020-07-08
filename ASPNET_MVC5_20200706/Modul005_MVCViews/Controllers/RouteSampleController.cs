using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class RouteSampleController : Controller
    {
        // GET: RouteSample
        public ActionResult Index(DateTime entryDate)
        {
            //artikelliste simmuliert ein Ergebnis aus der DB
            List<Artikel> artikelliste = new List<Artikel>();
            artikelliste.Add(new Artikel { ID = 1, Name = "Text a", PublishDate = new DateTime(2009, 12, 5) });
            artikelliste.Add(new Artikel { ID = 1, Name = "Text a", PublishDate = new DateTime(2011, 07, 5) });
            artikelliste.Add(new Artikel { ID = 1, Name = "Text a", PublishDate = new DateTime(2011, 2, 5) });
            artikelliste.Add(new Artikel { ID = 1, Name = "Text a", PublishDate = new DateTime(2012, 07, 5) });

            List<Artikel> resultList = artikelliste.Where(n => n.PublishDate.Date == entryDate.Date).ToList();


            return View(resultList);
        }


       
        public ActionResult Index2 ()
        {
            return View();
        }
    }

    public class Artikel
    {
        public int ID;
        public string Name;
        public DateTime PublishDate;
    }
}