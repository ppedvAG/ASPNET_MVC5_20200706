using PhotoSharing.DataAccessLayer;
using PhotoSharing.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modul003_MVCModel.Repository
{
    public class CommentRepository : ICommentRepository
    {
        PhotoSharingDB ctx = new PhotoSharingDB();
        public ICollection<Comment> GetComments(int PhotoId)
        {
            return ctx.Comments.Where(n => n.PhotoID == PhotoId).ToList();
        }
    }
}