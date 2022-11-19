//using DataAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace DataAccess.Concrete.InMemory
//{
//    public class InMemoryCarDal : ICarDal
//    {
//        List<Car> _cars;
//        public InMemoryCarDal()
//        {
//            _cars = new List<Car> 
//            {
//                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=500,ModelYear=2020,Description="Bmw"},
//                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=500,ModelYear=2022,Description="Audi"},
//                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=250,ModelYear=2022,Description="Renault"},
//                new Car{Id=4,BrandId=2,ColorId=3,DailyPrice=250,ModelYear=2021,Description="Citroen"},
//                new Car{Id=5,BrandId=3,ColorId=4,DailyPrice=350,ModelYear=2020,Description="Golf"},
//                new Car{Id=6,BrandId=3,ColorId=1,DailyPrice=300,ModelYear=2021,Description="Seat"}
//            };
//        }
//        public void Add(Car car)
//        {
//            _cars.Add(car);
//        }

//        public void Delete(Car car)
//        {
//            Car deletedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
//            _cars.Remove(deletedCar);
//        }

//        public List<Car> GetAll()
//        {
//            return _cars;
//        }

//        public void Update(Car car)
//        {
//            Car updatedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
//            updatedCar.ColorId = car.ColorId;
//            updatedCar.DailyPrice = car.DailyPrice;
//            updatedCar.Description = car.Description;
//            updatedCar.ModelYear = car.ModelYear;
//            updatedCar.BrandId = car.BrandId;
//        }
//    }
//}
