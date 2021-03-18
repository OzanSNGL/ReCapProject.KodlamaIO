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
using Microsoft.Extensions.Hosting;
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
        IHostEnvironment _hostEnvironment;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService, IHostEnvironment hostEnvironment)
        {
            _carImageDal = carImageDal;
            _carService = carService;
            _hostEnvironment = hostEnvironment;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            //var result = BusinessRules.Run(CheckImageCount(carImage.CarId), IfImgExists(file));
            //var imagetype = file.ContentType;
            //if (result != null)
            //{
            //    return result;
            //}

            var root = _hostEnvironment.ContentRootPath;
            var wwwroot = Path.Combine(root, "wwwroot");
            var path = Path.Combine(wwwroot, "Images");
            var fileHelper = FileHelper.WriteFile(file, path);

            if (!fileHelper.Success)
            {
                return new ErrorResult(fileHelper.Message);
            }

            carImage.ImgPath = fileHelper.Data;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult($"{Messages.ImageAdded}: {carImage.ImgPath}");
        }

        [SecuredOperation("carimage.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var root = _hostEnvironment.ContentRootPath;
            var wwwroot = Path.Combine(root, "wwwroot");
            var sourcePath = $"{wwwroot}{_carImageDal.Get(ci => ci.Id == carImage.Id).ImgPath}";
            var fileHelper = FileHelper.Delete(sourcePath);

            if (!fileHelper.Success)
            {
                return new ErrorResult(fileHelper.Message);
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(), true);
        }

        [SecuredOperation("carimage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckImageCount(carImage.CarId), IfImgExists(file));

            if (result != null)
            {
                return result;
            }

            var root = _hostEnvironment.ContentRootPath;
            var wwwroot = Path.Combine(root, "wwwroot");
            var path = Path.Combine(wwwroot, "Images");
            var sourcePath = $"{wwwroot}{_carImageDal.Get(ci => ci.Id == carImage.Id).ImgPath}";
            var fileHelper = FileHelper.Update(sourcePath, file, path);

            if (!fileHelper.Success)
            {
                return new ErrorResult(fileHelper.Message);
            }

            carImage.ImgPath = fileHelper.Data;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.ImageUpdated);
        }

        public IDataResult<List<CarImage>> Get(int carId)
        {        
            var result =_carImageDal.GetAll(p => p.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(result);
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

        private IResult IfImgExists(IFormFile formFile)
        {
            var result = formFile.ContentType.ToString().StartsWith("image");
            if (!result)
            {
                return new ErrorResult(Messages.ImageNotAdded);
            }
            return new SuccessResult();
        }
    }
}
