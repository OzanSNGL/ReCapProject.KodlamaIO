using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(), true, Messages.CarsListed);
        }

        public IDataResult<Color> GetAllById(int colorId)
        {
            if (colorId < 1)
            {
                return new ErrorDataResult<Color>(Messages.ColorIdInvalid);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(p=>p.ColorId == colorId), Messages.CarsListed);
        }
    }
}
