﻿using EFCore_CodeFirst.Dto.Players;
using EFCore_CodeFirst.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync([FromBody]CreatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest();
            }
            await _playerService.CreatePlayerAsync(playerRequest);
            return Ok("Record has been added successfully.");
        }

    }
}
