using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Features.Players.CreatePlayer;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly VideoGameAppDbContext _context;
        private readonly ISender _sender;
        public PlayerController(VideoGameAppDbContext context, ISender sender)
        {
            _context = context;
            _sender = sender;
        }
        [HttpPost("create-player")]
        public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand command)
        {
            var id = await _sender.Send(command);
            return Ok(id);
        }

        [HttpGet("get-user")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

    }
}
