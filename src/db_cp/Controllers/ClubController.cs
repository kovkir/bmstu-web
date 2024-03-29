﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    [Route("/api/v1/clubs")]
    public class ClubController : Controller
    {

        private IClubService clubService;
        private IMapper mapper;
        private ClubConverters clubConverters;
        private readonly ILogger<ClubController> _logger;

        public ClubController(IClubService clubService, IMapper mapper,
                              ClubConverters clubConverters, ILogger<ClubController> logger)
        {
            this.clubService = clubService;
            this.mapper = mapper;
            this.clubConverters = clubConverters;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Club>), StatusCodes.Status200OK)]
        public IActionResult GetAll(
            [FromQuery] ClubFilterDto filter,
            [FromQuery] ClubSortState? sortState
        )
        {
             _logger.LogInformation("Clubs (Request: GET)");
            return Ok(mapper.Map<IEnumerable<ClubDto>>(clubService.GetAll(filter, sortState)));
        }

        // [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ClubDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(ClubBaseDto clubDto)
        {
            try
            {
                var addedClub = clubService.Add(mapper.Map<ClubBL>(clubDto));
                return Ok(mapper.Map<ClubDto>(addedClub));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClubDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Put(int id, ClubBaseDto club)
        {
            try
            {
                var updatedClub = clubService.Update(mapper.Map<ClubBL>(club,
                        o => o.AfterMap((src, dest) => dest.Id = id)));

                return updatedClub != null ? Ok(mapper.Map<ClubDto>(updatedClub)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // [HttpPatch("{id}")]
        // [ProducesResponseType(typeof(ClubDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        // public IActionResult Patch(int id, ClubBaseDto club)
        // {
        //     try
        //     {
        //         var updatedClub = clubService.Update(clubConverters.convertPatch(id, club));
        //         return updatedClub != null ? Ok(mapper.Map<ClubDto>(updatedClub)) : NotFound();
        //     }
        //     catch (Exception ex)
        //     {
        //         return Conflict(ex.Message);
        //     }
        // }

        // [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClubDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedClub = clubService.Delete(id);
            return deletedClub != null ? Ok(mapper.Map<ClubDto>(deletedClub)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClubDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var club = clubService.GetByID(id);
            return club != null ? Ok(mapper.Map<ClubDto>(club)) : NotFound();
        }
    }
}
