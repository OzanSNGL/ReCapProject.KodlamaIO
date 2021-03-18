using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<ProductDetailDto>> GetCarDetails(int carId);
        IDataResult<List<ProductDetailDto>> GetAllCarDetails(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IResult Add(Car car);
        IResult Update(Car car);
    }
}
