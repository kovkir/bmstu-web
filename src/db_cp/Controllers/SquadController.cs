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
using db_cp.Repository;

namespace db_cp.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/squads")]
    public class SquadController : Controller
    {
        private readonly ISquadService squadService;
        private readonly IPlayerService playerService;
        private readonly ICoachService coachService;
        private readonly IMapper mapper;
        private readonly SquadConverters squadConverters;

        public SquadController(ISquadService squadService, IPlayerService playerService,
                               ICoachService coachService, IMapper mapper,
                               SquadConverters squadConverters)
        {
            this.squadService = squadService;
            this.playerService = playerService;
            this.coachService = coachService;
            this.mapper = mapper;
            this.squadConverters = squadConverters;
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] SquadSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<SquadDto>>(squadService.GetAll(sortState)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(SquadBaseDto squadDto)
        {
            try
            {
                var addedSquad = squadService.Add(mapper.Map<SquadBL>(squadDto));
                return Ok(mapper.Map<SquadDto>(addedSquad));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // [HttpPut("{id}")]
        // [ProducesResponseType(typeof(SquadDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        // public IActionResult Put(int id, SquadBaseDto squad)
        // {
        //     try
        //     {
        //         var updatedSquad = squadService.Update(mapper.Map<SquadBL>(squad,
        //                 o => o.AfterMap((src, dest) => dest.Id = id)));

        //         return updatedSquad != null ? Ok(mapper.Map<SquadDto>(updatedSquad)) : NotFound();
        //     }
        //     catch (Exception ex)
        //     {
        //         return Conflict(ex.Message);
        //     }
        // }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, SquadBaseDto squad)
        {
            try
            {
                var updatedSquad = squadService.Update(squadConverters.convertPatch(id, squad));
                return updatedSquad != null ? Ok(mapper.Map<SquadDto>(updatedSquad)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedSquad = squadService.Delete(id);
            squadService.DeleteSquadPlayersBySquadId(id);

            return deletedSquad != null ? Ok(mapper.Map<SquadDto>(deletedSquad)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var squad = squadService.GetByID(id);
            return squad != null ? Ok(mapper.Map<SquadDto>(squad)) : NotFound();
        }

        [HttpGet("{squadId}/players")]
        public IActionResult GetPlayersBySquadId(
            int squadId,
            [FromQuery] PlayerFilterDto filter,
            [FromQuery] PlayerSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<PlayerDto>>(playerService.GetPlayersBySquadId(squadId, filter, sortState)));
        }

        [HttpGet("{squadId}/coach")]
        public IActionResult GetCoachBySquadId(int squadId)
        {
            return Ok(mapper.Map<IEnumerable<CoachDto>>(coachService.GetCoachBySquadId(squadId)));
        }

        [HttpPost("{squadId}/players")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult AddPlayerToSquad(int squadId, PlayerIdDto playerIdDto)
        {
            try
            {
                return Ok(mapper.Map<SquadDto>(squadService.AddPlayerToMySquad(squadId, playerIdDto.Id)));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("{squadId}/coach")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult AddCoachToSquad(int squadId, CoachIdDto coachIdDto)
        {
            try
            {
                return Ok(mapper.Map<SquadDto>(squadService.AddCoachToMySquad(squadId, coachIdDto.Id)));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{squadId}/players/{playerId}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult DeletePlayerFromSquad(int squadId, int playerId)
        {
            try
            {
                return Ok(mapper.Map<SquadDto>(squadService.DeletePlayerFromMySquad(squadId, playerId)));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{squadId}/coach/{coachId}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult DeleteCoachFromSquad(int squadId, int coachId)
        {
            try
            {
                return Ok(mapper.Map<SquadDto>(squadService.DeletePlayerFromMySquad(squadId, coachId)));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
