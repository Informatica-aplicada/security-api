using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using apiSecurity.Models;
using apiSecurity.Services;
using Newtonsoft.Json;
using AuthJWT;
namespace apiSecurity.Controllers;

[ApiController]
[Route("roles")]
public class RolesAPI : ControllerBase
{   
        RoleService services = new RoleService();
        [HttpGet("index")]
        public string index(){
            return "index";
        }

          [HttpPost("id")]
        public async Task<String> generateToken([FromBody] LoginCredentials auth)
        {
            List<Roles> roles =  services.getUserRoles(auth);
            List<Data>  data = new List<Data> ();
            data = await services.Personinfo(new int[]{roles[0].BusinessEntityID});
            List<int> rolesId = new List<int>();
             List<int> PermissionsId = new List<int>();
            foreach (var item in roles)
            {
              rolesId.Add(item.IdRole);
              PermissionsId.Add(item.IdPermission);
            }
            data[0].IdRole = rolesId;
            data[0].IdPermission = PermissionsId;
            Jwt jwt = new Jwt();
            var token = jwt.Authenticaton(data[0]);
            return token;
        }

           [HttpPost("token")]
       public string test(Data data){
        Jwt jwt = new Jwt();
        var token = jwt.Authenticaton(data);
            return token;
        }
}
