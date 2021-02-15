using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Car carToAdd = new Car { CarId = 8, BrandId = 1, CarName = "BMW 2", ColorId = 2, DailyPrice = 330, ModelYear = 2016, Description = null };
            Car carToUpdate = new Car();
            Rental rentToAdd = new Rental { Id = 6, CarId = 7, CustomerId = 2, RentDate = new DateTime(12 / 02 / 2021), ReturnDate = new DateTime() };
            Rental rentToUpdate = new Rental { ReturnDate = new DateTime(15 / 02 / 2021) };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(carToUpdate);

            Console.WriteLine("------------");

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Update(rentToUpdate);

        }
    }
}
