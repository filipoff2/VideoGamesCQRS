using MediatR;
using VideoGamesCQRS.Data;
using VideoGamesCQRS.Models;

namespace VideoGamesCQRS.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly VideoGameAppDbContext _context;

        public CreatePlayerCommandHandler(VideoGameAppDbContext context)
        {
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
            return player.Id;
        }
    }
}
