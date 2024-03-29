﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        //Kurallar constuctor icerisine yazılır
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b=>b.Name).MinimumLength(2);
          
        }
    }
}
