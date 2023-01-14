using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)  //Bana validatorType ver 
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sinifi degil !");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // reflextion, calısma anında birseyleri calistirmamizi saglar, instance olustur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //validator'un basetype'ını bul onun generic argumanından ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // ilgili metodun parametrelerini bul, (invocation metod demek) 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //Validation tool kullanarak validate at
            }
        }
    }
}
