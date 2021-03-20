using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentDal : EfEntityRepositoryBase<Rent, RecapDatabaseContext>,IRentDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (RecapDatabaseContext context =new RecapDatabaseContext())
            {
                var result = from r in context.Rents
                    join c in context.Cars on r.CarId equals c.CarID
                    join b in context.Brands on c.BrandID equals b.BrandID
                    join clr in context.Colors on c.ColorID equals clr.ColorID
                    join cu in context.Customers on r.CustomerId equals cu.CustomerId
                    join u in context.Users on cu.UserId equals u.UserId

                    select new RentDetailDto
                    {
                        BrandName = b.BrandName,
                        CarId = c.CarID,
                        ColorName = clr.ColorName,
                        CompanyName = cu.CompanyName,
                        CarDescription = c.Description,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        RentId = r.RentId,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };

                return result.ToList();
            }
        }
    }
}
