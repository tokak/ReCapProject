using Core.DataAcccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RenteCarDbContext>, IRentalDal
    {
        public List<CustomerCarRentailDetail> GetCustomerCarRentalDetails()
        {
            using (RenteCarDbContext context = new RenteCarDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join u in context.Users
                             on c.Id equals u.Id
                             select new CustomerCarRentailDetail
                             {
                                 CarName = c.CarDescription,
                                 CustomerName = u.FirstName + " " + u.LastName + " " + u.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 IsAvaliable=r.IsAvaliable
                             };
                return result.ToList();
            }
        }
    }
}
