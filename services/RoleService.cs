using apiSecurity.Database;
using apiSecurity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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
    }
}