using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceUser
    {
        [Fact]
        public void TestUserByLogin()
        {
            IUserRepository userRepository = new UserMock();
            ISquadRepository squadRepository = new SquadMock();

            IUserService userService = new UserService(userRepository, squadRepository);

            User correctUser = new User
            {
                Id = 1,
                Login = "aaa",
                Password = "111",
                Permission = "admin"
            };

            User currentUser = userService.GetByLogin("aaa");

            Assert.Equal(correctUser.Login, currentUser.Login);
            Assert.Equal(correctUser.Password, currentUser.Password);
            Assert.Equal(correctUser.Permission, currentUser.Permission);
        }

        [Fact]
        public void TestUserByPermission()
        {
            IUserRepository userRepository = new UserMock();
            ISquadRepository squadRepository = new SquadMock();

            IUserService userService = new UserService(userRepository, squadRepository);

            User correctUser = new User
            {
                Id = 1,
                Login = "aaa",
                Password = "111",
                Permission = "admin"
            };

            IEnumerable<User> currentUsers = userService.GetByPermission("admin");

            foreach (User currentUser in currentUsers)
            {
                Assert.Equal(correctUser.Login, currentUser.Login);
                Assert.Equal(correctUser.Password, currentUser.Password);
                Assert.Equal(correctUser.Permission, currentUser.Permission);
            }
        }
    }
}
