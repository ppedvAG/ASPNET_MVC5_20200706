using Modul004_MVCController.Filter;
using PhotoSharing.DataAccessLayer.Entities;
using PhotoSharing.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul004_MVCController.Controllers
{
    public class PhotoController : Controller
    {

        IPhotoRepository repo = new PhotoRepository();

        // GET: Photo

        [SimpleActionFilter]
        public ActionResult Index()
        {
            IList<Photo> allPhotos = repo.GetAll();

            ViewBag.HariboVariable = "Haribo macht Zähne kaputt";
            ViewData["Milka"] = "Milkaschokolade macht auch die Zähne kaputt";
            
            TempData["Scholler"] = "Eis essen ist gesund!";
            return View(allPhotos);
        }


        [Authorize(Roles = "Admins")] //->ActionFilter -> Authorize -> Nur Admins dürfen diese Methode aufrufen
        public ActionResult First()
        {
            string tempVariable = string.Empty;
            string viewDataVariable = string.Empty;

            if (TempData.ContainsKey("Scholler"))
                tempVariable = TempData["Scholler"].ToString();

            if (ViewData.ContainsKey("Milka"))
                viewDataVariable = ViewData["Milka"].ToString();


            Photo firstPhoto = repo.GetFirstPhoto();

            if (firstPhoto == null)
            {
                return HttpNotFound();
            }
            return View(firstPhoto);
        }


        public ActionResult FileContenResultReturnValueSample()
        {
            //return new FileContentResult() -> Wichtig!!! FileContentResult wird bei binären Formaten verwendet (Bild, MP3, Datei)

            return View();
        }


        //Get - Methode
        public ActionResult Create()
        {
            Photo newPhoto = new Photo();

            newPhoto.CreatedDate = DateTime.Now;

            string tempVariable = string.Empty ;
            string viewDataVariable = string.Empty;

            
            if (TempData.ContainsKey("Scholler"))
                tempVariable = TempData["Scholler"].ToString();

            if (ViewData.ContainsKey("Milka"))
                viewDataVariable = ViewData["Milka"].ToString();


            return View(newPhoto); //View ist der selbe Name, wie die Action-Methode Create
            //return View("Create", newPhoto); -> Explizierter Aufruf der View
        }


        [HttpPost]
        public ActionResult Create(Photo photo) //Photo wird via Default Model-Binding befüllt -> Alternatives Beispiel siehe Modul003-> ModelBinding
        {
            


            if (ModelState.IsValid)
            {
                //Speichere Foto in die DB
                repo.InsertPhoto(photo);
                return RedirectToAction("Index", "Photo");
            }
            else
            {
                return View("Create", photo);
            }
        }



        public ActionResult Edit (int? id)
        {
            if (id.HasValue == false)
                return HttpNotFound();
        
            Photo photo = repo.GetPhotoById(id.Value);

            return View(photo);
        }

        public ActionResult Edit (Photo photo)
        {
            repo.Update(photo);
            return RedirectToAction("Index");
        }


        public ActionResult GetPhotobyTitle(string title)
        {
            Photo photo = repo.GetPhotoByTitle(title);


            if (photo == null)
                return HttpNotFound();

            //return View("First", photo);
            return View("Details", photo);

        }


        #region Show-Beispiel -> wie flexibel kann ich Action-Methoden aufrufen
        //Valide Calls: https://localhost:44313/Photo/GetPhotoById/1
        //Valider Calls mit QueryString Parameter -> https://localhost:44313/Photo/GetPhotoById?Id=1
        //                                           https://localhost:44313/Photo/GetPhotoById?ID=1
        public ActionResult GetPhotoById(int Id)
        {
            return View();
        }

        //https://localhost:44313/Photo/GetPhotoByIdAndName?title=abc&id=3
        public ActionResult GetPhotoByIdAndName(int Id, string title)
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }
        #endregion

    }
}