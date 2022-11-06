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
    public class UnitTestCoach
    {
        [Fact]
        public void TestCoachGetById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Coach.Add(new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                CoachRepository coachRepository = new CoachRepository(context);
                Coach coach = coachRepository.GetByID(1);

                Assert.Equal(1, coach.Id);
                Assert.Equal("Guardiola", coach.Surname);
                Assert.Equal("Spain", coach.Country);
                Assert.Equal((uint)15, coach.WorkExperience);
            }
        }

        [Fact]
        public void TestCoachAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                CoachRepository coachRepository = new CoachRepository(context);

                Coach correctCoach = new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                };

                coachRepository.Add(correctCoach);
                Coach currentCoach = context.Coach.Find(1);

                Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                Assert.Equal(correctCoach.Country, currentCoach.Country);
                Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
            }
        }

        [Fact]
        public void TestCoachUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Coach.Add(new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                CoachRepository coachRepository = new CoachRepository(context);

                Coach correctCoach = new Coach
                {
                    Id = 1,
                    Surname = "Klopp",
                    Country = "Germany",
                    WorkExperience = 21
                };

                coachRepository.Update(correctCoach);
                Coach currentCoach = context.Coach.Find(1);

                Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                Assert.Equal(correctCoach.Country, currentCoach.Country);
                Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
            }
        }

        [Fact]
        public void TestCoachBySurname()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Coach.Add(new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                CoachRepository coachRepository = new CoachRepository(context);

                Coach correctCoach = new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                };

                IEnumerable<Coach> currentCoaches = coachRepository.GetBySurname("Guardiola");

                foreach (Coach currentCoach in currentCoaches)
                {
                    Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                    Assert.Equal(correctCoach.Country, currentCoach.Country);
                    Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
                }
            }
        }

        [Fact]
        public void TestCoachByCountry()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Coach.Add(new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                CoachRepository coachRepository = new CoachRepository(context);

                Coach correctCoach = new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                };

                IEnumerable<Coach> currentCoaches = coachRepository.GetByCountry("Spain");

                foreach (Coach currentCoach in currentCoaches)
                {
                    Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                    Assert.Equal(correctCoach.Country, currentCoach.Country);
                    Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
                }
            }
        }

        [Fact]
        public void TestCoachByWorkExperience()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Coach.Add(new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                CoachRepository coachRepository = new CoachRepository(context);

                Coach correctCoach = new Coach
                {
                    Id = 1,
                    Surname = "Guardiola",
                    Country = "Spain",
                    WorkExperience = 15
                };

                IEnumerable<Coach> currentCoaches = coachRepository.GetByWorkExperience(15);

                foreach (Coach currentCoach in currentCoaches)
                {
                    Assert.Equal(correctCoach.Surname, currentCoach.Surname);
                    Assert.Equal(correctCoach.Country, currentCoach.Country);
                    Assert.Equal(correctCoach.WorkExperience, currentCoach.WorkExperience);
                }
            }
        }
    }
}
