namespace Krzaq.Mikrus.Database.Settings
{
    public record DatabaseConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User {  get; set; }
        public string Password { get; set; }
        public string Schema { get; set; }
    }
}
