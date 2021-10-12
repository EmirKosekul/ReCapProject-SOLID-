using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserManager(new EFUserDal());
            ICustomerService customerService = new CustomerManager(new EFCustomerDal());
            User user1 = new User();
            Customer customer1 = new Customer();
            foreach (var user in userService.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
            user1.Email = "asdasdllq@outlook.com";
            user1.FirstName = "Arzu";
            user1.LastName = "uıguıkguık";
            user1.Password = "5677";
            user1.UserId = 4;
            userService.Add(user1);
            customer1.CompanyName = "ArzuCo";
            customer1.CustomerId = 4;
            customerService.Add(customer1);
            foreach (var user in userService.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }

            //Test();
            //ModelTest();
        }

        private static void ModelTest()
        {
            ModelManager modelManager = new ModelManager(new EFModelDal());
            IModelDal modelDal = new EFModelDal();
            //Model model1 = new Model();
            //model1.ModelId = 1;
            //model1.ModelName = "A7";
            Model model2 = new Model();
            model2.ModelId = 3;
            model2.ModelName = "CcL";
            modelDal.Delete(model2);
            foreach (var model in modelManager.GetAll().Data)
            {
                Console.WriteLine(model.ModelName + "  ....  " + model.ModelId);
            }
        }

        private static void Test()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            //foreach (var car in carManager.GetByColorId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}
            Car car1 = new Car();
            car1.Id = 3;
            car1.CarName = "Renault";
            car1.DailyPrice = 10;
            car1.ColorId = 2;
            car1.BrandId = 3;
            car1.Description = "Renault";
            car1.ModelYear = 1995;
            //Car car2 = new Car();
            //car2.Id = 3;
            //car2.DailyPrice = 0;
            //car2.ColorId = 2;
            //car2.BrandId = 1;
            //car2.Description = "Old car 1994";
            //car2.ModelYear = 1994;
            EFCarDal a = new EFCarDal();
            a.Update(car1);
            //a.Add(car2);
            //a.Add(car1);
            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.CarName+" "+car.ColorName+ " " +car.BrandName+" " +car.DailyPrice);
            //}
        }
    }
}
