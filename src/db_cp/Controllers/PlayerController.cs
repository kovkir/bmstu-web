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
//    public class PlayerController : Controller
//    {
//        //static private IPlayerRepository playerRepository = new PlayerMock();
//        //static private IClubRepository clubRepository = new ClubMock();

//        //private IPlayerService playerService = new PlayerService(playerRepository);
//        //private IClubService clubService = new ClubService(clubRepository);

//        private IPlayerService playerService;
//        private IClubService clubService;
//        private ISquadService squadService;
//        private IUserService userService;
//        private readonly ILogger<AccountController> logger;

//        public PlayerController(IPlayerService playerService,
//                                IClubService   clubService,
//                                ISquadService  squadService,
//                                ILogger<AccountController> logger)
//        {
//            this.playerService = playerService;
//            this.clubService   = clubService;
//            this.squadService  = squadService;
//            this.logger = logger;
//        }

//        public IActionResult GetAllPlayers(PlayerSortState sortOrder = PlayerSortState.RatingDesc,
//                                           string surname = null, string country = null, string clubName = null,
//                                           uint minPrice = 0, uint maxPrice = 0, uint minRating = 0, uint maxRating = 0,
//                                           int squadId = 0)
//        {
//            ViewBag.Title = "Players";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            ViewData["IdSort"]       = sortOrder == PlayerSortState.IdAsc       ? PlayerSortState.IdDesc       : PlayerSortState.IdAsc;
//            ViewData["SurnameSort"]  = sortOrder == PlayerSortState.SurnameAsc  ? PlayerSortState.SurnameDesc  : PlayerSortState.SurnameAsc;
//            ViewData["RatingSort"]   = sortOrder == PlayerSortState.RatingDesc  ? PlayerSortState.RatingAsc    : PlayerSortState.RatingDesc;
//            ViewData["CountrySort"]  = sortOrder == PlayerSortState.CountryAsc  ? PlayerSortState.CountryDesc  : PlayerSortState.CountryAsc;
//            ViewData["ClubNameSort"] = sortOrder == PlayerSortState.ClubNameAsc ? PlayerSortState.ClubNameDesc : PlayerSortState.ClubNameAsc;
//            ViewData["PriceSort"]    = sortOrder == PlayerSortState.PriceDesc   ? PlayerSortState.PriceAsc     : PlayerSortState.PriceDesc;

//            IEnumerable<Player> players = playerService.GetByParameters(surname, country, clubName, minPrice,
//                                                                        maxPrice, minRating, maxRating, squadId);

//            PlayerViewModel allPlayers = new PlayerViewModel
//            {
//                players = playerService.GetSortPlayersByOrder(players, sortOrder),
//                myPlayers = squadService.GetMyPlayersByUserLogin(User.Identity.Name),
//                clubs = clubService.GetAll(),

//                filterPlayerViewModel = new FilterPlayerViewModel
//                {
//                    surname = surname,
//                    country = country,
//                    clubName = clubName,
//                    minPrice = minPrice,
//                    maxPrice = maxPrice,
//                    minRating = minRating,
//                    maxRating = maxRating,
//                    squadId = squadId
//                }
//            };

//            return View(allPlayers);
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
    [Route("/api/v1/players")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;
        private readonly PlayerConverters playerConverters;

        public PlayerController(IPlayerService playerService, IMapper mapper,
                                PlayerConverters playerConverters)
        {
            this.playerService = playerService;
            this.mapper = mapper;
            this.playerConverters = playerConverters;
        }

        [HttpPost("addNewPlayer")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult AddNewPlayer(PlayerDto playerDto)
        {
            var result = playerService.AddPlayer(mapper.Map<PlayerBL>(playerDto));

            return result != null ? Ok(mapper.Map<PlayerDto>(result)) : NotFound();
        }
    }
}