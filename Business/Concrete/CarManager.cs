using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add()
        {
            string brandName = null;
        brand: Console.WriteLine("Please enter a Brand Name:");
            brandName = Console.ReadLine();
            if (brandName.Length < 2)
            {
                Console.WriteLine("Please enter more than 2 characters.");
                goto brand;
            }
            Console.WriteLine("Please enter your suggested daily price:");
            int dailyPrice = int.Parse(Console.ReadLine());
            if (dailyPrice < 1)
            {
                Console.WriteLine("Please enter a price more than 0TL");
                goto brand;
            }
            Console.WriteLine("Please enter the model year:");
            int modelYear = int.Parse(Console.ReadLine());
            Console.WriteLine("You have successfully added your car. Please wait for verification.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(p=>p.BrandId==brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(p=>p.ColorId==colorId);
        }

        public List<ProductDetailDto> productDetailDtos()
        {
            return _carDal.GetProductDetails();
        }
    }
}
