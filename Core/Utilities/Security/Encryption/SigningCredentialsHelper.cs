using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //imzalama 
        // securityKey vericez oda bize imzalama nesnesini donecek
        //JWT sistemini yonetirken senin anahtarın bu securityKey ve şifreleme algoritman bu SecurityAlgorithms diyoruz 
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            // sen hashing işlemi yapacaksın securityKey anahtarını kullan ve SecurityAlgorithms şifreleme olarak bunu kullan
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
