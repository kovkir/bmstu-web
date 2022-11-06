using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceClub
    {
        [Fact]
        public void TestClubByName()
        {
            IClubRepository clubRepository = new ClubMock();
            IClubService clubService = new ClubService(clubRepository);

            Club correctClub = new Club
            {
                Id = 1,
                Name = "Paris Saint-Germain",
                Country = "France",
                FoundationDate = 1970
            };

            Club currentClub = clubService.GetByName("Paris Saint-Germain");

            Assert.Equal(correctClub.Name, currentClub.Name);
            Assert.Equal(correctClub.Country, currentClub.Country);
            Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
        }

        [Fact]
        public void TestClubByCountry()
        {
            IClubRepository clubRepository = new ClubMock();
            IClubService clubService = new ClubService(clubRepository);

            Club correctClub = new Club
            {
                Id = 2,
                Name = "Manchester United",
                Country = "England",
                FoundationDate = 1878
            };

            IEnumerable<Club> currentClubs = clubService.GetByCountry("England");

            foreach (Club currentClub in currentClubs)
            {
                Assert.Equal(correctClub.Name, currentClub.Name);
                Assert.Equal(correctClub.Country, currentClub.Country);
                Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
            }
        }

        [Fact]
        public void TestClubByFoundationDate()
        {
            IClubRepository clubRepository = new ClubMock();
            IClubService clubService = new ClubService(clubRepository);

            Club correctClub = new Club
            {
                Id = 2,
                Name = "Manchester United",
                Country = "England",
                FoundationDate = 1878
            };

            IEnumerable<Club> currentClubs = clubService.GetByFoundationDate(1878);

            foreach (Club currentClub in currentClubs)
            {
                Assert.Equal(correctClub.Name, currentClub.Name);
                Assert.Equal(correctClub.Country, currentClub.Country);
                Assert.Equal(correctClub.FoundationDate, currentClub.FoundationDate);
            }
        }
    }
}
