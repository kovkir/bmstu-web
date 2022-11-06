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
    public class UnitTestPlayer
    {
        [Fact]
        public void TestPlayerGetById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Player.Add(new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                PlayerRepository playerRepository = new PlayerRepository(context);
                Player player = playerRepository.GetByID(1);

                Assert.Equal(1, player.Id);
                Assert.Equal(1, player.ClubId);
                Assert.Equal("Messi", player.Surname);
                Assert.Equal((uint)93, player.Rating);
                Assert.Equal("Argentina", player.Country);
                Assert.Equal((uint)250000, player.Price);
            }
        }

        [Fact]
        public void TestPlayerAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player correctPlayer = new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                };

                playerRepository.Add(correctPlayer);
                Player currentPlayer = context.Player.Find(1);

                Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                Assert.Equal(correctPlayer.Price, currentPlayer.Price);
            }
        }

        [Fact]
        public void TestPlayerUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Player.Add(new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player correctPlayer = new Player
                {
                    Id = 1,
                    ClubId = 2,
                    Surname = "Ronaldo",
                    Rating = 91,
                    Country = "Portugal",
                    Price = 110000
                };

                playerRepository.Update(correctPlayer);
                Player currentPlayer = context.Player.Find(1);

                Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                Assert.Equal(correctPlayer.Price, currentPlayer.Price);
            }
        }

        [Fact]
        public void TestPlayerBySurname()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Player.Add(new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player correctPlayer = new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                };

                IEnumerable<Player> currentPlayers = playerRepository.GetBySurname("Messi");

                foreach (Player currentPlayer in currentPlayers)
                {
                    Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                    Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                    Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                    Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                    Assert.Equal(correctPlayer.Price, currentPlayer.Price);
                }
            }
        }

        [Fact]
        public void TestPlayerByRating()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Player.Add(new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player correctPlayer = new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                };

                IEnumerable<Player> currentPlayers = playerRepository.GetByRating(93);

                foreach (Player currentPlayer in currentPlayers)
                {
                    Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                    Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                    Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                    Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                    Assert.Equal(correctPlayer.Price, currentPlayer.Price);
                }
            }
        }

        [Fact]
        public void TestPlayerByCountry()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Player.Add(new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player correctPlayer = new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                };

                IEnumerable<Player> currentPlayers = playerRepository.GetByCountry("Argentina");

                foreach (Player currentPlayer in currentPlayers)
                {
                    Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                    Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                    Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                    Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                    Assert.Equal(correctPlayer.Price, currentPlayer.Price);
                }
            }
        }

        [Fact]
        public void TestPlayerByPrice()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Player.Add(new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                PlayerRepository playerRepository = new PlayerRepository(context);

                Player correctPlayer = new Player
                {
                    Id = 1,
                    ClubId = 1,
                    Surname = "Messi",
                    Rating = 93,
                    Country = "Argentina",
                    Price = 250000
                };

                IEnumerable<Player> currentPlayers = playerRepository.GetByPrice(200000, 300000);

                foreach (Player currentPlayer in currentPlayers)
                {
                    Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                    Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                    Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                    Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                    Assert.Equal(correctPlayer.Price, currentPlayer.Price);
                }
            }
        }
    }
}
