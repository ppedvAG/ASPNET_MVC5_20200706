using Modul003_MVCModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul003_MVCModel.ModelBinder
{
    //Custom Model-Binding
    public class CarModelBinder : IModelBinder
    {
        // früher wurde hat die IModelBinder.BindModel Interface-Methode so ausgesehen-> public object BindModel (ControllerContext controllerContext, ModelBindingContext
        //bindingContext)

        //Aufpassen bei der Inface-Wahl -> using System.Web.ModelBinding (falsches Interface) !!!!!!
        //public bool BindModel(ModelBindingExecutionContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        //    {
        //        string color = modelBindingExecutionContext.HttpContext.Request.Form["color"];
        //        string brand = modelBindingExecutionContext.HttpContext.Request.Form["brand"];

        //        Car car = new Car();
        //        car.Brand = brand;
        //        car.Color = color;

        //    return true;
        //}


        /// <summary>
        /// Richtiges Interface -> System.Web.Mvc;
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string color = controllerContext.HttpContext.Request.Form["color"];
            string brand = controllerContext.HttpContext.Request.Form["brand"];

            Car car = new Car();
            car.Brand = brand;
            car.Color = color;

            return car; 
        }
    }
}