using MediatR;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Features.Players.GetPlayerById
{
    public record GetPlayerByIdQuery(int id) : IRequest<Player?>;
}
