using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using apiSecurity.Models;
using apiSecurity.Services;
using Newtonsoft.Json;
using AuthJWT;
using apiSecurity.token;
namespace apiSecurity.Controllers;

[ApiController]
[Route("roles")]
public class RolesAPI : ControllerBase
{
    private readonly IRoles services;   
    private readonly ITokenGenerator jwt;
    public RolesAPI(IRoles services, ITokenGenerator jwt)
    {
        this.services = services;
        this.jwt = jwt;
    }

    [HttpPost("id")]
    public async Task<String> generateToken([FromBody] LoginCredentials auth)
    {
        List<Roles> roles = services.getUserRoles(auth); //mando login, saco id

        List<Data> data = await services.Personinfo(new int[] { roles[0].BusinessEntityID }); //mando id saco permisos y roles

        data[0].RoelsId = TokenGenerator.AddRoles(roles);
        data[0].SpaNames = TokenGenerator.AddPermissions(roles);
        
        var token = jwt.generateToken(data[0]);  //creo token con los datos
        return token;
    }


}
