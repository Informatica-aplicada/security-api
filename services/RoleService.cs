using apiSecurity.Database;
using apiSecurity.Models;

namespace apiSecurity.Services
{
    public class RoleService
    {
        public RoleService(){}
        DataRoles dR = new DataRoles();

           public List<Roles>  getUserRoles(LoginCredentials auth){
            return dR.List(auth);
        }


    }
}