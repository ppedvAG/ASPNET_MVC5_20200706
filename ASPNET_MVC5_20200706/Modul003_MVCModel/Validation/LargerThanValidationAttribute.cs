using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modul003_MVCModel.Validation
{
    //Custom validator 

    //[AttributeUsage(AttributeTargets.Field)]
    [AttributeUsage(AttributeTargets.Property)]
    public class LargerThanValidationAttribute : ValidationAttribute
    {
        public int MinimumValue { get; set; }


        //ctor + tab + tab -> erstellen eines Konstruktors
        public LargerThanValidationAttribute(int minimum)
        {
            MinimumValue = minimum;
        }

        //Virtuelle Methode wird überschrieben
        public override bool IsValid(object value)
        {
            int valueToCompare = (int)value;

            if (valueToCompare > MinimumValue)
                return true;
            else return false;
        }

    }
}