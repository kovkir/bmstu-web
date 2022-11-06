using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServicePlayer
    {
        [Fact]
        public void TestPlayerBySurname()
        {
            IPlayerRepository playerRepository = new PlayerMock();
            IClubRepository clubRepository = new ClubMock();
            ISquadRepository squadRepository = new SquadMock();

            IPlayerService playerService = new PlayerService(playerRepository, clubRepository, squadRepository);

            Player correctPlayer = new Player
            {
                Id = 1,
                ClubId = 1,
                Surname = "Messi",
                Rating = 93,
                Country = "Argentina",
                Price = 250000
            };

            IEnumerable<Player> currentPlayers = playerService.GetBySurname("Messi");

            foreach (Player currentPlayer in currentPlayers)
            {
                Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                Assert.Equal(correctPlayer.Price, currentPlayer.Price);
            }
        }

        [Fact]
        public void TestPlayerByRating()
        {
            IPlayerRepository playerRepository = new PlayerMock();
            IClubRepository clubRepository = new ClubMock();
            ISquadRepository squadRepository = new SquadMock();

            IPlayerService playerService = new PlayerService(playerRepository, clubRepository, squadRepository);

            Player correctPlayer = new Player
            {
                Id = 1,
                ClubId = 1,
                Surname = "Messi",
                Rating = 93,
                Country = "Argentina",
                Price = 250000
            };

            IEnumerable<Player> currentPlayers = playerService.GetByRating(93);

            foreach (Player currentPlayer in currentPlayers)
            {
                Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                Assert.Equal(correctPlayer.Price, currentPlayer.Price);
            }
        }

        [Fact]
        public void TestPlayerByCountry()
        {
            IPlayerRepository playerRepository = new PlayerMock();
            IClubRepository clubRepository = new ClubMock();
            ISquadRepository squadRepository = new SquadMock();

            IPlayerService playerService = new PlayerService(playerRepository, clubRepository, squadRepository);

            Player correctPlayer = new Player
            {
                Id = 1,
                ClubId = 1,
                Surname = "Messi",
                Rating = 93,
                Country = "Argentina",
                Price = 250000
            };

            IEnumerable<Player> currentPlayers = playerService.GetByCountry("Argentina");

            foreach (Player currentPlayer in currentPlayers)
            {
                Assert.Equal(correctPlayer.ClubId, currentPlayer.ClubId);
                Assert.Equal(correctPlayer.Surname, currentPlayer.Surname);
                Assert.Equal(correctPlayer.Rating, currentPlayer.Rating);
                Assert.Equal(correctPlayer.Country, currentPlayer.Country);
                Assert.Equal(correctPlayer.Price, currentPlayer.Price);
            }
        }

        [Fact]
        public void TestPlayerByPrice()
        {
            IPlayerRepository playerRepository = new PlayerMock();
            IClubRepository clubRepository = new ClubMock();
            ISquadRepository squadRepository = new SquadMock();

            IPlayerService playerService = new PlayerService(playerRepository, clubRepository, squadRepository);

            Player correctPlayer = new Player
            {
                Id = 1,
                ClubId = 1,
                Surname = "Messi",
                Rating = 93,
                Country = "Argentina",
                Price = 250000
            };

            IEnumerable<Player> currentPlayers = playerService.GetByPrice(200000, 300000);

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
