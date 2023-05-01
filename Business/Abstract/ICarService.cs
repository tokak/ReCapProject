using Core.Ultities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult CarAdded(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}
