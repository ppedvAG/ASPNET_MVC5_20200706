using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharing.DataAccessLayer.Entities
{
    // Vorbereitung für Entity Framework (CodeFirst) in MVC5 
    public class Photo
    {

        public int PhotoID { get; set; }

        //Auto Property  -> die Variable title wird zur Laufzeit hinzugefügt
        public string Title { get; set; }

        [DisplayName("Picture")] //Display - DataAnnotation
        public byte[] PhotoFile { get; set; }


        private string desciption;


        [DataType(DataType.MultilineText)] //UI zeigt anstatt eine einfache TextBox eine Multitextbox an. 
        public string Description
        {
            get
            {
                //weitere logik reinschreiben....z.b Culture/Internationalisieung
                return desciption;
            }

            set
            {
                //Du kannst Validierungslogik einbauen 
                desciption = value;
            }
        }

        //DisplayName = Alias Name -> Bei einer Tabelle von Photos, wird der Spaltename vom PropertyName abgeleitet. 
        // Damit man benutzerfreudliche Name erlangt, verwendet man DisplayName("")
        
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public string Owner { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}