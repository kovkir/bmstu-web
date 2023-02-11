using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Models;
using db_cp.Enums;
using db_cp.Services;
using System.Linq;
using AutoMapper;
using db_cp.ModelsConverters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace db_cp.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/agents")]
    public class AgentController : Controller
    {

        private IAgentService agentService;
        private IMapper mapper;
        private AgentConverters agentConverters;

        public AgentController(IAgentService agentService, IMapper mapper,
                               AgentConverters agentConverters)
        {
            this.agentService = agentService;
            this.mapper = mapper;
            this.agentConverters = agentConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AgentDto>), StatusCodes.Status200OK)]
        public IActionResult GetAll(
            [FromQuery] AgentSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<AgentDto>>(agentService.GetAll(sortState)));
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(AgentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(AgentBaseDto agentDto)
        {
            try
            {
                var addedAgent = agentService.Add(mapper.Map<AgentBL>(agentDto));
                return Ok(mapper.Map<AgentDto>(addedAgent));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AgentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Put(int id, AgentBaseDto agent)
        {
            try
            {
                var updatedAgent = agentService.Update(mapper.Map<AgentBL>(agent,
                        o => o.AfterMap((src, dest) => dest.Id = id)));

                return updatedAgent != null ? Ok(mapper.Map<AgentDto>(updatedAgent)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // [HttpPatch("{id}")]
        // [ProducesResponseType(typeof(AgentDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        // public IActionResult Patch(int id, AgentBaseDto agent)
        // {
        //     try
        //     {
        //         var updatedAgent = agentService.Update(agentConverters.convertPatch(id, agent));
        //         return updatedAgent != null ? Ok(mapper.Map<AgentDto>(updatedAgent)) : NotFound();
        //     }
        //     catch (Exception ex)
        //     {
        //         return Conflict(ex.Message);
        //     }
        // }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AgentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedAgent = agentService.Delete(id);
            return deletedAgent != null ? Ok(mapper.Map<AgentDto>(deletedAgent)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AgentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var agent = agentService.GetByID(id);
            return agent != null ? Ok(mapper.Map<AgentDto>(agent)) : NotFound();
        }
    }
}
