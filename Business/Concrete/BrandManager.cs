using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int brandId)
        {
            throw new NotImplementedException();
        }
    }
}
