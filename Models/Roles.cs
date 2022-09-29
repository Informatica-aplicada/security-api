namespace apiSecurity.Models
{
    public class Roles
    {
        public int BusinessEntityID {get;set;}
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public int IdPermission { get; set; }
        public string SpaName { get; set; }
    }
}