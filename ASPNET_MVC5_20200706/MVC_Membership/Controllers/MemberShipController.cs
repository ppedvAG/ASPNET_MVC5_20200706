using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Membership.Controllers
{
    [Authorize(Roles = "Admin,SuperUser,StandardUser")]
    
    public class MemberShipController : Controller
    {
        // GET: MemberShip
        public ActionResult Index()
        {
            return View();
        }
    }
}