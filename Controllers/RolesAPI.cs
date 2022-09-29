using Microsoft.AspNetCore.Mvc;
using apiSecurity.Models;
using apiSecurity.Services;
using Newtonsoft.Json;
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
        public List<Roles> ListByYear([FromBody] LoginCredentials auth)
        {
            Console.WriteLine("ingreso peticion");
            Console.WriteLine(JsonConvert.SerializeObject(auth));
            return services.getUserRoles(auth);
        }
}
