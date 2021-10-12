using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(),"Products are listed");
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }
        public Result Add(Car car)
        {
            _carDal.Updated(car);
            return new SuccessResult("Car has been added");
        }
        public Result Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Car has been deleted");
        }
        public Result Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Car has been updated");
        }

    }
}
