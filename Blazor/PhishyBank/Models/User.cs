namespace PhishyBank.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password) =>
            (Username, Password) = (username, password);
    }
}