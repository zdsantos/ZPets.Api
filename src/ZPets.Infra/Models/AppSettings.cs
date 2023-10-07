namespace ZPets.Infra.Models
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public JwtSettings JwtSettings { get; set; }
    }

    public class ConnectionStrings
    {
        public string Database { get; set; }
    }

    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }

    }
}
