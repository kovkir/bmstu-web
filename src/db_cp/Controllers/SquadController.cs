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

        // [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SquadDto>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public IActionResult GetAll(
            [FromQuery] SquadSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<SquadDto>>(squadService.GetAll(sortState)));
        }

        // [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
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

        // [Authorize]
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
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

        // [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedSquad = squadService.Delete(id);
            squadService.DeleteSquadPlayersBySquadId(id);

            return deletedSquad != null ? Ok(mapper.Map<SquadDto>(deletedSquad)) : NotFound();
        }

        // [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var squad = squadService.GetByID(id);
            return squad != null ? Ok(mapper.Map<SquadDto>(squad)) : NotFound();
        }

        // [Authorize]
        [HttpGet("{squadId}/players")]
        [ProducesResponseType(typeof(IEnumerable<PlayerDto>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public IActionResult GetPlayersBySquadId(
            int squadId,
            [FromQuery] PlayerFilterDto filter,
            [FromQuery] PlayerSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<PlayerDto>>(playerService.GetPlayersBySquadId(squadId, filter, sortState)));
        }

        // [Authorize]
        [HttpGet("{squadId}/players/{playerId}")]
        [ProducesResponseType(typeof(SquadPlayerDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetSquadPlayer(int squadId, int playerId)
        {
            var squadPlayer = squadService.GetSquadPlayer(squadId, playerId);
            return squadPlayer != null ? Ok(mapper.Map<SquadPlayerDto>(squadPlayer)) : NotFound();
        }

        // [Authorize]
        [HttpGet("{squadId}/coach")]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public IActionResult GetCoachBySquadId(int squadId)
        {
            return Ok(mapper.Map<IEnumerable<CoachDto>>(coachService.GetCoachBySquadId(squadId)));
        }

        // [Authorize]
        [HttpPost("{squadId}/players")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
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

        // [Authorize]
        [HttpPost("{squadId}/coach")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
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

        // [Authorize]
        [HttpDelete("{squadId}/players/{playerId}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
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

        // [Authorize]
        [HttpDelete("{squadId}/coach/{coachId}")]
        [ProducesResponseType(typeof(SquadDto), StatusCodes.Status201Created)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
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
