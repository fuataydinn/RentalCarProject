using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Cross_Custting_Concerns
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya Loglandı.");
        }
    }
}
