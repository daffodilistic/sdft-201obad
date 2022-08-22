using PhishyBank.Models;

namespace PhishyBank.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BankContext context)
        {
            SeedUsers(context);
            SeedTransactions(context);
            context.SaveChanges();
        }

        private static void SeedUsers(BankContext context)
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
        }

        private static void SeedTransactions(BankContext context)
        {
            if (!context.AccountTransactions.Any())
            {
                var transactions = new AccountTransaction[] {
                    new AccountTransaction{
                        UserId=1,
                        AccountIdSource="-1",
                        AccountIdTarget="1",
                        Amount=2100,
                        Currency="SGD",
                        Remarks="Initial deposit",
                        State="completed",
                        DateCreated=new DateTime(2022, 08, 01, 10, 30, 50),
                        DateUpdated=new DateTime(2022, 08, 01, 10, 30, 50),
                        Metadata=null},
                    new AccountTransaction{
                        UserId=1,
                        AccountIdSource="1",
                        AccountIdTarget="2",
                        Amount=1000,
                        Currency="SGD",
                        Remarks="Buy TOTO $5 big $5 small",
                        DateCreated=new DateTime(2022, 08, 01, 10, 32, 04),
                        DateUpdated=new DateTime(2022, 08, 01, 10, 32, 04),
                        State="completed",
                        Metadata=null}
                };
                context.AccountTransactions.AddRange(transactions);
            }
        }
    }
}