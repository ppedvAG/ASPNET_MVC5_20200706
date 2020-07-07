using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Schlechtes Beispiel
            CarService carService = new CarService();
            carService.Einparken(new Car());
            #endregion



            //CarService2 bietet eine Teilansicht, von ICarService -> Methode Einparken 
            ICarService carService2 = new CarService2();
            carService2.Einparken(new CarMock());



            ICarService carTestService = new CarService2();
            carTestService.Einparken(new Car2() );
            bool healthy = carTestService.WirdHygieneEingehalten;
        }
    }

    #region Schlechtes Beispiel
    //BusienessObjekt.dll
    public class Rad
    {

    }

    public class Car
    {
        public string Brand { get; set; }

        public string Color { get; set; }

        public Rad AlleVierRaeder { get; set; }
    }


    // CarService.dll benötigt unbedingt die BusinessOjekt.dll -> wegen der Car Definition
    public class CarService
    {
        public void Einparken(Car car)
        {
            // macht irgendwas mit Car
            Console.WriteLine(car.Brand);
        }
    }
    #endregion


    #region Bessere Variante
   

    // BusinessObjecte Produktiv.dll
    public class Car2 : ICar
    {
        //Großes Objekt, kann viel Logik enthalten
        public string Brand { get; set; }
        public string Color { get; set; }
    }


    // CarMock -> Test.dll

    public class CarMock : ICar
    {
        public string Brand { get; set; }
        public string Color { get; set; }

        public CarMock()
        {
            Brand = "Audi";
            Color = "Rot";
        }
    }

    //Benutzerdefiniertes Objekt -> Mein.dll 

    public class MySepcialCar : ICar
    {
        public string Brand { get; set ; }
        public string Color { get; set; }
    }

    //-------------------------- Service.dll---------------------------------------
    public interface ICar
    {
        string Brand { get; set; }
        string Color { get; set; }
    }

    public interface IBikeService
    {
        void Motorrundfahrt();
    }


    public interface ICoronaHygieneKonzept
    {
        bool WirdHygieneEingehalten { get; set; }
    }

    //ICarService + ICar in einer DLL 
    public interface ICarService : ICoronaHygieneKonzept
    {
        void Einparken(ICar car);
    }

    

    public interface ITuevLizent
    {
        bool LizentGueltigBis { get; set; }

        void PruefeFahrzeug(ICar geprueftesCar);
    }

    public class CarService2 : ICarService, IBikeService
    {
        public bool WirdHygieneEingehalten { get; set; }

        public void Einparken(ICar car)
        {
            Console.WriteLine(car.Brand);
        }

        public void Motorrundfahrt()
        {
            throw new NotImplementedException();
        }
    }


    public class TestCarService : ICarService
    {
        public bool WirdHygieneEingehalten { get; set; }

        public void Einparken(ICar car)
        {
            
        }
    }
    #endregion


}
