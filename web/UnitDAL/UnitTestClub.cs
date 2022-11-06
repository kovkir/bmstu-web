using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using db_cp.Models;
using db_cp.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitDAL
{
    public class UnitTestClub
    {
        [Fact]
        public void TestClubGetById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Club.Add(new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                ClubRepository clubRepository = new ClubRepository(context);
                var club = clubRepository.GetByID(1);

                Assert.Equal(1, club.Id);
                Assert.Equal("Paris Saint-Germain", club.Name);
                Assert.Equal("France", club.Country);
                Assert.Equal((uint) 1970, club.FoundationDate);
            }
        }

        [Fact]
        public void TestClubAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                ClubRepository clubRepository = new ClubRepository(context);

                Club correctClub = new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                };

                clubRepository.Add(correctClub);
                Club currentClub = context.Club.Find(1);

                Assert.Equal(correctClub.Name, currentClub.Name);
                Assert.Equal(correctClub.Country, currentClub.Country);
                Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
            }
        }

        [Fact]
        public void TestClubUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Club.Add(new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                ClubRepository clubRepository = new ClubRepository(context);

                Club correctClub = new Club
                {
                    Id = 1,
                    Name = "Manchester United",
                    Country = "England",
                    FoundationDate = 1878
                };

                clubRepository.Update(correctClub);
                Club currentClub = context.Club.Find(1);

                Assert.Equal(correctClub.Name, currentClub.Name);
                Assert.Equal(correctClub.Country, currentClub.Country);
                Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
            }
        }

        [Fact]
        public void TestClubByName()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Club.Add(new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                ClubRepository clubRepository = new ClubRepository(context);

                Club correctClub = new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                };

                Club currentClub = clubRepository.GetByName("Paris Saint-Germain");

                Assert.Equal(correctClub.Id, currentClub.Id);
                Assert.Equal(correctClub.Name, currentClub.Name);
                Assert.Equal(correctClub.Country, currentClub.Country);
                Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
            }
        }

        [Fact]
        public void TestClubByCountry()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Club.Add(new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                ClubRepository clubRepository = new ClubRepository(context);

                Club correctClub = new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                };

                IEnumerable<Club> currentClubs = clubRepository.GetByCountry("Paris Saint-Germain");

                foreach (Club currentClub in currentClubs)
                {
                    Assert.Equal(correctClub.Id, currentClub.Id);
                    Assert.Equal(correctClub.Name, currentClub.Name);
                    Assert.Equal(correctClub.Country, currentClub.Country);
                    Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
                }
            }
        }

        [Fact]
        public void TestClubByFoundationDate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Club.Add(new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                ClubRepository clubRepository = new ClubRepository(context);

                Club correctClub = new Club
                {
                    Id = 1,
                    Name = "Paris Saint-Germain",
                    Country = "France",
                    FoundationDate = 1970
                };

                IEnumerable<Club> currentClubs = clubRepository.GetByFoundationDate(1970);

                foreach (Club currentClub in currentClubs)
                {
                    Assert.Equal(correctClub.Id, currentClub.Id);
                    Assert.Equal(correctClub.Name, currentClub.Name);
                    Assert.Equal(correctClub.Country, currentClub.Country);
                    Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
                }
            }
        }
    }
}
