
using PhotoSharing.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul003_MVCModel.Repository
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments(int PhotoId);

      
       
    }

}
