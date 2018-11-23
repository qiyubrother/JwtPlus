using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JWTPlus
{
    public class Jwt
    {
        private string _secret = string.Empty;
        public Jwt(string secret)
        {
            _secret = secret;
        }
        public string Encode(JwtPayload jwtPayload)
        {
            IJwtEncoder encoder = new JwtEncoder(new HMACSHA256Algorithm(), new JsonNetSerializer(), new JwtBase64UrlEncoder());

            return encoder.Encode(jwtPayload, _secret);
        }

        public IJwtPayload Decode(string token)
        {
            try
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, new JwtValidator(new JsonNetSerializer(), new UtcDateTimeProvider()), new JwtBase64UrlEncoder());

                var json = JsonConvert.DeserializeObject(decoder.Decode(token, _secret, verify: true)) as JObject;
                var jwtPayload = new JwtPayloadReturn {
                    ValidFrom = Convert.ToDateTime(json["ValidFrom"].ToString()),
                    IssuedAt = Convert.ToDateTime(json["IssuedAt"].ToString()),
                    ValidFor = TimeSpan.Parse(json["ValidFor"].ToString()),
                    Expiration = Convert.ToDateTime(json["Expiration"].ToString()),
                };

                return jwtPayload;
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                throw;
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                throw;
            }
        }
    }
}
