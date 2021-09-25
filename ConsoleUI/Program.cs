using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
            Car car1 = new Car();
            car1.Id = 3;
            car1.DailyPrice = 10;
            car1.ColorId = 2;
            car1.BrandId = 1;
            car1.Description = "Renault";
            car1.ModelYear = 1995;
            //Car car2 = new Car();
            //car2.Id = 3;
            //car2.DailyPrice = 0;
            //car2.ColorId = 2;
            //car2.BrandId = 1;
            //car2.Description = "Old car 1994";
            //car2.ModelYear = 1994;
            EFCarDal a = new EFCarDal();
            //a.Add(car2);
            a.Add(car1);
            foreach (var car in carManager.GetByColorId(2))
            {
                Console.WriteLine(car.Description);
            }


        }
    }
}
