using Business.Abstract;
using Business.Constants;
using Core.Ultities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Message.CarNameInValid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Message.CarAdded);
        }

        public IResult Delete(Brand brand)
        {            
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetById(b=>b.Id==id));
        }

        public IResult Update(Brand brand)
        {
           _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
