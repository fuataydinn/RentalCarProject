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
            CarTest();

            // BrandTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(+car.CarId + "  - " + " Araç Markası :  " + car.BrandName + " Arac rengi : " + car.ColorName + " Gunluk fiyat :" + car.DailyPerice);
                    Console.WriteLine(result.Message);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());

        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.Name);
        //    }
        //}
    }
}
