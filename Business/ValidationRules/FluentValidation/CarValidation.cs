using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidation:AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(c =>c.CarDescription).NotEmpty();//boş olamaz
            RuleFor(c => c.CarDescription).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);//0 dan buyük olsun
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c=>c.BrandId == 1);//.WithMessage("") hata mesajını yazdırabılırız. 
            RuleFor(c => c.CarDescription).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");//Must : uymalı
        }
        private bool StartWithA(string carName)
        {
            return carName.StartsWith("A");//A ile başlıyorsa True değilse False döner
        }

    }
   
}
