﻿using AutoMapper;
using BlogApplication.DataAccess.Models;
using BlogApplication.DataAccess.Models.DTO.User;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography.X509Certificates;


namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/UserController")]
    public class UserController : ControllerBase
    {
        private readonly MyAppDb _db;
        private readonly IMapper _mapper;
        public UserController(MyAppDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Get all Users [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            IEnumerable<Users> userList = await _db.UsersTable.ToListAsync();
            return Ok(_mapper.Map<List<UserDTO>>(userList));
        }

        // Create a User [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO userCreateDTO)
        {
            // Custom validation for User's Name
            if (await _db.UsersTable.FirstOrDefaultAsync(u => u.Name.ToLower() == userCreateDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "User Name Already Exists");
                return BadRequest(ModelState);
            }
            Users model = _mapper.Map<Users>(userCreateDTO);

            await _db.UsersTable.AddAsync(model);
            await _db.SaveChangesAsync();

            return Ok(userCreateDTO);
        }

        // Delete a User [HttpDelete] based on Id
        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _db.UsersTable.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();

            }
            _db.UsersTable.Remove(user);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // Update a User Data [HttpPut] based on id
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            if (userUpdateDTO == null || id != userUpdateDTO.Id)
            {
                return BadRequest();
            }
            Users model = _mapper.Map<Users>(userUpdateDTO);

            _db.UsersTable.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
