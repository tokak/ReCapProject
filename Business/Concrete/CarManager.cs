using Business.Abstract;
using Core.Ultities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(item => item.ColorId == id));
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(item => item.BrandId == id));
        }



        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(item => item.DailyPrice > min && item.DailyPrice < max));
        }

        public IResult CarAdded(Car car)
        {
            if (car.CarDescription.Length < 2 || car.DailyPrice <= 0)
            {
                return new ErrorResult();
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult();
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
