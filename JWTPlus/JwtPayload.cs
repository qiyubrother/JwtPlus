using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTPlus
{
    public class JwtPayload : IJwtPayload
    {
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public DateTime ValidFrom { get; set; } = DateTime.Now;
        public DateTime IssuedAt => DateTime.Now;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(60);

        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public Func<Task<string>> JtiGenerator =>
          () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials SigningCredentials { get; set; }
    }
}
