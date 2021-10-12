using Business.Abstract;
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
            if (rental.ReturnDate!=null)
            {
                _rentalDal.Updated(rental);
                return new SuccessResult("Rental added!");
            }
            _rentalDal.Updated(rental);
            return new ErrorResult("The car is already rented!");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Rental deleted!");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Updated(rental);
            return new SuccessResult("Rental updated!");
        }
    }
}
