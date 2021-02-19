using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(1);
            RuleFor(c => c.ColorId).GreaterThanOrEqualTo(1);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1900);
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}
