using Modul005_MVCViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class ViewDataSampleController : Controller
    {
        // GET: ViewDataSample
        public ActionResult Index()
        {
            IList<Student> studentList = new List<Student>();
            studentList.Add(new Student() { StudentName = "Bill" });
            studentList.Add(new Student() { StudentName = "Steve" });
            studentList.Add(new Student() { StudentName = "Ram" });

            ViewData["students"] = studentList;

            return View();
        }

        public ActionResult Index2()
        {
            



            ViewData.Add("Id", 1);

            //Zweite Initialisierung Möglichkeit
            ViewData.Add(new KeyValuePair<string, object>("Name", "Bill"));
            ViewData.Add(new KeyValuePair<string, object>("Age", 20));





            #region ViewData verwendet intern das Dictionary. 
            // Hier wird nur gezeigt, wie ein Dictionary an sich funktioniert. 
            // Vielleicht erkennst du eine parallele zu ViewData ;-)
            IDictionary<string, object> viewDataObject = new Dictionary<string, object>();
            viewDataObject.Add("students", 1);
            viewDataObject.Add("students1", "hallo");
            viewDataObject.Add(new KeyValuePair<string, object>("UnterrichtsBegin", DateTime.Now));

            //Einfacher Beispiel für einen 
            foreach (KeyValuePair<string, object> currentEntry in viewDataObject)
            {
                string currentKey = currentEntry.Key;
                string currentValue = currentEntry.Key;
            }
            #endregion



            return View();
        }

        public ActionResult Index3()
        {
            ViewBag.Id = 1; //Intern ruft die ViewBag diesen Methode auf ViewData.Add("Id", 1);

            //Das bedeutet an dieser Stelle, dass es einen runtime Fehler gibt, weil der Key schon vergeben ist. 
            ViewData.Add("Id", 1); // throw runtime exception as it already has "Id" key
            ViewData.Add(new KeyValuePair<string, object>("Name", "Bill"));
            ViewData.Add(new KeyValuePair<string, object>("Age", 20));

            return View();
        }

    }
}