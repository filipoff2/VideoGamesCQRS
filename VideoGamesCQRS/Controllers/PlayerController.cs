using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly VideoGameAppDbContext _context;
        public PlayerController(VideoGameAppDbContext context)
        {
            _context = context;
        }
        [HttpPost("create-player")]
        public async Task<ActionResult<int>> CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return Ok(player.Id);
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
