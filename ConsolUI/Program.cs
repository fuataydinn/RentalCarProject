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
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine( + car.CarId+ "  - " + " Araç Markası :  "+ car.BrandName+ " Arac rengi : "+ car.ColorName+" Gunluk fiyat :"+ car.DailyPerice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
    }
}
