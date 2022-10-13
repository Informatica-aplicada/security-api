using apiSecurity.Database;
using apiSecurity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using apiSecurity.token;
namespace apiSecurity.Services
{
    public class RoleService : IRoles
    {

        DataRoles dR = new DataRoles();
        
        public List<Roles>  getUserRoles(LoginCredentials auth){
            return dR.List(auth);
        }
        
        public async Task<List<Data>> Personinfo([FromBody] int[] id)
        {
            List<Data> person = new List<Data>();
            var json = JsonConvert.SerializeObject(id);
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://person-microservices.azurewebsites.net/api/person/ids"),
                Content = new StringContent(json)
                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                person = JsonConvert.DeserializeObject<List<Data>>(body);
                Console.WriteLine(body);
            }

            return person;

        }

        public async Task<Data> getData(LoginCredentials auth)
        {

      
        List<Roles> roles = getUserRoles(auth); //mando login, saco id

        List<Data> data = await Personinfo(new int[] { roles[0].BusinessEntityID }); //mando id saco permisos y roles

        data[0].RoelsId = TokenGenerator.AddRoles(roles);
        data[0].SpaNames = TokenGenerator.AddPermissions(roles);
        return data[0];
        }
    }
}