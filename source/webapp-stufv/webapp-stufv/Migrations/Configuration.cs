namespace webapp_stufv.Migrations {
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    internal sealed class Configuration : DbMigrationsConfiguration<webapp_stufv.Models.STUFVModelContext> {
        public Configuration( ) {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed( webapp_stufv.Models.STUFVModelContext context ) {
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
                new UserTypes {
                    Id = 1,
                    Description = "Admin"
                },
                new UserTypes {
                    Id = 2,
                    Description = "User"
                }
                );

            context.Cities.AddOrUpdate(
                new Cities {
                    ZipCode = "3840",
                    City = "Borgloon"
                },
                new Cities {
                    ZipCode = "3600",
                    City = "Hasselt"
                }
                );

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider( );
            String salt = GenerateRandomSalt( rng, 16 );
            String encPass = MD5Encrypt( "123", salt );

            for ( int i = 1 ; i <= 30 ; i++ ) {
                context.Users.AddOrUpdate(
                    new User {
                        Id = i,
                        Active = true,
                        BirthDate = GenererateRandomDate( 1950, 2016 ),
                        BirthPlace = "Hasselt",
                        Email = "test" + i + "@test.com",
                        FirstName = "test" + i,
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
                        RegisterDate = GenererateRandomDate( 2010, 2017 )
                    } );
                context.ProfileSettings.AddOrUpdate(
                    new ProfileSettings {
                        UserId = i,
                        Email = true,
                        FirstName = true,
                        LastName = true,
                        BirthDate = true,
                        Street = true,
                        ZipCode = true,
                        MobileNr = true,
                        TelNr = true,
                    });
            }

            for ( int i = 1 ; i <= 10 ; i++ ) {
                context.EventTypes.AddOrUpdate(
                    new EventTypes {
                        Id = i,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                    } );
            }

            for ( int i = 1 ; i <= 30 ; i++ ) {
                context.Articles.AddOrUpdate(
                    new Article {
                        Id = i,
                        Active = true,
                        Title = "Lorem Ipsum",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                        DateTime = GenererateRandomDate( 2010, 2017 ),
                        ThumbsUp = 0,
                        UserId = i,
                        imgLink = "https://scontent-amt2-1.xx.fbcdn.net/t31.0-8/s960x960/13308529_10209788524855093_7854628716781566876_o.jpg"
                    } );
            }

            context.Organisations.AddOrUpdate(
                    new Organisation
                    {
                        Id = 1,
                        Active = true,
                        Name = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                        isRegistered = true,
                        RegisterDate = GenererateRandomDate(2010, 2017),
                        UserId = 1
                    });
            context.Organisations.AddOrUpdate(
                    new Organisation
                    {
                        Id = 2,
                        Active = true,
                        Name = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                        isRegistered = true,
                        RegisterDate = GenererateRandomDate(2010, 2017),
                        UserId = 1
                    });
            context.Organisations.AddOrUpdate(
                    new Organisation
                    {
                        Id = 3,
                        Active = true,
                        Name = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                        isRegistered = true,
                        RegisterDate = GenererateRandomDate(2010, 2017),
                        UserId = 1
                    });
            context.Organisations.AddOrUpdate(
                    new Organisation
                    {
                        Id = 4,
                        Active = true,
                        Name = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                        isRegistered = false,
                        RegisterDate = GenererateRandomDate(2010, 2017),
                        UserId = 1
                    });
            context.Organisations.AddOrUpdate(
                    new Organisation
                    {
                        Id = 5,
                        Active = true,
                        Name = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                        isRegistered = false,
                        RegisterDate = GenererateRandomDate(2010, 2017),
                        UserId = 1
                    });

            for ( int i = 1 ; i <= 30 ; i++ ) {
                Random rand = new Random( );
                DateTime startDate = GenererateRandomDate( 2016, 2020 );
                context.Events.AddOrUpdate(
                    new Event {
                        Id = i,
                        Active = true,
                        AlcoholFree = true,
                        Name = "Lorem Ipsum",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tincidunt euismod dolor, eu dignissim tortor eleifend a. Mauris ac laoreet arcu, ut condimentum nibh. Ut ullamcorper laoreet eros et commodo. Ut a risus quis justo mollis facilisis. Aliquam et turpis ut tellus pharetra malesuada quis nec risus. Curabitur aliquet porta neque vel maximus. Sed vel mi sit amet risus molestie sollicitudin ut at ex. Donec tincidunt ante nec nunc rutrum elementum.",
                        End = startDate.AddDays( rand.Next( 1, 11 ) ),
                        Start = startDate,
                        EntranceFee = rand.Next( 0, 101 ),
                        OrganisationId = rand.Next( 1, 11 ),
                        ZipCode = "3840",
                        Type = 1,
                        Street = "Stationstraat 4",
                        RegisterDate = GenererateRandomDate( 2010, 2017 ),
                        Image = "noimageavailable.png"
                    } );
            }

            for ( int i = 1 ; i <= 10 ; i++ ) {
                context.Tips.AddOrUpdate(
                    new Tip {
                        Id = i,
                        Active = true,
                        TipText = "Tip " + i
                    } );
            }

        }

        private string GenerateRandomSalt( RNGCryptoServiceProvider rng, int size ) {
            var bytes = new Byte[ size ];
            rng.GetBytes( bytes );
            return Convert.ToBase64String( bytes );
        }
        private static string MD5Encrypt( string password, string salt ) {
            MD5 md5 = new MD5CryptoServiceProvider( );

            md5.ComputeHash( ASCIIEncoding.ASCII.GetBytes( salt + password ) );
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder( );
            for ( int i = 0 ; i < result.Length ; i++ ) {
                strBuilder.Append( result[ i ].ToString( "x2" ) );
            }

            return strBuilder.ToString( );
        }
        private DateTime GenererateRandomDate( int startYear, int endYear ) {
            Random rnd = new Random( );

            int year = rnd.Next( startYear, endYear );
            int month = rnd.Next( 1, 12 );
            int day = DateTime.DaysInMonth( year, month );

            int Day = rnd.Next( 1, day );

            DateTime dt = new DateTime( year, month, Day );
            return dt;
        }
    }
}
