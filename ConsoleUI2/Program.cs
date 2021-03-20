using Business.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI2
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();

            RentDetailsTest();
        }

        private static void RentDetailsTest()
        {
            RentManager rentManager = new RentManager(new EfRentDal());
            var result = rentManager.GetRentDetails();
            foreach (var rent in result.Data)
            {
                Console.WriteLine(
                    rent.RentId + "/" +
                    rent.CarDescription + "/" +
                    rent.CustomerName + "/" +
                    rent.FirstName + "/" +
                    rent.LastName + "/" +
                    rent.RentDate + "/" +
                    rent.ReturnDate);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.Description + "/" + car.BrandName + "/" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
