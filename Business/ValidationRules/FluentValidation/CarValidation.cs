using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0).When(c=>c.BrandId==1);
            RuleFor(c => c.Description).MinimumLength(5);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Araç A harfi ile başlamalı"); // Açıklama a ile başlamalı... StartWithA bizim olusturdumuz metod

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
            //Eger A ile baslıyorsa true doner...
        }
    }
}
