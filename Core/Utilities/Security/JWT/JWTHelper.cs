using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }  // IConfiguration : API'mizdeki appsettings dosyamızı okumaya yarar
        private TokenOptions _tokenOptions;  // TokenOptions : appsettings okudugumuz degerleri bunun icine atarız -JWT klasorunde bu class
        private DateTime _accessTokenExpiration; //Token süresi
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration; // Bunu .net kendi enjecte ediyor
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //appsettings içereisindeki Token Options bolumunu al ve TokenOptions ile maple

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //token süresi
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //token için securityKey lazım bunu bizim olusturdugumuz SecurityKeyHelper sınıfı ile yaptık
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); //hangi algoritmayı kullanacagı bilgisi
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //jwt olusturmak icin bu metod'u asagıda olusturduk
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, //nuget paket System.IdentityModel.Tokens.Jwt
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims), //Claimler onemli onun icin de asagıda metod yaptık
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            //Claim'de sadece yetkiler bulunmaz kullanıcı ile ilgili diger bilgiler de tutulur asagida oldugu gibi

            //Extensions: .net'de var olan bir nesneye yeni metodlar eklemek için kullanılır. Claims .net içinde olan bir sınıf ama aşagıdaki gibi AddEmail,AddName gibi metodları yok biz extensions sayesinde bu metodları kendimiz ekledik.
            // Bir extension yazmamıs icin hem class hem de metod static olmak zorunda

            // Core katmanında extesion adında klasor icinde bu 
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); //kullanıcının rollerini veri tabanından cekip ekliyoruz

            return claims;
        }
    }
}
