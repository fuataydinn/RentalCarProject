using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //class'ın attribute'lerini oku 
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)  //method'un attribute'lerini oku 
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);  //onları bir listeye ekle 

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //calısma onceligini Priority'ye gore yap
        }
    }
}
