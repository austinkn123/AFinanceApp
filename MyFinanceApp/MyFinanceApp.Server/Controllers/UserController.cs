﻿using AppLibrary.IRepositories;
using AppLibrary.Models;
using AppLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MyFianceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }


        [HttpGet("get-user/{id}")]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var user = await _userRepository.GetById(id);
            return Ok(user);
            
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] User model)
        {
            await _userRepository.AddUser(model);
            return Ok();
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userRepository.DeleteUser(id);
            return Ok();
        }

        [HttpPatch("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] User model)
        {
            await _userRepository.UpdateUser(model);
            return Ok();
        }
    }
}
