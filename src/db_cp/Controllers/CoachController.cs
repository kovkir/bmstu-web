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

        public CoachController(ICoachService coachService, IMapper mapper,
                               CoachConverters coachConverters)
        {
            this.coachService = coachService;
            this.mapper = mapper;
            this.coachConverters = coachConverters;
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] CoachFilterDto filter,
            [FromQuery] CoachSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<CoachDto>>(coachService.GetAll(filter, sortState)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(CoachBaseDto coachDto)
        {
            try
            {
                var addedCoach = coachService.Add(mapper.Map<CoachBL>(coachDto));
                return Ok(mapper.Map<CoachDto>(addedCoach));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Put(int id, CoachBaseDto coach)
        {
            try
            {
                var updatedCoach = coachService.Update(mapper.Map<CoachBL>(coach,
                        o => o.AfterMap((src, dest) => dest.Id = id)));

                return updatedCoach != null ? Ok(mapper.Map<CoachDto>(updatedCoach)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // [HttpPatch("{id}")]
        // [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        // public IActionResult Patch(int id, CoachBaseDto coach)
        // {
        //     try
        //     {
        //         var updatedCoach = coachService.Update(coachConverters.convertPatch(id, coach));
        //         return updatedCoach != null ? Ok(mapper.Map<CoachDto>(updatedCoach)) : NotFound();
        //     }
        //     catch (Exception ex)
        //     {
        //         return Conflict(ex.Message);
        //     }
        // }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedCoach = coachService.Delete(id);
            return deletedCoach != null ? Ok(mapper.Map<CoachDto>(deletedCoach)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var coach = coachService.GetByID(id);
            return coach != null ? Ok(mapper.Map<CoachDto>(coach)) : NotFound();
        }
    }
}
