using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceCoach
    {
        [Fact]
        public void TestCoachBySurname()
        {
            ICoachRepository coachRepository = new CoachMock();
            ICoachService coachService = new CoachService(coachRepository);

            Coach correctCoach = new Coach
            {
                Id = 1,
                Surname = "Guardiola",
                Country = "Spain",
                WorkExperience = 15
            };

            IEnumerable<Coach> currentCoaches = coachService.GetBySurname("Guardiola");

            foreach (Coach currentCoach in currentCoaches)
            {
                Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                Assert.Equal(correctCoach.Country, currentCoach.Country);
                Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
            }
        }

        [Fact]
        public void TestCoachByCountry()
        {
            ICoachRepository coachRepository = new CoachMock();
            ICoachService coachService = new CoachService(coachRepository);

            Coach correctCoach = new Coach
            {
                Id = 1,
                Surname = "Guardiola",
                Country = "Spain",
                WorkExperience = 15
            };

            IEnumerable<Coach> currentCoaches = coachService.GetByCountry("Spain");

            foreach (Coach currentCoach in currentCoaches)
            {
                Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                Assert.Equal(correctCoach.Country, currentCoach.Country);
                Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
            }
        }

        [Fact]
        public void TestCoachByWorkExperience()
        {
            ICoachRepository coachRepository = new CoachMock();
            ICoachService coachService = new CoachService(coachRepository);

            Coach correctCoach = new Coach
            {
                Id = 1,
                Surname = "Guardiola",
                Country = "Spain",
                WorkExperience = 15
            };

            IEnumerable<Coach> currentCoaches = coachService.GetByWorkExperience(15);

            foreach (Coach currentCoach in currentCoaches)
            {
                Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                Assert.Equal(correctCoach.Country, currentCoach.Country);
                Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
            }
        }
    }
}
