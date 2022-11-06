using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_cp.ViewModels;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using Microsoft.AspNetCore.Mvc;
using db_cp.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace db_cp.Controllers
{
    public class UserController : Controller
    {
        //static private IUserRepository userRepository = new UserMock();
        //static private ISquadRepository squdRepository = new SquadMock();

        //private IUserService userService = new UserService(userRepository);
        //private ISquadService squadService = new SquadService(squdRepository);

        private IUserService userService;
        private ISquadService squadService;
        private readonly ILogger<AccountController> logger;

        public UserController(IUserService userService,
                              ISquadService squadService,
                              ILogger<AccountController> logger)
        {
            this.userService = userService;
            this.squadService = squadService;
            this.logger = logger;
        }

        public IActionResult GetAllUsers(UserSortState sortOrder = UserSortState.IdAsc)
        {
            ViewBag.Title = "Users";

            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
                User.Identity.Name,
                MethodBase.GetCurrentMethod().Name);

            ViewData["IdSort"]          = sortOrder == UserSortState.IdAsc          ? UserSortState.IdDesc          : UserSortState.IdAsc;
            ViewData["LoginSort"]       = sortOrder == UserSortState.LoginAsc       ? UserSortState.LoginDesc       : UserSortState.LoginAsc;
            ViewData["PermissionSort"]  = sortOrder == UserSortState.PermissionAsc  ? UserSortState.PermissionDesc  : UserSortState.PermissionAsc;
            ViewData["RatingSquadSort"] = sortOrder == UserSortState.RatingSquadAsc ? UserSortState.RatingSquadDesc : UserSortState.RatingSquadAsc;

            var allUsers = new UserViewModel
            {
                squads = squadService.GetAll(),
                users = userService.GetSortUsersByOrder(sortOrder)
            };

            return View(allUsers);
        }

        public IActionResult СhangePermission(int id, string permission)
        {
            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
                User.Identity.Name,
                MethodBase.GetCurrentMethod().Name);

            User user = userService.GetByID(id);

            user.Permission = permission;
            userService.Update(user);

            return RedirectToAction("GetAllUsers");
        }
    }
}
