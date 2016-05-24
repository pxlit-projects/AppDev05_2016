namespace webapp_stufv.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<webapp_stufv.Models.STUFVModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(webapp_stufv.Models.STUFVModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.UserTypes.AddOrUpdate(
                new UserTypes
                {
                    Id = 1,
                    Description = "Admin"
                },
                new UserTypes
                {
                    Id = 2,
                    Description = "User"
                }
                );

            context.Cities.AddOrUpdate(
                new Cities
                {
                    ZipCode = "3840",
                    City = "Borgloon"
                },
                new Cities
                {
                    ZipCode = "3600",
                    City = "Hasselt"
                }
                );

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            String salt = GenerateRandomSalt(rng, 16);
            String encPass = MD5Encrypt("123", salt);

            context.Users.AddOrUpdate(
                new User
                {
                    Id = 1,
                    Active = true,
                    BirthDate = DateTime.Parse("14-03-1996"),
                    BirthPlace = "Hasselt",
                    Email = "test@test.com",
                    FirstName = "test",
                    LastName = "test",
                    MobileNr = "0485199853",
                    RoleID = 1,
                    Sex = "M",
                    Street = "Stationstraat 32",
                    ZipCode = "3840",
                    TelNr = "012747032",
                    PassWord = encPass,
                    Salt = salt,
                    ProfilePicture = "noimageavailable.png",
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42")
                },
                new User
                {
                    Id = 2,
                    Active = true,
                    BirthDate = DateTime.Parse("14-03-1996"),
                    BirthPlace = "Tongeren",
                    Email = "test@user.com",
                    FirstName = "test",
                    LastName = "test",
                    MobileNr = "0485199853",
                    RoleID = 2,
                    Sex = "V",
                    Street = "Teststraat 32",
                    ZipCode = "3600",
                    TelNr = "012747032",
                    PassWord = encPass,
                    Salt = salt,
                    ProfilePicture = "noimageavailable.png",
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42")
                }
                );

            context.Articles.AddOrUpdate(
                new Article
                {
                    Active = true,
                    Title = "Artikel 1",
                    Content = "Dit is artikel 1",
                    DateTime = DateTime.Parse("14-03-1996"),
                    ThumbsUp = 0,
                    UserId = 1
                },
                new Article
                {
                    Active = true,
                    Title = "Artikel 2",
                    Content = "Dit is artikel 2",
                    DateTime = DateTime.Parse("14-03-1996"),
                    ThumbsUp = 0,
                    UserId = 1
                },
                new Article
                {
                    Active = true,
                    Title = "Artikel 3",
                    Content = "Dit is artikel 3",
                    DateTime = DateTime.Parse("14-03-1996"),
                    ThumbsUp = 0,
                    UserId = 1
                },
                new Article
                {
                    Active = true,
                    Title = "Artikel 4",
                    Content = "Dit is artikel 4",
                    DateTime = DateTime.Parse("14-03-1996"),
                    ThumbsUp = 0,
                    UserId = 1
                }
                );

            context.Organisations.AddOrUpdate(
                new Organisation
                {
                    Id = 1,
                    Active = true,
                    Name = "Testorganisatie 1",
                    Description = "Wij zijn een testorganisatie",
                    isRegistered = true,
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42"),
                    UserId = 1
                },
                new Organisation
                {
                    Id = 2,
                    Active = false,
                    Name = "Testorganisatie 2",
                    Description = "Wij zijn een testorganisatie",
                    isRegistered = false,
                    UserId = 2
                }
                );

            context.EventTypes.AddOrUpdate(
                new EventTypes
                {
                    Id = 1,
                    Description = "Feestje"
                }
                );

            context.Events.AddOrUpdate(
                new Event
                {
                    Active = true,
                    AlcoholFree = true,
                    Name = "Event 1",
                    Description = "Dit is een vette event",
                    End = DateTime.Parse("14-03-1996").AddDays(1),
                    Start = DateTime.Parse("14-03-1996"),
                    EntranceFee = 5,
                    OrganisationId = 1,
                    ZipCode = "3840",
                    Type = 1,
                    Street = "Stationstraat 4",
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42")
                },
                new Event
                {
                    Active = true,
                    AlcoholFree = false,
                    Name = "Event 2",
                    Description = "Dit is een vette event",
                    End = DateTime.Parse("14-03-1996").AddDays(1),
                    Start = DateTime.Parse("14-03-1996"),
                    EntranceFee = 5,
                    OrganisationId = 1,
                    ZipCode = "3600",
                    Type = 1,
                    Street = "Stationstraat 42",
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42")
                },
                new Event
                {
                    Active = true,
                    AlcoholFree = false,
                    Name = "Event 3",
                    Description = "Dit is een vette event",
                    End = DateTime.Parse("14-03-1996").AddDays(1),
                    Start = DateTime.Parse("14-03-1996"),
                    EntranceFee = 5,
                    OrganisationId = 1,
                    ZipCode = "3600",
                    Type = 1,
                    Street = "Stationstraat 42",
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42")
                },
                new Event
                {
                    Active = true,
                    AlcoholFree = true,
                    Name = "Event 4",
                    Description = "Dit is een vette event",
                    End = DateTime.Parse("14-03-1996").AddDays(1),
                    Start = DateTime.Parse("14-03-1996"),
                    EntranceFee = 5,
                    OrganisationId = 1,
                    ZipCode = "3600",
                    Type = 1,
                    Street = "Stationstraat 42",
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42")
                },
                new Event
                {
                    Active = true,
                    AlcoholFree = false,
                    Name = "Event 5",
                    Description = "Dit is een vette event",
                    End = DateTime.Parse("14-03-1996").AddDays(1),
                    Start = DateTime.Parse("14-03-1996"),
                    EntranceFee = 5,
                    OrganisationId = 1,
                    ZipCode = "3600",
                    Type = 1,
                    Street = "Stationstraat 42",
                    RegisterDate = Convert.ToDateTime("24/05/2016 14:50:50.42")
                }
                );

            context.Tips.AddOrUpdate(
                new Tip
                {
                    Active = true,
                    TipText = "Tip 1"
                },
                new Tip
                {
                    Active = true,
                    TipText = "Tip 2"
                },
                new Tip
                {
                    Active = true,
                    TipText = "Tip 3"
                }
                );
        }

        private string GenerateRandomSalt(RNGCryptoServiceProvider rng, int size)
        {
            var bytes = new Byte[size];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
        private static string MD5Encrypt(string password, string salt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(salt + password));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
