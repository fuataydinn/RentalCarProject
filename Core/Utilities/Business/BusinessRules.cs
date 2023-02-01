using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        // params olunca içerisine istedigimiz kadar IResult verebiliriz.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)  //basarısız ise errorResult dön
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
