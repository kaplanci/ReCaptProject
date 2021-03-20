using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarManager :ICarService
    {
         ICarDal _carDal;
         private IBrandService _brandService;
       
        

         public CarManager(ICarDal carDal,IBrandService brandService)
         {
             _carDal = carDal;
             _brandService = brandService;

         }

       

        public IDataResult<List<Car>> GetAll()
         {
             if (DateTime.Now.Hour==20)
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

         //[ValidationAspect(typeof(CarValidator))]
         public IResult Add(Car car)
         {
             IResult result =BusinessRules.Run(CheckIfCarExist(car.Description),CheckIfCarCountOfBrandCorrect(car.BrandID),
                 CheckCountOfBrand());

             if (result!=null)
             {
                 return result;
             }
             _carDal.Add(car);
             return new SuccessResult(Messages.CarAdded);

         }

         public IResult Delete(Car car)
         {
             _carDal.Delete(car);
             return new SuccessResult(Messages.CarDeleted);

        }

         [ValidationAspect(typeof(CarValidator))]
         public IResult Update(Car car)
         {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarUpdated);

            }
            
            return new ErrorResult(Messages.TypeFailed);
            
         }

         private IResult CheckIfCarCountOfBrandCorrect(int brandId)
         {

             var result = _carDal.GetAll(c => c.BrandID ==brandId).Count;
             if (result >= 10)
             {
                 return new ErrorResult(Messages.CarCountofError);
             }
             return new SuccessResult();
         }

         private IResult CheckIfCarExist (string Description)
         {
             var result = _carDal.GetAll(c => c.Description == Description).Any();
             if (result)
             {
                 return new ErrorResult(Messages.CarAlreadyExist);
             }
             return new SuccessResult();
         }

         private IResult CheckCountOfBrand()
         {
             var result = _brandService.GetAll();
             if (result.Data.Count>15)
             {
                 return new ErrorResult(Messages.BrandLimitExceed);
             }
             return new SuccessResult();
         }
    }
}
