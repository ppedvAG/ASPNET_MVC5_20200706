using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul005_MVCViews.Controllers
{
    public class TempDataController : Controller
    {
        // GET: TempData
        public ActionResult Index()
        {
            #region Sample1
            TempData["name"] = "Test data";
            TempData["age"] = 30;
            #endregion

            return View();
        }

        public ActionResult Index2()
        {
            #region Sample1
            string userName;
            int userAge;

            userName = TempData["name"].ToString();
            userAge = int.Parse(TempData["age"].ToString());

            if (TempData.ContainsKey("name"))
                userName = TempData["name"].ToString();

            if (TempData.ContainsKey("age"))
                userAge = int.Parse(TempData["age"].ToString());
            #endregion


            //TempData.Keep(); //TempData.Keep erhält dir die Daten für einen weiteren Request...z.b Index3
            return View();
        }

        public ActionResult Index3()
        {
            #region Sample1
            string userName;
            int userAge;

            if (TempData.ContainsKey("name"))
                userName = TempData["name"].ToString();

            if (TempData.ContainsKey("age"))
                userAge = int.Parse(TempData["age"].ToString());
            #endregion

            return View();
        }
    }
}