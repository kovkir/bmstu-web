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
//    public class CoachController : Controller
//    {
//        //static private ICoachRepository coachRepository = new CoachMock();
//        //private ICoachService coachService = new CoachService(coachRepository);

//        private ICoachService coachService;
//        private ISquadService squadService;
//        private readonly ILogger<AccountController> logger;

//        public CoachController(ICoachService coachService,
//                               ISquadService squadService,
//                               ILogger<AccountController> logger)
//        {
//            this.coachService = coachService;
//            this.squadService = squadService;
//            this.logger = logger;
//        }

//        public IActionResult GetAllCoaches(CoachSortState sortOrder = CoachSortState.IdAsc,
//                                           string surname = null, string country = null,
//                                           uint minWorkExperience = 0, uint maxWorkExperience = 0)
//        {
//            ViewBag.Title = "Coaches";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            ViewData["IdSort"] = sortOrder == CoachSortState.IdAsc ? CoachSortState.IdDesc : CoachSortState.IdAsc;
//            ViewData["SurnameSort"] = sortOrder == CoachSortState.SurnameAsc ? CoachSortState.SurnameDesc : CoachSortState.SurnameAsc;
//            ViewData["CountrySort"] = sortOrder == CoachSortState.CountryAsc ? CoachSortState.CountryDesc : CoachSortState.CountryAsc;
//            ViewData["WorkExperienceSort"] = sortOrder == CoachSortState.WorkExperienceAsc ? CoachSortState.WorkExperienceDesc : CoachSortState.WorkExperienceAsc;

//            IEnumerable<Coach> coaches = coachService.GetByParameters(surname, country, minWorkExperience, maxWorkExperience);

//            CoachViewModel allCoaches = new CoachViewModel
//            {
//                coaches = coachService.GetSortCoachesByOrder(coaches, sortOrder),
//                myCoachId = squadService.GetMyCoachIdByUserLogin(User.Identity.Name),

//                filterCoachViewModel = new FilterCoachViewModel
//                {
//                    surname = surname,
//                    country = country,
//                    minWorkExperience = minWorkExperience,
//                    maxWorkExperience = maxWorkExperience
//                }
//            };

//            return View(allCoaches);
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


namespace db_cp.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/coaches")]
    public class CoachController : Controller
    {

        private ICoachService coachService;
        private ISquadService squadService;
        private IMapper mapper;
        private CoachConverters coachConverters;

        public CoachController(ICoachService coachService, IMapper mapper, CoachConverters coachConverters)
        {
            this.coachService = coachService;
            this.mapper = mapper;
            this.coachConverters = coachConverters;
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public IActionResult GetAllCoaches(
            [FromQuery] CoachBaseDto filter,
            [FromQuery] CoachSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<CoachDto>>(coachService.GetAllCoaches(filter, sortState)));
        }
    }
}
