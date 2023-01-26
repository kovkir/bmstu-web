//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using db_cp.ViewModels;
//using db_cp.Interfaces;
//using db_cp.Mocks;
//using db_cp.Services;
//using Microsoft.AspNetCore.Mvc;
//using db_cp.Models;
//using Microsoft.Extensions.Logging;
//using System.Reflection;

//namespace db_cp.Controllers
//{
//    public class UserController : Controller
//    {
//        //static private IUserRepository userRepository = new UserMock();
//        //static private ISquadRepository squdRepository = new SquadMock();

//        //private IUserService userService = new UserService(userRepository);
//        //private ISquadService squadService = new SquadService(squdRepository);

//        private IUserService userService;
//        private ISquadService squadService;
//        private readonly ILogger<AccountController> logger;

//        public UserController(IUserService userService,
//                              ISquadService squadService,
//                              ILogger<AccountController> logger)
//        {
//            this.userService = userService;
//            this.squadService = squadService;
//            this.logger = logger;
//        }

//        public IActionResult GetAllUsers(UserSortState sortOrder = UserSortState.IdAsc)
//        {
//            ViewBag.Title = "Users";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            ViewData["IdSort"]          = sortOrder == UserSortState.IdAsc          ? UserSortState.IdDesc          : UserSortState.IdAsc;
//            ViewData["LoginSort"]       = sortOrder == UserSortState.LoginAsc       ? UserSortState.LoginDesc       : UserSortState.LoginAsc;
//            ViewData["PermissionSort"]  = sortOrder == UserSortState.PermissionAsc  ? UserSortState.PermissionDesc  : UserSortState.PermissionAsc;
//            ViewData["RatingSquadSort"] = sortOrder == UserSortState.RatingSquadAsc ? UserSortState.RatingSquadDesc : UserSortState.RatingSquadAsc;

//            var allUsers = new UserViewModel
//            {
//                squads = squadService.GetAll(),
//                users = userService.GetSortUsersByOrder(sortOrder)
//            };

//            return View(allUsers);
//        }

//        public IActionResult СhangePermission(int id, string permission)
//        {
//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            User user = userService.GetByID(id);

//            user.Permission = permission;
//            userService.Update(user);

//            return RedirectToAction("GetAllUsers");
//        }
//    }
//}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Models;
using db_cp.Services;
using System.Linq;
using AutoMapper;
using db_cp.ModelsConverters;
using Microsoft.AspNetCore.Cors;
using db_cp.Repository;

namespace db_cp.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly UserConverters userConverters;

        public UserController(IUserService userService,
            IMapper mapper, UserConverters userConverters)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.userConverters = userConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(mapper.Map<IEnumerable<UserDto>>(userService.GetAllUsers()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserIdPasswordDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult AddUser(UserPasswordDto user)
        {
            var addedUser = userService.AddUser(mapper.Map<UserBL>(user));
  
            return Ok(mapper.Map<UserIdPasswordDto>(addedUser));
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = userService.Login(loginDto);

            return result != null ? Ok(mapper.Map<UserDto>(result)) : NotFound();
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserIdPasswordDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Register(LoginDto loginDto)
        {
            var userDto = new UserPasswordDto
            {
                Login = loginDto.Login,
                Password = loginDto.Password,
                Permission = "user"
            };

            return AddUser(userDto);
        }
    }
}