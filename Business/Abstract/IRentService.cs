using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService
    {
        IResult Add(Rent rent);
        IResult Delete(Rent rent );
        IResult Update(Rent rent );
        IDataResult<List<Rent>> GetAll();
        IDataResult<Rent> GetById(int id);
        IDataResult<List<RentDetailDto>> GetRentDetails();

    }
}
