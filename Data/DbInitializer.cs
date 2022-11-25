using GeoprofsXyn.Models;

namespace GeoprofsXyn.Data
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            if (context.User.Any())
            {
                return;
            }

            var userOne = new User
            {
                Naam = "test",
                Email = "test@gmail.com",
                Wachtwoord = "test1",
                VerlofUren = int.Parse("10")
            };
            var userTwo = new User
            {
                Naam = "ben",
                Email = "ben@gmail.com",
                Wachtwoord = "ben1",
                VerlofUren = int.Parse("20")
            };
            context.User.Add(userOne);
            context.User.Add(userTwo);
            context.SaveChanges();

            var Rol = new Rol[]
            {
                new Rol{Naam="Werknemer", userId = userOne.Id},
                new Rol{Naam="Team Manager", userId = userTwo.Id}
            };

            context.Rol.AddRange(Rol);
            context.SaveChanges();

            var TeamOne = new Team 
            { 
                Naam = "Team 1",
                userId = userOne.Id
            };
            var TeamTwo = new Team
            {
                Naam = "Team 2",
                userId = userTwo.Id
            };

            context.Team.Add(TeamOne);
            context.Team.Add(TeamTwo);

            context.SaveChanges();

            var verlofTicketOne = new Verlof
            { 
                Naam = "Huisarts",
                Omschrijving = "Huisarts afspraak",
                BeginDatum = DateTime.Parse("2022-11-07"),
                EindDatum = DateTime.Parse("2022-11-08"),
                UserId = userOne.Id 
            };

            var verlofTicketTwo = new Verlof
            {
                Naam = "Tandarts",
                Omschrijving = "Tandarts afspraak",
                BeginDatum = DateTime.Parse("2022-11-09"),
                EindDatum = DateTime.Parse("2022-11-10"),
                UserId = userTwo.Id
            };

            context.Verlof.Add(verlofTicketOne);
            context.Verlof.Add(verlofTicketTwo);
            context.SaveChanges();

            var VerlofSoort = new VerlofSoort[]
            {
                new VerlofSoort{Naam="Huisarts", VerlofId = verlofTicketOne.Id },
                new VerlofSoort{Naam="Tandarts", VerlofId = verlofTicketTwo.Id }
            };

            context.VerlofSoort.AddRange(VerlofSoort);
            context.SaveChanges();
        }
    }
}
