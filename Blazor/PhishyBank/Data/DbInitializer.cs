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
            var users = new User[] {
                new User{
                    Id=1,
                    Email="marcus_soh@sharklasers.com",
                    Name="Marcus Soh",
                    Password="marcus123"
                },
                new User{
                    Id=2,
                    Email="lawrence_soh@sharklasers.com",
                    Name="Lawrence Soh",
                    Password="lawrence123"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}