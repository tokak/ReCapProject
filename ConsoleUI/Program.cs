
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Threading.Tasks.Dataflow;

namespace ConsoleUI
{
    class program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
           

            //EklemeIslemleriTest(carManager, brandManager, colorManager);
            //GetCarTest();
            //SartaGoreArabaEklemeTest(carManager);
            //iliskiliTablodaArabaGetirmeTest();

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
            foreach (var item in carManager1.GetCarDetails())
            {
                Console.WriteLine($"{item.BrandName}\t {item.CarDesription}\t {item.ModelYear}\t {item.ColorName}\t {item.DailyPrice}");

            }
        }

        private static void SartaGoreArabaEklemeTest(CarManager carManager)
        {
            //Araba Ekleme

            Car car1 = new Car() { BrandId = 7, ColorId = 7, DailyPrice = 20000, CarDescription = "V", ModelYear = 2000 };
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

        private static CarManager GetCarTest()
        {
            //Arabaları listeleme
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.ModelYear} {car.CarDescription}");
            }

            return carManager;
        }
    }
}