using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=5, DailyPrice=205, ModelYear=2012, Description="Volkswagen Polo, Benzin" },
                new Car{CarId=2, BrandId=1, ColorId=1, DailyPrice=400, ModelYear=2016, Description="Volkswagen Passat, Dizel" },
                new Car{CarId=3, BrandId=2, ColorId=4, DailyPrice=355, ModelYear=2019, Description="Renault Symbol, Benzin" },
                new Car{CarId=4, BrandId=3, ColorId=1, DailyPrice=610, ModelYear=2020, Description="BMW 5, Benzin" },
                new Car{CarId=5, BrandId=3, ColorId=5, DailyPrice=585, ModelYear=2020, Description="BMW 1, Benzin" },
                new Car{CarId=6, BrandId=4, ColorId=1, DailyPrice=195, ModelYear=2006, Description="Fiat Marea, Benzin" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
