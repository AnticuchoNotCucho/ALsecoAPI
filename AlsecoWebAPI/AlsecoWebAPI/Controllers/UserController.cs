using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlsecoWebAPI.Interfaces;
using AlsecoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlsecoWebAPI.Controllers
{
    [ApiController]
    [Route("Users/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            if (user == false)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok("Usuario eliminado");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var userUpdated = await _userRepository.UpdateUser(user);
            if (userUpdated == false)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok("Usuario actualizado");
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _userRepository.AddUser(user);
            return Ok();
        }
            
    }
}
