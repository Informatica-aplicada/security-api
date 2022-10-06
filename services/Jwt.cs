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
    
    public string generateToken(Data data)
    {

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
