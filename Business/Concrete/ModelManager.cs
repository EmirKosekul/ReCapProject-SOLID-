using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modeldal;
        public ModelManager (IModelDal modelDal)
        {
            _modeldal = modelDal;
        }

        public Result Add(Model model)
        {
            _modeldal.Updated(model);
            return new SuccessResult("Model has been added!");
        }

        public Result Delete(Model model)
        {
            _modeldal.Delete(model);
            return new SuccessResult("Model has been deleted!");
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modeldal.GetAll());

        }

        public IDataResult<Model> GetById(int modelId)
        {
            return new SuccessDataResult<Model>(_modeldal.Get(m=>m.ModelId==modelId));
        }

        public Result Update(Model model)
        {
            _modeldal.Update(model);
            return new SuccessResult("Model has been updated!");
        }

        IResult IModelService.Add(Model model)
        {
            throw new NotImplementedException();
        }

        IResult IModelService.Delete(Model model)
        {
            throw new NotImplementedException();
        }

        IResult IModelService.Update(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
