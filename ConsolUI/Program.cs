using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            // BrandTest();

            CarAddAndList();

        }
        static void CarAddAndList()
        {
            Car car1 = new Car() { BrandId = 9, ColorId = 99, ModelYear = 2023, DailyPrice = 1453, Description = "Deneme" };
            Car car2 = new Car() { BrandId = 5, ColorId = 88, ModelYear = 2008, DailyPrice = 15, Description = "26 / 10 / 2022 ikinci kayıt" };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            carManager.Add(car2);

            Console.WriteLine("****************  Sisteme Kayıtlı Bütün Araçlar Listeleniyor **********************");

            IDataResult<List<Car>> carList = carManager.GetAll();
            foreach (Car car in carList.Data)
            {
                Console.WriteLine("Araç ID:" + car.Id + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
            }
            Console.WriteLine(carList.Message);


            Console.WriteLine("****************  Sisteme Kayıtlı Araçlar Detaylarıyla Listeleniyor **********************");
            IDataResult<List<CarDetailDto>> carDetailList = carManager.GetCarDetails();

            foreach (var carDetail in carDetailList.Data)
            {
                Console.WriteLine("Car Name: {0}, Brand Name: {1}, Color Name: {2}, DailyPrice: {3}", carDetail.CarName, carDetail.BrandName, carDetail.ColorName, Convert.ToInt32(carDetail.DailyPrice));
            }
            Console.WriteLine(carDetailList.Message);
        }

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var result = carManager.GetCarDetails();
        //    if (result.Success==true)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(car.CarId + "  - " + " Araç Markası :  " + car.BrandName + " Arac rengi : " + car.ColorName + " Gunluk fiyat :" + car.DailyPerice);
        //            Console.WriteLine(result.Message);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }

        //}

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
