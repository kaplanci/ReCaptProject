using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentManager:IRentService
    {
         IRentDal _rentDal;

         public RentManager(IRentDal rentDal)
         {
             _rentDal = rentDal;
         }


         public IResult Add(Rent rent)
        {
            if (rent.ReturnDate==null && _rentDal.GetAll(r=>r.CarId==r.RentId).Count>0)
            {
                return  new ErrorResult(Messages.TypeFailed);
            }
            return new SuccessResult(Messages.RentAdded);
        }

        public IResult Delete(Rent rent)
        {
            _rentDal.Delete(rent);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IResult Update(Rent rent)
        {
            _rentDal.Update(rent);
            return new SuccessResult(Messages.RentUpdated);
        }

        public IDataResult<List<Rent>> GetAll()
        {
           return new SuccessDataResult<List<Rent>>(_rentDal.GetAll());
        }

        public IDataResult<Rent> GetById(int id)
        {
            return new SuccessDataResult<Rent>(_rentDal.Get(r=>r.RentId==id));
        }

        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentDal.GetRentDetails());
        }
    }
}
