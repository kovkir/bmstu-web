//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using db_cp.ViewModels;
//using db_cp.Interfaces;
//using db_cp.Mocks;
//using db_cp.Services;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using db_cp.Models;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.Extensions.Logging;
//using System.Reflection;

//namespace db_cp.Controllers 
//{
//    public class AccountController : Controller
//    {
//        //static private IUserRepository userRepository = new UserMock();
//        //private IUserService userService = new UserService(userRepository);

//        IUserService userService;
//        ISquadService squadService;
//        private readonly ILogger<AccountController> logger;

//        public AccountController(IUserService userService,
//                                 ISquadService squadService,
//                                 ILogger<AccountController> logger)
//        {
//            this.userService = userService;
//            this.squadService = squadService;
//            this.logger = logger;
//        }

//        [HttpGet]
//        public IActionResult Register()
//        {
//            ViewBag.Title = "Register";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Register(RegisterViewModel model)
//        {
//            ViewBag.Title = "Register";

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    User user = new User
//                    {
//                        Login = model.Login,
//                        Password = model.Password,
//                        Permission = "user"
//                    };

//                    userService.Add(user);

//                    Squad squad = new Squad
//                    {
//                        CoachId = 0,
//                        Name = model.NameMySquad,
//                        Rating = 0
//                    };

//                    squadService.Add(squad);

//                    await Authenticate(user);

//                    logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                        User.Identity.Name,
//                        MethodBase.GetCurrentMethod().Name);

//                    return RedirectToAction("Index", "Home");
//                }
//                catch (Exception ex)
//                {
//                    logger.Log(LogLevel.Information, "user: {0}; method: {1}; error: {2}",
//                        User.Identity.Name,
//                        MethodBase.GetCurrentMethod().Name,
//                        ex.Message);


//                    Console.Write("Этот логин уже занят");
//                    ModelState.AddModelError("", "Этот логин уже занят");
//                }
//            }
//            else
//                ModelState.AddModelError("", "Некорректные данные");

//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult Login()
//        {
//            ViewBag.Title = "Login";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(LoginViewModel model)
//        { 
//            ViewBag.Title = "Login";

//            if (ModelState.IsValid)
//            {
//                User user = userService.GetByLogin(model.Login);

//                if (user != null && user.Password == model.Password)
//                {
//                    await Authenticate(user);

//                    logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                        User.Identity.Name,
//                        MethodBase.GetCurrentMethod().Name);

//                    return RedirectToAction("Index", "Home");
//                }
//                else
//                {
//                    logger.Log(LogLevel.Information, "user: {0}; method: {1}; error: {2}",
//                        User.Identity.Name,
//                        MethodBase.GetCurrentMethod().Name,
//                        "Некорректные логин и(или) пароль");

//                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
//                }
//            }
//            else
//                ModelState.AddModelError("", "Некорректные логин и(или) пароль");

//            return View(model);
//        }

//        private async Task Authenticate(User user)
//        {
//            var claims = new List<Claim>
//            {
//                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
//                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Permission)
//            };

//            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
//                ClaimsIdentity.DefaultRoleClaimType);

//            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
//        }

//        public async Task<IActionResult> Logout()
//        {
//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

//            return RedirectToAction("Index", "Home");
//        }
//    }
//}
