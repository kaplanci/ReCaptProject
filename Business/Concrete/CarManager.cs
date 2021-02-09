using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
         ICarDal _carDal;

         public CarManager(ICarDal carDal)
         {
             _carDal = carDal;
         }

         public List<Car> GetAll()
         {
             return _carDal.GetAll(); 

         }

         public List<Car> GetByUnitPrice(decimal min, decimal max)
         {
             throw new NotImplementedException();
         }

         public void add(Car car)
         {
             if (car.Description.Length >= 2 && car.DailyPrice>0)
             {
                 _carDal.Add(car);
             }
             else
             {
                 Console.WriteLine("Ekleme Başarısız");
             }
         }
    }
}
