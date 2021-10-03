using Business.Abstract;
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
        public List<Model> GetAll()
        {
            return _modeldal.GetAll();
        }

        public Model GetById(int modelId)
        {
            return _modeldal.Get(m=>m.ModelId==modelId);
        }
    }
}
