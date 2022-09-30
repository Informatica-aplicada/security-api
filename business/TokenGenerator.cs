using apiSecurity.Database;
using apiSecurity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace apiSecurity.token
{
    public class TokenGenerator
    {
    

        public static List<String> AddRoles(List<Roles> roles)
        {
            List<String> rolesSpa = new List<String>();

            foreach (var item in roles)
            {
                rolesSpa.Add(item.SpaName);
            }
            return rolesSpa;
        }

           public static List<int> AddPermissions(List<Roles> roles)
        {
            List<int> Permissions = new List<int>();

            foreach (var item in roles)
            {
                Permissions.Add(item.IdPermission);
            }
            return Permissions;
        }

     public static List<int> AddPermissionsss(List<Roles> roles)
        {
            List<int> Permissions = new List<int>();

            foreach (var item in roles)
            {
                Permissions.Add(item.IdPermission);
            }
            return Permissions;
        }

        

    }
}