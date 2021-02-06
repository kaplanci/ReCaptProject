using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager  carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }



            
        }
    }
}
