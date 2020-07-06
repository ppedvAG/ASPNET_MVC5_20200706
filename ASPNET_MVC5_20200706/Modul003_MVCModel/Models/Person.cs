using Modul003_MVCModel.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modul003_MVCModel.Models
{
    public class Person
    {
        public int PersonID { get; set; }


        //Name muss ein MUSS-Feld in der DB sein, genauso wird Name im Formular auch als MUSS Feld dargestellt (es muss ausgefüllt werden -> ModelBinding)

        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(100)] //in der DB wird ein nvarchar(100) / varchar(100) 
        public string Name { get; set; }

        [Range(0, 400)]
        public int Height { get; set; }

        //[Range(0, 300.5)]
        //public decimal A { get; set; }


        [Required]
        [RegularExpression(".+\\@.+\\..+")]
        //[DataType(DataType.EmailAddress)] Alternative Schreibweise
        public string Email { get; set; }

        //[LargerThanValidation(18)]
        //public int VoterAge { get; set; }

    }
}