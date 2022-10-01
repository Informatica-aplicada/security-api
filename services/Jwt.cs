using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apiSecurity.Models;
namespace AuthJWT
{
    public class Jwt : ITokenGenerator
    {

        public string generateToken(Data data)
        {

            var rolesId = new List<object>();
            var Permissions = new List<object>();
        
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
           
            Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            Int32 expirationTime = 3600;


            var payload = new JwtPayload       {
            {"Name",data.Name},
             {"LastName",data.LastName},
            { "Roles", data.RoelsId },
            { "Permissions", data.SpaNames },
            { "exp", unixTimestamp + expirationTime}
            };

            string key = "keysecret1234567$$$"; //no va aqui


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        }
    }
}
