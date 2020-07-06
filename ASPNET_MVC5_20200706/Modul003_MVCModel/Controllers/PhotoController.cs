using Modul003_MVCModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul003_MVCModel.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoSharingDB db = new PhotoSharingDB();
        // GET: Photo
        //public ActionResult Index()
        //{
        //    //Objekt Foto wurde deklariert -> Photo photo;
        //    //und initializiert photo = new Photo();
        //    Photo photo = new Photo();

        //    photo.Title = "Landschaftsbild";
        //    photo.Description = "Sonnenaufgang";
        //    photo.Owner = User.Identity.Name; // User.Identity.Name; des aktuell angemeldeten Benutzers
        //    photo.CreatedDate = DateTime.Today; //DateTime.Now(Mit Uhrzeit) oder DateTime.NowUtc (Uhrzeit mit Zeitzonen)


        //    return View(photo);
        //}


        public ActionResult Index()
        {
            //Lese alle Datensätze aus der Tabelle Photos
            return View(db.Photos.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Photo photo = db.Photos.Find(id);

            if (photo == null)
            {
                return HttpNotFound();
            }

            return View("Details", photo);
        }
    }
}