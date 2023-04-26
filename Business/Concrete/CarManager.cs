using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(item=>item.ColorId==id);
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(item => item.BrandId == id);
        }



        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(item=>item.DailyPrice>min && item.DailyPrice<max);
        }

        public bool CarAdded(Car car)
        {
            if (car.CarDescription.Length<2 || car.DailyPrice<=0)
            {
                return false;
            }
            else
            {
                _carDal.Add(car);
                return true;
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
