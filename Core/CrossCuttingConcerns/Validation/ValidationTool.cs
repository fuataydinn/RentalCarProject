using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool  // bu tip araclar static olusturulur , bir kere instance'i alinsin yeter
    {
        public static void Validate(IValidator validator,object entity)  // IValidator hepsinin mirasını tutuyor, object olmasının nedeni DTO veya nesne yollayabiliriz
        {
            var context = new ValidationContext<object>(entity); 
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
