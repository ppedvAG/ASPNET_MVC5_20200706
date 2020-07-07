
using PhotoSharing.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.DataAccessLayer.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private PhotoSharingDB ctx = new PhotoSharingDB();

        public void Delete(int Id)
        {
            Photo photoToDelete = ctx.Photos.SingleOrDefault(n => n.PhotoID == Id);

            ctx.Photos.Remove(photoToDelete);
            ctx.SaveChanges();
        }

        public IList<Photo> GetAll()
        {
            return ctx.Photos.ToList();
        }

        public Photo GetFirstPhoto()
        {
            return ctx.Photos.First();
            //return ctx.Photos.ToList().First();
        }

        public Photo GetPhotoById(int id)
        {
            return ctx.Photos.SingleOrDefault(o => o.PhotoID == id);
        }

        public Photo GetPhotoByTitle(string title)
        {
            return ctx.Photos.Single(n => n.Title == title);
        }

        public void InsertPhoto(Photo photo)
        {
            //Datensatz wird gespeichert. Minimalistischer Code
            ctx.Photos.Add(photo);
            ctx.SaveChanges();
        }

        public void Update(Photo modifiedPhoto)
        {
            ctx.Entry<Photo>(modifiedPhoto).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();

        }
    }
}
