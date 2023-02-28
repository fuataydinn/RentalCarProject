using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    // kullanıcı sisteme istek yaparken elinde tutdugu token'ı (local storoge ) paketin icine koyup gondermesi bu class olur  
    public class AccessToken // erisim anahtarı
    {
        //kullanıcı adı ve parola verir kullanıcı biz ona Token veririz bu sınıf ile+
        public string Token { get; set; }
        public DateTime Expration { get; set; } // bitis suresi
    }
}
