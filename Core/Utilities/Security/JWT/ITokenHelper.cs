using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Kim için token olusturacagımızı ve hangi yetkileri (claim) olacagını parametreye ver
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
