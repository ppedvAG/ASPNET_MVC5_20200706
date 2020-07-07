using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace Modul003_MVCModel.Models
{
    // Entity Framework = O/R Mapper - ORM
    public class PhotoSharingDB : DbContext    
    {
        public PhotoSharingDB()
        {

        }

        //Für eine Benutzerdefinierte Datenbankanbindung, kann einen Connectionstring verwenden (siehe Beispiel)
        //PhotoSharingDB()
        //    : base("Data Source = localhost\\MySQLServer; Initial Catalog=PhotoSharingDB")
        //{

        //}

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}