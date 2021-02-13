using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByUnitPrice(decimal min , decimal max);
        List<CarDetailDto> GetCarDetails();





        void add(Car car);
    }
}
 