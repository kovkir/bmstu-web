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
//    public class SquadController : Controller
//    {
//        //static private ISquadRepository squadRepository = new SquadMock();
//        //private ICoachService coachService = new CoachService(coachRepository);

//        private ISquadService squadService;
//        private ICoachService coachService;
//        private readonly ILogger<AccountController> logger;

//        public SquadController(ISquadService squadService,
//                               ICoachService coachService,
//                               ILogger<AccountController> logger)
//        {
//            this.squadService = squadService;
//            this.coachService = coachService;
//            this.logger = logger;
//        }

//        public IActionResult GetAllSquads(SquadSortState sortOrder = SquadSortState.IdAsc)
//        {
//            ViewBag.Title = "Squads";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            ViewData["IdSort"]           = sortOrder == SquadSortState.IdAsc           ? SquadSortState.IdDesc           : SquadSortState.IdAsc;
//            ViewData["CoachSurnameSort"] = sortOrder == SquadSortState.CoachSurnameAsc ? SquadSortState.CoachSurnameDesc : SquadSortState.CoachSurnameAsc;
//            ViewData["NameSort"]         = sortOrder == SquadSortState.NameAsc         ? SquadSortState.NameDesc         : SquadSortState.NameAsc;
//            ViewData["RatingSort"]       = sortOrder == SquadSortState.RatingAsc       ? SquadSortState.RatingDesc       : SquadSortState.RatingAsc;

//            var allSquads = new SquadViewModel
//            {
//                coaches = coachService.GetAll(),
//                squads = squadService.GetSortSquadsByOrder(sortOrder)
//            };

//            return View(allSquads);
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
    [Route("/api/v1/squads")]
    public class SquadController : Controller
    {
        private readonly ISquadService squadService;
        private readonly ICoachService coachService;
        private readonly IMapper mapper;
        private readonly SquadConverters squadConverters;

        public SquadController(ISquadService squadService, ICoachService coachService,
                               IMapper mapper, SquadConverters squadConverters)
        {
            this.squadService = squadService;
            this.coachService = coachService;
            this.mapper = mapper;
            this.squadConverters = squadConverters;
        }
    }
}
