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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.CarId == 0 && rental.CustomerId == 0 && rental.RentDate.Hour > 22)
            {
                return new ErrorResult(Messages.RentNotAdded);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<Rental>> ShowAllAvailable(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.CarsListed);
            }
            return new ErrorDataResult<List<Rental>>(Messages.CannotBeListed);
        }

        public IDataResult<List<Rental>> ShowAllRented(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.CarsListed);
            }
            return new ErrorDataResult<List<Rental>>(Messages.CannotBeListed);
        }

        public IResult Update(Rental rental)
        {
            int id = new int();
            id = int.Parse(Console.ReadLine());
            if (rental.Id == id)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentUpdated);
            }
            return new ErrorResult(Messages.CarIdInvalid);
        }
    }
}
