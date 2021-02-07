using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<ProductDetailDto> productDetailDtos();
        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByColorId(int id);
        void Add();
    }
}
