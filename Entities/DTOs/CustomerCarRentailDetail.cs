using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{    public class CustomerCarRentailDetail:IDto
    {
        //arabanın hangi müşteride nezman aldıgı ve araba teslimi yapılıp yapılmadıgını bulma
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsAvaliable { get; set; }

    }
}
