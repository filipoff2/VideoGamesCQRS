using MediatR;

namespace VideoGamesCQRS.Features.Players.DisablePlayer
{
        public record DisablePlayerCommand(int id) : IRequest<int>;
}
