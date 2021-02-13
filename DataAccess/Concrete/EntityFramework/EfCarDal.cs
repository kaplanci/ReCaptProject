using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,RecapDatabaseContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapDatabaseContext context = new RecapDatabaseContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandID equals b.BrandID
                    select new CarDetailDto
                    {
                        CarId = c.CarID,
                        Description = c.Description, 
                        BrandName = b.BrandName, 
                        ColorName = c.ColorName
                    };
                return result.ToList();

            }
        }
    }
}
