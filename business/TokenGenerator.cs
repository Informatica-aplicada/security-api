using apiSecurity.Database;
using apiSecurity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace apiSecurity.token
{
    public class TokenGenerator
    {
    

        public static List<int> AddRoles(List<Roles> roles)
        {
            List<int> rolesSpa = new List<int>();

            foreach (var item in roles)
            {
                rolesSpa.Add(item.IdRole);
            }
            return rolesSpa;
        }

           public static List<String> AddPermissions(List<Roles> roles)
        {
            List<String> Permissions = new List<String>();

            foreach (var item in roles)
            {
                Permissions.Add(item.SpaName);
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