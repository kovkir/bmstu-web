using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceSquad
    {
        [Fact]
        public void TestSquadByName()
        {
            ISquadRepository squadRepository = new SquadMock();
            ICoachRepository coachRepository = new CoachMock();
            IUserRepository userRepository = new UserMock();

            ISquadService squadService = new SquadService(squadRepository, coachRepository, userRepository);

            Squad correctSquad = new Squad
            {
                Id = 3,
                CoachId = 3,
                Name = "Pink Rabbit",
                Rating = 86
            };

            Squad currentSquad = squadService.GetByName("Pink Rabbit");

            Assert.Equal(correctSquad.CoachId, currentSquad.CoachId);
            Assert.Equal(correctSquad.Name, currentSquad.Name);
            Assert.Equal(correctSquad.Rating, currentSquad.Rating);
        }

        [Fact]
        public void TestSquadByRating()
        {
            ISquadRepository squadRepository = new SquadMock();
            ICoachRepository coachRepository = new CoachMock();
            IUserRepository userRepository = new UserMock();

            ISquadService squadService = new SquadService(squadRepository, coachRepository, userRepository);

            Squad correctSquad = new Squad
            {
                Id = 3,
                CoachId = 3,
                Name = "Pink Rabbit",
                Rating = 86
            };

            IEnumerable<Squad> currentSquads = squadService.GetByRating(86);

            foreach (Squad currentSquad in currentSquads)
            {
                Assert.Equal(correctSquad.CoachId, currentSquad.CoachId);
                Assert.Equal(correctSquad.Name, currentSquad.Name);
                Assert.Equal(correctSquad.Rating, currentSquad.Rating);
            }
        }
    }
}
