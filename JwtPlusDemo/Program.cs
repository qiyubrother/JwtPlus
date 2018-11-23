using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWTPlus;
namespace JwtPlusDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = Guid.NewGuid().ToString(); 
            var jwt = new Jwt(secret);

            //var payload = new JwtPayload { ValidFor = TimeSpan.FromMinutes(120) };
            var payload = new JwtPayload { }; // 默认60分后过期
            var token = jwt.Encode(payload); // 生成Token
            Console.WriteLine($"Token:{token}\n");
            Console.WriteLine($"Expiration:{payload.Expiration}");

            #region 判断Token是否有效
            try
            {
                var jwtRtn = jwt.Decode(secret);
                if (jwtRtn.Expiration < DateTime.Now)
                {
                    // Timeout.
                    Console.WriteLine("Token is invalid.");
                }
                else
                {
                    Console.WriteLine("Token is valid.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid secret.");
            }

            #endregion
            Console.ReadKey();
        }
    }
}
