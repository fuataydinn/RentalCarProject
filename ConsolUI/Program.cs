using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId=1,ColorId=2,DailyPrice=350,Description="Bmw"});
            //carManager.Add(new Car { BrandId=2,ColorId=2,DailyPrice=400,Description="Audi"});

            carManager.Update(new Car {Id=1, ModelYear=2015 });


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
