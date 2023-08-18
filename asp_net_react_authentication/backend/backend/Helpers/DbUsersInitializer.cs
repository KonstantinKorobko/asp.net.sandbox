using backend.Models;
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

            var idsUsers = new IdByUserName[]
            {
                new IdByUserName{UserName = users[0].UserName, Id = users[0].Id},
                new IdByUserName{UserName = users[1].UserName, Id = users[1].Id},
                new IdByUserName{UserName = users[2].UserName, Id = users[2].Id},
                new IdByUserName{UserName = users[3].UserName, Id = users[3].Id},
                new IdByUserName{UserName = users[4].UserName, Id = users[4].Id},
                new IdByUserName{UserName = users[5].UserName, Id = users[5].Id},
                new IdByUserName{UserName = users[6].UserName, Id = users[6].Id},
                new IdByUserName{UserName = users[7].UserName, Id = users[7].Id}
            };

            var idsEmails = new IdByEmail[]
            {
                new IdByEmail{Email = users[0].Email, Id = users[0].Id},
                new IdByEmail{Email = users[1].Email, Id = users[1].Id},
                new IdByEmail{Email = users[2].Email, Id = users[2].Id},
                new IdByEmail{Email = users[3].Email, Id = users[3].Id},
                new IdByEmail{Email = users[4].Email, Id = users[4].Id},
                new IdByEmail{Email = users[5].Email, Id = users[5].Id},
                new IdByEmail{Email = users[6].Email, Id = users[6].Id},
                new IdByEmail{Email = users[7].Email, Id = users[7].Id}
            };

            context.Users.AddRange(users);
            context.IdsUsers.AddRange(idsUsers);
            context.IdsEmails.AddRange(idsEmails);

            context.SaveChanges();
        }
    }
}
