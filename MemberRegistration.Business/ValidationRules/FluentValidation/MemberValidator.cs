﻿using FluentValidation;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.ValidationRules.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty();
            RuleFor(m => m.FirstName.Length).GreaterThan(2);
            RuleFor(m => m.LastName).NotEmpty();
            RuleFor(m => m.LastName.Length).GreaterThan(2);
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
            RuleFor(m => m.DateOfBirth).NotEmpty().LessThanOrEqualTo(DateTime.Now - TimeSpan.FromDays(18 * 365));
            RuleFor(m => m.TcNo).NotEmpty().Length(11);
        }
    }
}
