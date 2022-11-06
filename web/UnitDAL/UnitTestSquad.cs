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
    public class UnitTestSquad
    {
        [Fact]
        public void TestSquadGetById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Squad.Add(new Squad
                {
                    Id = 3,
                    CoachId = 3,
                    Name = "Pink Rabbit",
                    Rating = 86
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                SquadRepository squadRepository = new SquadRepository(context);
                Squad squad = squadRepository.GetByID(3);

                Assert.Equal(3, squad.Id);
                Assert.Equal(3, squad.CoachId);
                Assert.Equal("Pink Rabbit", squad.Name);
                Assert.Equal((uint)86, squad.Rating);
            }
        }

        [Fact]
        public void TestSquadAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                SquadRepository squadRepository = new SquadRepository(context);

                Squad correctSquad = new Squad
                {
                    Id = 3,
                    CoachId = 3,
                    Name = "Pink Rabbit",
                    Rating = 86
                };

                squadRepository.Add(correctSquad);
                Squad currentSquad = context.Squad.Find(3);

                Assert.Equal(correctSquad.CoachId, currentSquad.CoachId);
                Assert.Equal(correctSquad.Name, currentSquad.Name);
                Assert.Equal(correctSquad.Rating, currentSquad.Rating);
            }
        }

        [Fact]
        public void TestSquadUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Squad.Add(new Squad
                {
                    Id = 3,
                    CoachId = 3,
                    Name = "Pink Rabbit",
                    Rating = 86
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                SquadRepository squadRepository = new SquadRepository(context);

                Squad correctSquad = new Squad
                {
                    Id = 3,
                    CoachId = 1,
                    Name = "Legend 17",
                    Rating = 90
                };

                squadRepository.Update(correctSquad);
                Squad currentSquad = context.Squad.Find(3);

                Assert.Equal(correctSquad.CoachId, currentSquad.CoachId);
                Assert.Equal(correctSquad.Name, currentSquad.Name);
                Assert.Equal(correctSquad.Rating, currentSquad.Rating);
            }
        }

        [Fact]
        public void TestSquadByName()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Squad.Add(new Squad
                {
                    Id = 3,
                    CoachId = 3,
                    Name = "Pink Rabbit",
                    Rating = 86
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                SquadRepository squadRepository = new SquadRepository(context);

                Squad correctSquad = new Squad
                {
                    Id = 3,
                    CoachId = 3,
                    Name = "Pink Rabbit",
                    Rating = 86
                };

                Squad currentSquad = squadRepository.GetByName("Pink Rabbit");

                Assert.Equal(correctSquad.CoachId, currentSquad.CoachId);
                Assert.Equal(correctSquad.Name, currentSquad.Name);
                Assert.Equal(correctSquad.Rating, currentSquad.Rating);
            }
        }

        [Fact]
        public void TestSquadByRating()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Squad.Add(new Squad
                {
                    Id = 3,
                    CoachId = 3,
                    Name = "Pink Rabbit",
                    Rating = 86
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                SquadRepository squadRepository = new SquadRepository(context);

                Squad correctSquad = new Squad
                {
                    Id = 3,
                    CoachId = 3,
                    Name = "Pink Rabbit",
                    Rating = 86
                };

                IEnumerable<Squad> currentSquads = squadRepository.GetByRating(86);

                foreach (Squad currentSquad in currentSquads)
                {
                    Assert.Equal(correctSquad.CoachId, currentSquad.CoachId);
                    Assert.Equal(correctSquad.Name, currentSquad.Name);
                    Assert.Equal(correctSquad.Rating, currentSquad.Rating);
                }
            }
        }
    }
}
