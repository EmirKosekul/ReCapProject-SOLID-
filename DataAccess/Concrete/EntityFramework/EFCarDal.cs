using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarCompanyContext context=new CarCompanyContext())
            {
                if (entity.DailyPrice>0)
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }              
            }
        }

        public void Delete(Car entity)
        {
            using (CarCompanyContext context = new CarCompanyContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarCompanyContext context = new CarCompanyContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarCompanyContext context = new CarCompanyContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarCompanyContext context = new CarCompanyContext())
            {
                var uptadetEntity = context.Entry(entity);
                uptadetEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
