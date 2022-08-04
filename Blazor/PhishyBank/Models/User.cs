namespace PhishyBank.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}