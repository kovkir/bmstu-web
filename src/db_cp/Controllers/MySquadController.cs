﻿//using System;
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
//    public class MySquadController : Controller
//    {
//        private ISquadService  squadService;
//        private ICoachService  coachService;
//        private IUserService   userService;
//        private IClubService   clubService;
//        private IPlayerService playerService;
//        private readonly ILogger<AccountController> logger;

//        public MySquadController(ISquadService  squadService,
//                                 ICoachService  coachService,
//                                 IUserService   userService,
//                                 IClubService   clubService,
//                                 IPlayerService playerService,
//                                 ILogger<AccountController> logger)
//        {
//            this.squadService  = squadService;
//            this.coachService  = coachService;
//            this.userService   = userService;
//            this.clubService   = clubService;
//            this.playerService = playerService;
//            this.logger = logger;
//        }


//        public IActionResult GetMySquad(PlayerSortState sortOrder = PlayerSortState.IdAsc,
//                                        IsUpdata isUpdate = IsUpdata.IsNotUpdate,
//                                        int playerId = 0, int coachId = 0)
//        {
//            ViewBag.Title = "MySquad";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            ViewData["IdSort"]       = sortOrder == PlayerSortState.IdAsc       ? PlayerSortState.IdDesc       : PlayerSortState.IdAsc;
//            ViewData["SurnameSort"]  = sortOrder == PlayerSortState.SurnameAsc  ? PlayerSortState.SurnameDesc  : PlayerSortState.SurnameAsc;
//            ViewData["RatingSort"]   = sortOrder == PlayerSortState.RatingDesc  ? PlayerSortState.RatingAsc    : PlayerSortState.RatingDesc;
//            ViewData["CountrySort"]  = sortOrder == PlayerSortState.CountryAsc  ? PlayerSortState.CountryDesc  : PlayerSortState.CountryAsc;
//            ViewData["ClubNameSort"] = sortOrder == PlayerSortState.ClubNameAsc ? PlayerSortState.ClubNameDesc : PlayerSortState.ClubNameAsc;
//            ViewData["PriceSort"]    = sortOrder == PlayerSortState.PriceDesc   ? PlayerSortState.PriceAsc     : PlayerSortState.PriceDesc;

//            User user = userService.GetByLogin(User.Identity.Name);
//            Squad squad = squadService.UpdateMySquad(isUpdate, user.Id, playerId, coachId);
//            IEnumerable<Player> players = squadService.GetMyPlayersBySquadId(squad.Id);

//            MySquadViewModel mySquadViewModel = new MySquadViewModel
//            {
//                mySquad = squad,
//                myCoach = coachService.GetByID(squad.CoachId),
//                myPlayers = playerService.GetSortPlayersByOrder(players, sortOrder),
//                clubs = clubService.GetAll(),

//                player = playerService.GetByID(playerId),
//                coach = coachService.GetByID(coachId),

//                _isUpdate = isUpdate
//            };

//            return View(mySquadViewModel);
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
    [Route("/api/v1/mysquads")]
    public class MySquadController : Controller
    {
        private readonly ISquadService squadService;
        private readonly ICoachService coachService;
        private readonly IUserService userService;
        private readonly IClubService clubService;
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;
        private readonly SquadConverters squadConverters;

        public MySquadController(ISquadService squadService, ICoachService coachService,
                                 IUserService userService, IClubService clubService,
                                 IPlayerService playerService, IMapper mapper,
                                 SquadConverters squadConverters)
        {
            this.squadService = squadService;
            this.coachService = coachService;
            this.userService = userService;
            this.clubService = clubService;
            this.playerService = playerService;
            this.mapper = mapper;
            this.squadConverters = squadConverters;
        }
    }
}
