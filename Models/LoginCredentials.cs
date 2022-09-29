using System;

namespace apiSecurity.Models
{
    public class LoginCredentials
    {
        public string gmail {get; set;}
        public string passw { get; set;}


        public override string ToString()
        {
            return $"{nameof(gmail)}: {gmail}, {nameof(passw)}: {passw}";
        }
    }
}
