using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName.Length).LessThan(20).GreaterThan(2);
            RuleFor(u=>u.LastName).NotEmpty();
            RuleFor(u => u.LastName.Length).LessThan(20).GreaterThan(2);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password.Length).GreaterThan(8);
            RuleFor(u => u.EMail).NotEmpty();
            RuleFor(u => u.EMail).Must(ContainMail);
        }

        private bool ContainMail(string arg)
        {
            return arg.Contains("@");
        }
    }
}
