using MediatR;

namespace VideoGamesCQRS.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand (string Name, int Level) : IRequest<int>;
}
