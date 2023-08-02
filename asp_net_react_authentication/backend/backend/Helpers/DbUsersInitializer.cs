using WebApp.Models;

namespace WebApp.Helpers
{
    public class DbUsersInitializer
    {
        public static void Initialize(UserDbContext context)
        {
            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new AppUser[]
            {
                new AppUser{UserName = "Carson", Password = "12345", FirstMidName="Carson",LastName="Alexander"},
                new AppUser{UserName = "Meredith", Password = "12345", FirstMidName = "Meredith", LastName = "Alonso"},
                new AppUser{UserName = "Arturo", Password = "12345", FirstMidName = "Arturo", LastName = "Anand"},
                new AppUser{UserName = "Gytis", Password = "12345", FirstMidName = "Gytis", LastName = "Barzdukas"},
                new AppUser{UserName = "Yan", Password = "12345", FirstMidName = "Yan", LastName = "Li"},
                new AppUser{UserName = "Peggy", Password = "12345", FirstMidName = "Peggy", LastName = "Justice"},
                new AppUser{UserName = "Laura", Password = "12345", FirstMidName = "Laura", LastName = "Norman"},
                new AppUser{UserName = "Nino", Password = "12345", FirstMidName = "Nino", LastName = "Olivetto"}
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
