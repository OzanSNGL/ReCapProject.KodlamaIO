using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            if (id < 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarIdInvalid);
            }
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), true, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            if (id < 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.ColorIdInvalid);
            }
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), true, Messages.CarsListed);
        }

        public IDataResult<List<ProductDetailDto>> productDetailDtos()
        {
            return new DataResult<List<ProductDetailDto>>(_carDal.GetProductDetails(), true, Messages.CarDetailsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
