using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apiSecurity.Models;
namespace AuthJWT
{
    public class Jwt
    {
      
        public string Authenticaton(Data data)
        {

            var rolesId = new List<object>();
            var Permissions = new List<object>();
            rolesId.Add( data.IdRole);
            Permissions.Add(data.IdPermission);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
    

            var payload = new JwtPayload       {
            {"Name",data.Name},
             {"LastName",data.LastName},
            { "Roles", rolesId },
            { "Permissions", Permissions }
            };
             string key = "keysecret1234567$$$";
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
