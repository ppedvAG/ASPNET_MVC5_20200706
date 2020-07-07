using PhotoSharing.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.DataAccessLayer.Repositories
{
    public interface IPhotoRepository
    {
        IList<Photo> GetAll();

        Photo GetFirstPhoto();

        void InsertPhoto(Photo photo);

        Photo GetPhotoByTitle(string title);

        Photo GetPhotoById(int id);


        void Update(Photo modifiedPhoto);


        void Delete(int Id);
    }
}
