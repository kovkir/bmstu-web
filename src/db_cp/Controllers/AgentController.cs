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
//    public class AgentController : Controller
//    {
//        IAgentService agentService;
//        IPlayerService playerService;
//        private readonly ILogger<AccountController> logger;

//        public AgentController(IAgentService agentService,
//                               IPlayerService playerService,
//                               ILogger<AccountController> logger)
//        {
//            this.agentService = agentService;
//            this.playerService = playerService;
//            this.logger = logger;
//        }

//        public IActionResult GetAllAgents()
//        {
//            ViewBag.Title = "Agents";

//            logger.Log(LogLevel.Information, "user: {0}; method: {1}",
//                User.Identity.Name,
//                MethodBase.GetCurrentMethod().Name);

//            AgentViewModel allAgents = new AgentViewModel
//            {
//                agents = agentService.GetAll(),
//                players = playerService.GetAll()
//            };

//            return View(allAgents);
//        }
//    }
//}
