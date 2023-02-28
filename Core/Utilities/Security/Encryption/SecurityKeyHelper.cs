using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //şifreleme olan sistemlerde hersey byte array formatında olmak zorundadır, jwt servisleri anlaması icin.
        //appsetting dosyasındaki key'i byte array haline getirmeye yarıyor bu sınıf
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //bu baytı alıp onu simetrik bir anahtar yapıyor
        }
    }
}
