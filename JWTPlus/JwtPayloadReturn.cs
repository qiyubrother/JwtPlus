using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWTPlus
{
    public class JwtPayloadReturn : IJwtPayload
    {
        public string Issuer { get; set; }
        public string Subject { get ; set; }
        public string Audience { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime IssuedAt { get; set; }
        public TimeSpan ValidFor { get; set; }
        public DateTime Expiration { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
