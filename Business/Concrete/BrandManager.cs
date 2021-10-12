using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Updated(brand);
            return new SuccessResult("Brand has been added!");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Brand has been deleted!");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
             return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId==brandId));
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult("Brand has been updated!");
        }
    }
}
