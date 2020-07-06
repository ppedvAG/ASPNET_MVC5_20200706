using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Modul003_MVCModel.Models
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingDB>
    {
        protected override void Seed(PhotoSharingDB context)
        {
            var photos = new List<Photo>
            {
                new Photo
                {
                    Title = "My First Foto",
                    Description = "This is a part of the sample data",
                    Owner = "Fred",
                    CreatedDate = DateTime.Today
                },
                new Photo
                {
                    Title="My Second Photo",
                    Description = "This is part of the sample data",
                    Owner = "Sue",
                    CreatedDate = DateTime.Today
                }
            };

            //Kurzschreibe für = photos.ForEach(s => context.Photos.Add(s)); 

            foreach (Photo photoToAdd in photos)
            {
                context.Photos.Add(photoToAdd);
            }

            context.SaveChanges();


            
        }
    }
}