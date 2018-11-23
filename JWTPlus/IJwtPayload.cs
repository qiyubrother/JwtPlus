using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWTPlus
{
    public interface IJwtPayload
    {
        string Issuer { get; set; }
        string Subject { get; set; }
        string Audience { get; set; }
        DateTime ValidFrom { get; set; }
        DateTime IssuedAt { get; }
        TimeSpan ValidFor { get; set; }
        DateTime Expiration { get; }
        //SigningCredentials SigningCredentials { get; set; }
    }
}
