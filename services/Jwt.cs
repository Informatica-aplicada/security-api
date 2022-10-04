using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apiSecurity.Models;
using Newtonsoft.Json;
namespace AuthJWT
{
    public class Jwt : ITokenGenerator
    {

        private readonly String key;
        public Jwt (String key){
            this.key = key;
        }
        public string generateTokenss(Data data)
        {

            Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            Int32 expirationTime = 3600;


            var payload = new JwtPayload       {
            {"Name",data.Name},
             {"LastName",data.LastName},
            { "Roles", data.RoelsId },
            { "Permissions", data.SpaNames },
            { "exp", unixTimestamp + expirationTime}
            };


            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();

            
            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        }

        
    public string generateToken(Data data)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var skey = Encoding.ASCII.GetBytes(key);
        string rolesJson = JsonConvert.SerializeObject(data.RoelsId);
         string SpaNames = JsonConvert.SerializeObject(data.SpaNames);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { 
                new Claim("Name",data.Name),
                new Claim("LastName",data.LastName),
                new Claim("Roles", rolesJson,JsonClaimValueTypes.JsonArray),
                new Claim("Permissions", SpaNames,JsonClaimValueTypes.JsonArray)}),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(skey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    }
}
