using apiSecurity.Models;
public interface ITokenGenerator
{
   String generateToken(Data data);
}