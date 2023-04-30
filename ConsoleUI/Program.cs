
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Threading.Tasks.Dataflow;

namespace ConsoleUI
{
    class program
    {
        static void Main(string[] args)
        {

            //TeslimEdilenEdilmeyenArabalarıListelemeTest();
            //RentalAddedTest();
            //CustomerAddTest();
            //UserAddTest();
            //CarAddedTest();
            //EklemeIslemleriTest(carManager, brandManager, colorManager);
            //GetCarTest();
            //SartaGoreArabaEklemeTest(carManager);
            //iliskiliTablodaArabaGetirmeTest();

        }

        private static void TeslimEdilenEdilmeyenArabalarıListelemeTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetCustomerCarRentalDetails();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.CarName} {item.CustomerName} {item.RentDate} {item.ReturnDate} {item.IsAvaliable}");
            }
            //Müşteride olan Arabaları Listeleme
            Console.WriteLine("Müşteride Olan Arabalar");
            foreach (var item in result)
            {
                if (item.IsAvaliable == true)
                {
                    Console.WriteLine($"{item.CarName} {item.CustomerName} {item.RentDate} {item.ReturnDate} ");

                }
            }
            Console.WriteLine("Müşteride Olmayan Arabalar");
            foreach (var item in result)
            {
                if (item.IsAvaliable == false)
                {
                    Console.WriteLine($"{item.CarName} {item.CustomerName} {item.RentDate} {item.ReturnDate} ");

                }
            }
        }

        private static void RentalAddedTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Parse("10-04-2023"),
                ReturnDate = DateTime.Parse("20-04-2023"),
                IsAvaliable = true
            };
            var result = rentalManager.Add(rental1);
            if (result.Success)
            {
                Console.WriteLine("Ekleme işlemi başarılı");
            }
            else
            {
                Console.WriteLine("Araba Müşteride ");
            }
            Rental rental2 = new Rental() { CarId = 2, CustomerId = 2, RentDate = DateTime.Parse("30-04-2023"), IsAvaliable = false };
            var result2 = rentalManager.Add(rental2);
            if (result.Success)
            {
                Console.WriteLine("Ekleme işlemi başarılı");
            }
            else
            {
                Console.WriteLine("Araba Müşteride ");
            }
        }

        private static void CustomerAddTest()
        {
            //Kampanya ekleme
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer() { UserId = 1, CompanyName = "Yaz kampanyası %20 indirim" };
            customerManager.Add(customer1);
        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user1 = new User() { FirstName = "Mehmet", LastName = "Adıgüzel", Email = "adiguzel@gmail.com", Password = "123" };
            var result = userManager.Add(user1);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarAddedTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() { BrandId = 7, ColorId = 7, CarDescription = "V", DailyPrice = 7000000, ModelYear = 2010 };
            var result = carManager.CarAdded(car);
            if (result.Success)
            {
                Console.WriteLine("Eklendi");
            }
            else
            {
                Console.WriteLine("Başarısız");
            }
        }

        private static void EklemeIslemleriTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            //Ekleme işlemleri
            Color color1 = new Color();
            color1.ColorName = "Mavi";
            colorManager.Add(color1);
            Brand brand1 = new Brand();
            brand1.BrandName = "Citroen";
            brandManager.Add(brand1);
            Car car1 = new Car() { BrandId = 7, ColorId = 7, ModelYear = 2000, CarDescription = "Citroen A1 serisi", DailyPrice = 15000000 };
            carManager.CarAdded(car1);
        }

        private static void iliskiliTablodaArabaGetirmeTest()
        {
            //ilişkili tablo listeleme
            CarManager carManager1 = new CarManager(new EfCarDal());
            Console.WriteLine("Marka\t Açıklama\t Model\t Renk\t Fiyat\t");
            foreach (var item in carManager1.GetCarDetails().Data)
            {
                Console.WriteLine($"{item.BrandName}\t {item.CarDesription}\t {item.ModelYear}\t {item.ColorName}\t {item.DailyPrice}");

            }
        }

        private static void SartaGoreArabaEklemeTest(CarManager carManager)
        {
            //Araba Ekleme

            Car car1 = new Car() { BrandId = 7, ColorId = 7, DailyPrice = 20000, CarDescription = "V", ModelYear = 2000 };
            if (carManager.CarAdded(car1).Success)
            {
                Console.WriteLine("Araba Eklendi");
            }
            //CarDescription 2 den küçük ve DailyPrice<=0 küçük ise ekleme yapılmayacaktır.
            else
            {
                Console.WriteLine("Tekrar Kontrol ediniz");
            }
        }

        private static CarManager GetCarTest()
        {
            //Arabaları listeleme
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.ModelYear} {car.CarDescription}");
            }

            return carManager;
        }
    }
}