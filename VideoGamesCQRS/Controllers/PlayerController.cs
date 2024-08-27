using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Text;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Features.Players.CreatePlayer;
using VideoGamesCQRS.Features.Players.DisablePlayer;
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

        [HttpPatch]
        public async Task<IActionResult> PatchPlayer(DisablePlayerCommand command)
        {
            var player = await _sender.Send(command);
            
            if (player <=0)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "An error occurred",
                    Detail = "Something went wrong while processing your request.",
                    Status = 500
                };

                await Response.WriteAsJsonAsync(problemDetails);
                return Problem();

            }

            return Ok(player);
        }

    }
}
