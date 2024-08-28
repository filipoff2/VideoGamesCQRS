using MediatR;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Events;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly VideoGameAppDbContext _context;
        private readonly IMediator _mediator;

        public CreatePlayerCommandHandler(VideoGameAppDbContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Name = request.Name,
                Level = request.Level
            };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            await _mediator.Publish(new CreatePlayerCompletedEvent(player));
            return player.Id;
        }
    }
}
