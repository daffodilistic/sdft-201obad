using PhishyBank.Models;

namespace PhishyBank.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BankContext context)
        {
            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Email="daffodilistic@gmail.com",Password="daffo123"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}