using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
             {
                 new Car{BrandID = 1,CarID = 1,ColorID = 2,DailyPrice = 2800,Description = "TOGG HATCHBACK",ModelYear = 2023},
                 new Car{BrandID = 1,CarID = 2,ColorID = 3,DailyPrice = 2500,Description = "TOGG SEDAN",ModelYear = 2023},
                 new Car{BrandID = 2,CarID = 3,ColorID = 1,DailyPrice = 3500,Description = "TESLA",ModelYear = 2021},
                 new Car{BrandID = 3,CarID = 4,ColorID = 2,DailyPrice = 1500,Description = "PASSAT",ModelYear = 2023},
                 new Car{BrandID = 3,CarID = 5,ColorID = 2,DailyPrice = 5600,Description = "JETTA",ModelYear = 2003}
             };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID); //LINQ
            carToUpdate.Description = car.Description;
            carToUpdate.CarID = car.CarID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorID = car.ColorID; 
            
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarID==car.CarID); //LINQ


            _cars.Remove(carToDelete); 

        }

        public List<Car> GetAllByCategory(int brandID)
        {
            return _cars.Where(c => c.BrandID == brandID).ToList(); //LINQ
        }
    }
}
