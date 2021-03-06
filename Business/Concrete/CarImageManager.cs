using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [SecuredOperation("carimage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageCount(carImage.CarId), IfImgExists(carImage));
            if (result != null)
            {
                return result;
            }
            carImage.ImgPath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        [SecuredOperation("carimage.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll(int carId)
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId), true);
        }

        [SecuredOperation("carimage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            carImage.ImgPath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImgPath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        public IDataResult<CarImage> Get(int carId)
        {

            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == carId));
        }

        //RULES

        public IResult CheckImageCount(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.MaxImageCount);
            }
            return new SuccessResult();
        }

        string defaultPath = Environment.CurrentDirectory + "@/Images/CarImages/default.jpg";
        private IResult IfImgExists(CarImage carImage)
        {
            if (carImage.ImgPath == null)
            {
                carImage.ImgPath.Replace(carImage.ImgPath, defaultPath);
                return new SuccessResult();
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
