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
    public class UnitTestUser
    {
        [Fact]
        public void TestUserGetById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.User.Add(new User
                {
                    Id = 1,
                    Login = "aaa",
                    Password = "111",
                    Permission = "admin"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                UserRepository userRepository = new UserRepository(context);
                User user = userRepository.GetByID(1);

                Assert.Equal(1, user.Id);
                Assert.Equal("aaa", user.Login);
                Assert.Equal("111", user.Password);
                Assert.Equal("admin", user.Permission);
            }
        }

        [Fact]
        public void TestUserAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                UserRepository userRepository = new UserRepository(context);

                User correctUser = new User
                {
                    Id = 1,
                    Login = "aaa",
                    Password = "111",
                    Permission = "admin"
                };

                userRepository.Add(correctUser);
                User currentUser = context.User.Find(1);

                Assert.Equal(correctUser.Login, currentUser.Login);
                Assert.Equal(correctUser.Password, currentUser.Password);
                Assert.Equal(correctUser.Permission, currentUser.Permission);
            }
        }

        [Fact]
        public void TestUserUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.User.Add(new User
                {
                    Id = 1,
                    Login = "aaa",
                    Password = "111",
                    Permission = "admin"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                UserRepository userRepository = new UserRepository(context);

                User correctUser = new User
                {
                    Id = 1,
                    Login = "bbb",
                    Password = "222",
                    Permission = "user"
                };

                userRepository.Update(correctUser);
                User currentUser = context.User.Find(1);

                Assert.Equal(correctUser.Login, currentUser.Login);
                Assert.Equal(correctUser.Password, currentUser.Password);
                Assert.Equal(correctUser.Permission, currentUser.Permission);
            }
        }

        [Fact]
        public void TestUserByLogin()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.User.Add(new User
                {
                    Id = 1,
                    Login = "aaa",
                    Password = "111",
                    Permission = "admin"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                UserRepository userRepository = new UserRepository(context);

                User correctUser = new User
                {
                    Id = 1,
                    Login = "aaa",
                    Password = "111",
                    Permission = "admin"
                };

                User currentUser = userRepository.GetByLogin("aaa");

                Assert.Equal(correctUser.Login, currentUser.Login);
                Assert.Equal(correctUser.Password, currentUser.Password);
                Assert.Equal(correctUser.Permission, currentUser.Permission);
            }
        }

        [Fact]
        public void TestUserByPermission()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.User.Add(new User
                {
                    Id = 1,
                    Login = "aaa",
                    Password = "111",
                    Permission = "admin"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                UserRepository userRepository = new UserRepository(context);

                User correctUser = new User
                {
                    Id = 1,
                    Login = "aaa",
                    Password = "111",
                    Permission = "admin"
                };

                IEnumerable<User> currentUsers = userRepository.GetByPermission("admin");

                foreach (User currentUser in currentUsers)
                {
                    Assert.Equal(correctUser.Login, currentUser.Login);
                    Assert.Equal(correctUser.Password, currentUser.Password);
                    Assert.Equal(correctUser.Permission, currentUser.Permission);
                }
            }
        }
    }
}
