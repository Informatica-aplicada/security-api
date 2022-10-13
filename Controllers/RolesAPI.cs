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
        if(services.getUserRoles(auth).Count == 0){
            return ""; //mensaje de error
        }else{
        return jwt.generateToken(services.getData(auth).Result);
        }
    }



    [HttpGet("index")]
    public async Task<String> index()
    {
        return "TODO OKI";
    }

}
