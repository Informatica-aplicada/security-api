using apiSecurity.Models;
public interface IRoles
{
   List<Roles> getUserRoles(LoginCredentials auth);
   Task<List<Data>>  Personinfo(int[] id);
}