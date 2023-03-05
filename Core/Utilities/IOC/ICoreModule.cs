using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IOC
{
    public interface ICoreModule
    {
        //bizim butun projelerdeki kullanacagımız bagımlılıkları bu metod cozuyo
        void Load(IServiceCollection serviceCollention);
    }
}
