using Modul003_MVCModel.Models;
using Modul003_MVCModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul003_MVCModel.Controllers
{
    public class CommentarController : Controller
    {
        ICommentRepository commentRepository = new CommentRepository(); 
        
        public ActionResult DisplayCommentsForPhoto(int PhotoID) 
        { 
            // Use the repository to get the comments 
            ICollection<Comment> comments = commentRepository.GetComments(PhotoID); 
            return View("DisplayComments", comments); }
    }
}