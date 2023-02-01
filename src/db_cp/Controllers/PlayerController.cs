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
    [Route("/api/v1/players")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly ISquadService squadService;
        private readonly IMapper mapper;
        private readonly PlayerConverters playerConverters;

        public PlayerController(IPlayerService playerService, ISquadService squadService,
                                IMapper mapper, PlayerConverters playerConverters)
        {
            this.playerService = playerService;
            this.mapper = mapper;
            this.playerConverters = playerConverters;
        }


        [EnableCors("MyPolicy")]
        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] PlayerFilterDto filter,
            [FromQuery] PlayerSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<PlayerDto>>(playerService.GetAll(filter, sortState)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(PlayerDto playerDto)
        {
            try
            {
                var addedPlayer = playerService.Add(mapper.Map<PlayerBL>(playerDto));
                return Ok(mapper.Map<PlayerDto>(addedPlayer));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Put(int id, PlayerBaseDto player)
        {
            try
            {
                var updatedPlayer = playerService.Update(mapper.Map<PlayerBL>(player,
                        o => o.AfterMap((src, dest) => dest.Id = id)));

                return updatedPlayer != null ? Ok(mapper.Map<PlayerDto>(updatedPlayer)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, PlayerBaseDto player)
        {
            try
            {
                var updatedPlayer = playerService.Update(playerConverters.convertPatch(id, player));
                return updatedPlayer != null ? Ok(mapper.Map<PlayerDto>(updatedPlayer)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedPlayer = playerService.Delete(id);
            squadService.DeleteSquadPlayersByPlayerId(id);

            return deletedPlayer != null ? Ok(mapper.Map<PlayerDto>(deletedPlayer)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var player = playerService.GetByID(id);
            return player != null ? Ok(mapper.Map<PlayerDto>(player)) : NotFound();
        }
    }
}
