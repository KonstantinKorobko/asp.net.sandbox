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
                new AppUser{UserName = "Carson", Email = "a1@mail.com", Password = "12345", FirstMidName="Carson",LastName="Alexander"},
                new AppUser{UserName = "Meredith", Email = "a2@mail.com", Password = "12345", FirstMidName = "Meredith", LastName = "Alonso"},
                new AppUser{UserName = "Arturo", Email = "a3@mail.com", Password = "12345", FirstMidName = "Arturo", LastName = "Anand"},
                new AppUser{UserName = "Gytis", Email = "a4@mail.com", Password = "12345", FirstMidName = "Gytis", LastName = "Barzdukas"},
                new AppUser{UserName = "Yan", Email = "a5@mail.com", Password = "12345", FirstMidName = "Yan", LastName = "Li"},
                new AppUser{UserName = "Peggy", Email = "a6@mail.com", Password = "12345", FirstMidName = "Peggy", LastName = "Justice"},
                new AppUser{UserName = "Laura", Email = "a7@mail.com", Password = "12345", FirstMidName = "Laura", LastName = "Norman"},
                new AppUser{UserName = "Nino", Email = "a8@mail.com", Password = "12345", FirstMidName = "Nino", LastName = "Olivetto"}
            };

            var usersAuthent = new UserAuthent[]
            {
                new UserAuthent{UserName = users[0].UserName, Password = users[0].Password, Id = users[0].Id},
                new UserAuthent{UserName = users[1].UserName, Password = users[1].Password, Id = users[1].Id},
                new UserAuthent{UserName = users[2].UserName, Password = users[2].Password, Id = users[2].Id},
                new UserAuthent{UserName = users[3].UserName, Password = users[3].Password, Id = users[3].Id},
                new UserAuthent{UserName = users[4].UserName, Password = users[4].Password, Id = users[4].Id},
                new UserAuthent{UserName = users[5].UserName, Password = users[5].Password, Id = users[5].Id},
                new UserAuthent{UserName = users[6].UserName, Password = users[6].Password, Id = users[6].Id},
                new UserAuthent{UserName = users[7].UserName, Password = users[7].Password, Id = users[7].Id}
            };

            context.Users.AddRange(users);
            context.UsersAuthent.AddRange(usersAuthent);

            context.SaveChanges();
        }
    }
}
