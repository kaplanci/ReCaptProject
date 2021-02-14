using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
         ICarDal _carDal;

         public CarManager(ICarDal carDal)
         {
             _carDal = carDal;
         }

         public IDataResult<List<Car>> GetAll()
         {
             if (DateTime.Now.Hour==22)
             {
                 return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
             }
             return new SuccessDataResult<List<Car>> (_carDal.GetAll(),Messages.CarsListed);

         }

         public IDataResult<List<Car>> GetAllByBrandId(int id)
         {
             return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandID==id));
         }

         public IDataResult<List<Car>>  GetByDailyPrice(decimal min, decimal max)
         {
             return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max));
         }

         public IDataResult<List <CarDetailDto>> GetCarDetails()
         {
             return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
         }

         public IDataResult<Car> GetById(int carId)
         {
             return new SuccessDataResult<Car>(_carDal.Get(c => c.CarID == carId));
         }

         public IResult add(Car car)
         {
             if (car.Description.Length >= 2 && car.DailyPrice>0)
             {
                 _carDal.Add(car);
                 return new SuccessResult(Messages.CarAdded);

             }
             else
             {
                 return new ErrorResult(Messages.CarNameInvalid);
             }

             
         }
    }
}
