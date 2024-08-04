using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Features.Players.CreatePlayer;
using VideoGamesCQRS.Features.Players.GetPlayerById;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ISender _sender;
        public PlayerController( ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand command)
        {
            var id = await _sender.Send(command);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _sender.Send(new GetPlayerByIdQuery(id));
            if (player is null)
            {
                return NotFound();
            }
            return Ok(player);
        }

    }
}
