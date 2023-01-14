using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Cross_Custting_Concerns
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veri tabanına loglandı");
        }
    }
}
