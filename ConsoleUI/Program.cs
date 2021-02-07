using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            GetAll(carManager);

            Console.WriteLine("----------");

            GetByBrandId(carManager);

            Console.WriteLine("----------");

            GetByColorId(carManager);
        }

        private static void GetByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetAllByColorId(2))
            {
                Console.WriteLine("Car Name: {0}  |  Daily Price: {1}   ", car.CarName, car.DailyPrice);
            }
        }

        private static void GetByBrandId(CarManager carManager)
        {
            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine("Car Name: {0}  |  Daily Price: {1}   ", car.CarName, car.DailyPrice);
            }
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.productDetailDtos())
            {
                Console.WriteLine("Car Name: {0}  |  Brand: {1}  |  Color: {2}  |  Daily Price: {3}TL", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
