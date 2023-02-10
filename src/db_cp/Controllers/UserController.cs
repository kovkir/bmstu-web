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
    [Route("/api/v1/users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly ISquadService squadService;
        private readonly IMapper mapper;
        private readonly UserConverters userConverters;

        public UserController(IUserService userService, ISquadService squadService,
                              IMapper mapper, UserConverters userConverters)
        {
            this.userService = userService;
            this.squadService = squadService;
            this.mapper = mapper;
            this.userConverters = userConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public IActionResult GetAll(
            [FromQuery] UserSortState? sortState
        )
        {
            return Ok(mapper.Map<IEnumerable<UserDto>>(userService.GetAll(sortState)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserIdPasswordDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(UserPasswordDto userDto)
        {
            try
            {
                var addedUser = userService.Add(mapper.Map<UserBL>(userDto));
                return Ok(mapper.Map<UserIdPasswordDto>(addedUser));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // [HttpPut("{id}")]
        // [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        // [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        // public IActionResult Put(int id, UserPasswordDto user)
        // {
        //     try
        //     {
        //         var updatedUser = userService.Update(mapper.Map<UserBL>(user,
        //                 o => o.AfterMap((src, dest) => dest.Id = id)));

        //         return updatedUser != null ? Ok(mapper.Map<UserDto>(updatedUser)) : NotFound();
        //     }
        //     catch (Exception ex)
        //     {
        //         return Conflict(ex.Message);
        //     }
        // }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, UserPasswordDto user)
        {
            try
            {
                var updatedUser = userService.Update(userConverters.convertPatch(id, user));
                return updatedUser != null ? Ok(mapper.Map<UserDto>(updatedUser)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedUser = userService.Delete(id);
            return deletedUser != null ? Ok(mapper.Map<UserDto>(deletedUser)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var user = userService.GetByID(id);
            return user != null ? Ok(mapper.Map<UserDto>(user)) : NotFound();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = userService.Login(loginDto);
            return result != null ? Ok(mapper.Map<UserDto>(result)) : NotFound();
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserIdPasswordDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Register(LoginDto loginDto)
        {
            var userDto = new UserPasswordDto
            {
                Login = loginDto.Login,
                Password = loginDto.Password,
                Permission = "user"
            };

            return Add(userDto);
        }
    }
}
