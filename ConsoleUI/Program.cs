
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class program
    {
        static void Main(string[] args)
        {
            //Arabaları listeleme
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.ModelYear} {car.CarDescription}");
            }

            //Araba Ekleme

            Car car1 = new Car() { BrandId=7, ColorId=7,  DailyPrice=20000, CarDescription="V", ModelYear=2000 };
            if (carManager.CarAdded(car1))
            {
                Console.WriteLine("Araba Eklendi");
            }
            //CarDescription 2 den küçük ve DailyPrice<=0 küçük ise ekleme yapılmayacaktır.
            else
            {
                Console.WriteLine("Tekrar Kontrol ediniz");
            }

        }
    }
}